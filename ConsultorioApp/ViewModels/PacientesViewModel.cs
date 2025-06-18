using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioApp.Data;
using ConsultorioApp.Models;
using ConsultorioApp.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.ViewModels;

public partial class PacientesViewModel : ObservableObject
{
    [ObservableProperty] private string? filtroNombre;

    public ObservableCollection<Paciente> Pacientes { get; set; } = new();

    [RelayCommand]
    private async Task CargarPacientes()
    {
        await using var db = new AppDbContext();
        var lista = await db.Pacientes.ToListAsync();

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

        await using var db = new AppDbContext();
        db.Pacientes.Remove(paciente);
        await db.SaveChangesAsync();
        await CargarPacientes();
    }
}