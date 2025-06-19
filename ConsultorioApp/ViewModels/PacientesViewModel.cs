using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioApp.Interfaces;
using ConsultorioApp.Models;
using ConsultorioApp.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.ViewModels;

public partial class PacientesViewModel : ObservableObject
{
    private readonly IPacienteService _pacienteService;
    [ObservableProperty] private string? filtroNombre;

    public ObservableCollection<Paciente> Pacientes { get; set; } = new();
    // 📦 Constructor principal
    public PacientesViewModel(IPacienteService pacienteService )
    {
        _pacienteService = pacienteService;
    }

    [RelayCommand]
    private async Task CargarPacientes()
    {
        var lista = await _pacienteService.GetAllAsync();

        Pacientes.Clear();
        foreach (var p in lista) Pacientes.Add(p);
    }

    [RelayCommand]
    private void Filtrar()
    {
        if (string.IsNullOrWhiteSpace(FiltroNombre))
        {
            CargarPacientes();
            return;
        }

        var resultado = Pacientes.Where(p => p.Nombre.Contains(FiltroNombre, StringComparison.OrdinalIgnoreCase))
            .ToList();

        Pacientes.Clear();
        foreach (var p in resultado) Pacientes.Add(p);
    }

    [RelayCommand]
    private async Task NuevoPaciente()
    {
        await Shell.Current.GoToAsync(nameof(PacienteDetallePage));
    }

    [RelayCommand]
    private async Task Eliminar(Paciente paciente)
    {
        if (paciente == null) return;
        var confirm = await Shell.Current.DisplayAlert("Eliminar", "¿Está seguro?", "Sí", "No");
        if (!confirm) return;
        
        await _pacienteService.DeleteAsync(paciente.Id);
        await CargarPacientes();
    }
}