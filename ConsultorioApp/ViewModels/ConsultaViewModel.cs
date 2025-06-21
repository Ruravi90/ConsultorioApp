using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ConsultorioApp.Models;
using ConsultorioApp.Services;
using Microsoft.Maui.ApplicationModel;

namespace ConsultorioApp.ViewModels
{
    public partial class ConsultaViewModel : ObservableObject
    {
        private readonly IPacienteStore _pacienteStore;
        private readonly IConsultaService _consultaService;

        [ObservableProperty]
        private List<Paciente> pacientes;

        [ObservableProperty]
        private Paciente pacienteSeleccionado;

        [ObservableProperty]
        private Paciente nuevoPaciente = new();

        [ObservableProperty]
        private Consulta nuevaConsulta;

        public ConsultaViewModel(IPacienteStore pacienteStore, IConsultaService consultaService)
        {
            _pacienteStore = pacienteStore;
            _consultaService = consultaService;

            CargarPacientesAsync();
            // Inicializa con valores por defecto
            NuevaConsulta = new Consulta
            {
                FechaInicio = DateTime.Now,
                Activa = true
            };
        }

        private async Task CargarPacientesAsync()
        {
            var lista = await _pacienteStore.GetAllAsync();
            Pacientes = lista;
        }

        [RelayCommand]
        private async Task AgregarPaciente()
        {
            if (string.IsNullOrWhiteSpace(NuevoPaciente.NombreCompleto) ||
                string.IsNullOrWhiteSpace(NuevoPaciente.Dni))
            {
                await Shell.Current.DisplayAlert("Error", "Ingrese nombre y DNI del paciente", "Aceptar");
                return;
            }

            await _pacienteStore.AddAsync(NuevoPaciente);
            Pacientes.Add(NuevoPaciente);
            PacienteSeleccionado = NuevoPaciente;

            // Reinicia datos para crear nueva consulta
            NuevaConsulta = new Consulta
            {
                PacienteId = NuevoPaciente.Id,
                FechaInicio = DateTime.Now,
                Activa = true
            };
            
            await CargarPacientesAsync();
        }

        [RelayCommand]
        private async Task GuardarConsulta()
        {
            if (PacienteSeleccionado == null)
            {
                await Shell.Current.DisplayAlert("Error", "Seleccione o cree un paciente primero.", "Aceptar");
                return;
            }

            NuevaConsulta.PacienteId = PacienteSeleccionado.Id;

            await _consultaService.AddAsync(NuevaConsulta);

            await Shell.Current.DisplayAlert("Éxito", "Consulta guardada correctamente.", "Aceptar");
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        private async Task LimpiarFormularioAsync()
        {
            bool confirmado = await Shell.Current.DisplayAlert(
                "Limpiar formulario",
                "¿Estás seguro de que deseas limpiar los campos?",
                "Sí", "No");

            if (confirmado)
            {
                ReiniciarFormulario();
            }
        }
        private void ReiniciarFormulario()
        {
            bool confirmado = true; // Puedes usar DisplayAlert si lo deseas

            if (confirmado)
            {
                NuevaConsulta = new Consulta
                {
                    PacienteId = PacienteSeleccionado?.Id ?? -1,
                    FechaInicio = DateTime.Now,
                    Activa = true
                };

                // Opcional – Si también quieres limpiar síntomas u otros campos
                NuevaConsulta.Motivo = string.Empty;
                NuevaConsulta.Sintomas = string.Empty;
                NuevaConsulta.Observaciones = string.Empty;

                // Muestra un mensaje de Toast (si usas CommunityToolkit.Maui)
                MainThread.BeginInvokeOnMainThread(()  => 
                {
                    Toast.Make("Formulario limpiado", ToastDuration.Short).Show();
                });
            }
        }
    }
}