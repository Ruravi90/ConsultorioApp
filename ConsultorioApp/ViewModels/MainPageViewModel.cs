using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace ConsultorioApp.ViewModels;

public partial class MainPageViewModel: ObservableObject
{
    [RelayCommand]
    private async Task CerrarSesion()
    {
        Preferences.Remove("usuario_logueado");

        await Shell.Current.GoToAsync("//LoginPage");
    }
}