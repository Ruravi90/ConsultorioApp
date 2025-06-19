using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioApp.Interfaces;
using ConsultorioApp.Models;
using ConsultorioApp.Services;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.ViewModels;

public partial class PacienteDetalleViewModel : ObservableObject
{
    private readonly IPacienteService _pacienteService;

    [ObservableProperty] private Paciente paciente;
    

    // 📦 Constructor principal
    public PacienteDetalleViewModel(IPacienteService pacienteService )
    {
        _pacienteService = pacienteService;
        Paciente = paciente ?? new Paciente();
    }

    [RelayCommand]
    private async Task Guardar()
    {
        if (string.IsNullOrWhiteSpace(Paciente.Nombre) ||
            string.IsNullOrWhiteSpace(Paciente.Telefono))
        {
            await Shell.Current.DisplayAlert("Error", "Todos los campos son obligatorios.", "Aceptar");
            return;
        }

        try
        {
            if (Paciente.Id == 0)
                await _pacienteService.AddAsync(Paciente);
            else
                await _pacienteService.UpdateAsync(Paciente);

            await Shell.Current.DisplayAlert("Éxito", "Datos guardados correctamente.", "Aceptar");
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", $"No se pudo guardar: {ex.Message}", "Aceptar");
        }
    }

    [RelayCommand]
    private async Task Cancelar()
    {
        await Shell.Current.GoToAsync("..");
    }
}