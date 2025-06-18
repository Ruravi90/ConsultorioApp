using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioApp.Data;
using ConsultorioApp.Models;
using ConsultorioApp.Services;

namespace ConsultorioApp.ViewModels;

public partial class PacienteDetalleViewModel : ObservableObject
{
    private readonly AppDbContext _dbContext;

    private readonly PacienteService _service;

    [ObservableProperty] private Paciente paciente;

    // ✅ Constructor vacío para soporte desde XAML
    public PacienteDetalleViewModel() : this(null)
    {
    }

    // 📦 Constructor principal
    public PacienteDetalleViewModel(Paciente paciente = null)
    {
        _dbContext = new AppDbContext();
        _service = new PacienteService(_dbContext);
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
                await _service.Add(Paciente);
            else
                await _service.Update(Paciente);

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