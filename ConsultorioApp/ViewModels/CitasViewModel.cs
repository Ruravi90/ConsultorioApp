using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ConsultorioApp.Database;
using ConsultorioApp.Interfaces;
using ConsultorioApp.Models;
using ConsultorioApp.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.ViewModels;

public class CitasViewModel : ObservableObject
{
    private readonly ICitaService _citaService;
    public ObservableCollection<Cita> Citas { get; set; } = new();

    // 📦 Constructor principal
    public CitasViewModel(ICitaService citaService)
    {
        _citaService = citaService;
        CargarCitas();
    }
    private async Task CargarCitas()
    {
        var lista = await _citaService.GetAllAsync();

        Citas.Clear();
        foreach (var c in lista) Citas.Add(c);
    }

    private async Task NuevaCita()
    {
        await Shell.Current.GoToAsync(nameof(CitaDetallePage));
    }

    private async Task Eliminar(Cita cita)
    {
        if (cita == null) return;
        var confirm = await Shell.Current.DisplayAlert("Eliminar", "¿Está seguro?", "Sí", "No");
        if (!confirm) return;
        
        await _citaService.DeleteAsync(cita.Id);
        await CargarCitas();
    }
}