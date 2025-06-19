using System;
using System.Diagnostics;
using ConsultorioApp.Interfaces;
using ConsultorioApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace ConsultorioApp;

public partial class App : Application
{

    public App(IUsuarioService usuarioService)
    {
        InitializeComponent();
        MainPage = new AppShell();
        VerificarSesionAsync();
    }

    private void VerificarSesionAsync()
    {
        Dispatcher.Dispatch(async () =>
        {
            try
            {
                // Acceso seguro al proveedor de servicios
                var services = Application.Current?.Handler?.MauiContext?.Services;

                if (services == null)
                    throw new InvalidOperationException("Servicios no disponibles");

                var sessionManager = services.GetService<ISessionManager>();

                if (sessionManager == null)
                {
                    await Shell.Current.GoToAsync("//LoginPage");
                    return;
                }

                if (sessionManager.EstaLogueado)
                {
                    await Shell.Current.GoToAsync("//MainPage");
                }
                else
                {
                    await Shell.Current.GoToAsync("//LoginPage");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al validar sesión: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "No se pudo cargar la sesión.", "Aceptar");
            }
        });
    }
}