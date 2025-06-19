using ConsultorioApp.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        // 🔒 Oculta el menú lateral
        Shell.SetNavBarIsVisible(this, false);
        Shell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled);
    }
}