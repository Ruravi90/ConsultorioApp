using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioApp.Interfaces;
using ConsultorioApp.Services;
using ConsultorioApp.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace ConsultorioApp.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IUsuarioService _usuarioService;
    [ObservableProperty]
    private string nombreUsuario;

    [ObservableProperty]
    private string nombreUsuarioError;

    [ObservableProperty]
    private string contraseña;

    [ObservableProperty]
    private string contraseñaError;

    public LoginViewModel(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [RelayCommand]
    private async Task IniciarSesion()
    {
        bool tieneErrores = false;

        // Validación del correo
        if (string.IsNullOrWhiteSpace(NombreUsuario))
        {
            NombreUsuarioError = "El usuario es obligatorio";
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
        bool validado = await _usuarioService.ValidarUsuario(NombreUsuario, Contraseña);

        if (validado)
        {
            var usuario = await _usuarioService.GetUsuarioPorUsuario(NombreUsuario);
            Preferences.Set("usuario_logueado", true);
            Preferences.Set("usuario_id", usuario.Id);
            Preferences.Set("usuario_rol", usuario.Rol.Nombre);
            await Shell.Current.GoToAsync("//MainPage");
        }
        else
        {
            Toast.Make("Usuario o contraseña incorrectos.").Show();
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