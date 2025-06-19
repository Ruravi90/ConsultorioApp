using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ConsultorioApp.Interfaces;
using ConsultorioApp.Models;
using ConsultorioApp.Services;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.ViewModels;

public partial class CitaDetalleViewModel : ObservableObject
{
    private readonly ICitaService _citaService;
    private readonly IPacienteService _pacienteService;

    [ObservableProperty] public Cita cita;

    
    // 📦 Constructor principal
    public CitaDetalleViewModel(ICitaService citaService, IPacienteService pacienteService)
    {
        _citaService = citaService;
        _pacienteService = pacienteService;

        cita = cita ?? new Cita();
        CargarPacientes();
    }

    public ObservableCollection<Paciente> Pacientes { get; set; } = new();

    private async Task CargarPacientes()
    {
        var lista = await _pacienteService.GetAllAsync();
        foreach (var p in lista) Pacientes.Add(p);
    }

    private async Task Guardar()
    {
        if (cita.PacienteId <= 0)
        {
            await Shell.Current.DisplayAlert("Error", "Seleccione un paciente válido.", "Aceptar");
            return;
        }

        if (cita.Fecha < DateTime.Now)
        {
            await Shell.Current.DisplayAlert("Error", "La cita no puede ser en el pasado.", "Aceptar");
            return;
        }

        if (string.IsNullOrWhiteSpace(cita.Motivo))
        {
            await Shell.Current.DisplayAlert("Error", "El motivo es obligatorio.", "Aceptar");
            return;
        }

        try
        {
            if (cita.Id == 0)
                await _citaService.AddAsync(cita);
            else
                await _citaService.UpdateAsync(cita);

            await Shell.Current.DisplayAlert("Éxito", "Cita guardada correctamente.", "Aceptar");
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", $"No se pudo guardar la cita: {ex.Message}", "Aceptar");
        }
    }

    private async Task Cancelar()
    {
        await Shell.Current.GoToAsync("..");
    }
}