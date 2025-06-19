using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioApp.Interfaces;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.ViewModels
{
    public partial class SplashScreenViewModel : ObservableObject
    {
        private readonly IUsuarioService _usuarioService;

        public SplashScreenViewModel(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            IniciarAsync();
        }

        [RelayCommand]
        private async Task IniciarAsync()
        {
            // Simula una carga (opcional)
            await Task.Delay(2000);

            bool sesionIniciada = await _usuarioService.UsuarioAutenticadoAsync();

            await Shell.Current.GoToAsync(sesionIniciada ? "//MainPage" : "//LoginPage");
        }
    }
}