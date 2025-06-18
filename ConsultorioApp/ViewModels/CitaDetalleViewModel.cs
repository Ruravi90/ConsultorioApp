using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ConsultorioApp.Data;
using ConsultorioApp.Models;
using ConsultorioApp.Services;

namespace ConsultorioApp.ViewModels;

public partial class CitaDetalleViewModel : ObservableObject
{
    private readonly CitaService _citaService;
    private readonly AppDbContext _dbContext;
    private readonly PacienteService _pacienteService;

    [ObservableProperty] public Cita cita;

    // ✅ Constructor vacío para soporte XAML
    public CitaDetalleViewModel() : this(null)
    {
    }

    // 📦 Constructor principal
    public CitaDetalleViewModel(Cita cita = null)
    {
        _dbContext = new AppDbContext();
        _citaService = new CitaService(_dbContext);
        _pacienteService = new PacienteService(_dbContext);

        cita = cita ?? new Cita();
        CargarPacientes();
    }

    public ObservableCollection<Paciente> Pacientes { get; set; } = new();

    private async Task CargarPacientes()
    {
        var lista = await _pacienteService.GetAll();
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
                await _citaService.Add(cita);
            else
                await _citaService.Update(cita);

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