using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioApp.Views;

namespace ConsultorioApp.ViewModels;

public partial class RegistroViewModel : ObservableObject
{
    [ObservableProperty]
    private string nombreUsuario;

    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string contraseña;

    [ObservableProperty]
    private string confirmarContraseña;

    [RelayCommand]
    private async Task Registrar()
    {
        if (string.IsNullOrWhiteSpace(NombreUsuario) ||
            string.IsNullOrWhiteSpace(Email) ||
            string.IsNullOrWhiteSpace(Contraseña) ||
            string.IsNullOrWhiteSpace(ConfirmarContraseña))
        {
            Toast.Make("Todos los campos son obligatorios").Show();
            return;
        }

        if (Contraseña != ConfirmarContraseña)
        {
            Toast.Make("Las contraseñas no coinciden.").Show();
            return;
        }

        // Aquí puedes conectar con SQLite o API
        Toast.Make("Registro correcto!").Show();
        
        await Shell.Current.GoToAsync("///LoginPage");
    }

    [RelayCommand]
    private async Task IrALogin()
    {
        if (Shell.Current == null)
        {
            Debug.WriteLine("Shell es null");
            return;
        }

        try
        {
            await Shell.Current.GoToAsync("///LoginPage");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error al navegar: {ex.Message}");
            await Shell.Current.DisplayAlert("Error", "No se pudo navegar.", "Aceptar");
        }
    }
}