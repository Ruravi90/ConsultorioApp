using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioApp.Views;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string nombreUsuario;

    [ObservableProperty]
    private string nombreUsuarioError;

    [ObservableProperty]
    private string contraseña;

    [ObservableProperty]
    private string contraseñaError;

    [RelayCommand]
    private async Task IniciarSesion()
    {
        bool tieneErrores = false;

        // Validación del correo
        if (string.IsNullOrWhiteSpace(NombreUsuario))
        {
            NombreUsuarioError = "El correo es obligatorio";
            tieneErrores = true;
        }
        else if (!IsValidEmail(NombreUsuario))
        {
            NombreUsuarioError = "Ingrese un correo válido";
            tieneErrores = true;
        }
        else
        {
            NombreUsuarioError = null;
        }

        // Validación de contraseña
        if (string.IsNullOrWhiteSpace(Contraseña))
        {
            ContraseñaError = "La contraseña es obligatoria";
            tieneErrores = true;
        }
        else
        {
            ContraseñaError = null;
        }

        if (tieneErrores) return;

        // Aquí va la lógica de autenticación
        if (NombreUsuario == "admin@example.com" && Contraseña == "1234")
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "Usuario o contraseña incorrectos.", "Aceptar");
        }
    }

    // 🧮 Método de validación de correo
    private bool IsValidEmail(string email)
    {
        var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern);
    }
    
    [RelayCommand]
    private async Task IrARegistro()
    {
        await Shell.Current.GoToAsync("//RegistroPage");
    }
}