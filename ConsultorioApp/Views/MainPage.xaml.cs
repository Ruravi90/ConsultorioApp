using ConsultorioApp.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.Views;


public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        Shell.SetFlyoutBehavior(this, FlyoutBehavior.Flyout);
        Shell.SetNavBarIsVisible(this, true);
    }
}