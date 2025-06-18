using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ConsultorioApp.Data;
using ConsultorioApp.Models;
using ConsultorioApp.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.ViewModels;

public class CitasViewModel : ObservableObject
{
    public ObservableCollection<Cita> Citas { get; set; } = new();

    private async Task CargarCitas()
    {
        await using var db = new AppDbContext();
        var lista = await db.Citas.Include(c => c.Paciente).OrderBy(c => c.Fecha).ToListAsync();

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

        await using var db = new AppDbContext();
        db.Citas.Remove(cita);
        await db.SaveChangesAsync();
        await CargarCitas();
    }
}