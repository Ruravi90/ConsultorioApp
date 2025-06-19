using ConsultorioApp.Interfaces;
using ConsultorioApp.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.Views;

public partial class RegistroPage : ContentPage
{
    private readonly IUsuarioService _usuarioService;
    public RegistroPage(RegistroViewModel viewModel,IUsuarioService usuarioService)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _usuarioService = usuarioService;
        VerificarSesionAsync();
    }
    private void VerificarSesionAsync()
    {
        Dispatcher.Dispatch(async () =>
        {
            bool sesionIniciada = await _usuarioService.UsuarioAutenticadoAsync();
        
            if (sesionIniciada)
            {
                Shell.SetNavBarIsVisible(this, true);
                Shell.SetFlyoutBehavior(this, FlyoutBehavior.Flyout);
            }
            else
            {
                Shell.SetNavBarIsVisible(this, false);
                Shell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled);
            }
        });
    }
}