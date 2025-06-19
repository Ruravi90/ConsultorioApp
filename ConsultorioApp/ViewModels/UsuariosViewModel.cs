using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ConsultorioApp.Interfaces;
using ConsultorioApp.Models;
using ConsultorioApp.Views;

namespace ConsultorioApp.ViewModels
{
    public partial class UsuariosViewModel : ObservableObject
    {
        private readonly IUsuarioService _usuarioService;

        public ObservableCollection<Usuario> Usuarios { get; set; } = new();

        public UsuariosViewModel(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            CargarUsuarios();
        }

        private async Task CargarUsuarios()
        {
            var lista = await _usuarioService.GetAllAsync();
            foreach (var u in lista)
            {
                Usuarios.Add(u);
            }
        }

        [RelayCommand]
        private async Task NuevoUsuario()
        {
            await Shell.Current.GoToAsync(nameof(RegistroPage));
        }

        [RelayCommand]
        private async Task EditarUsuario(Usuario usuario)
        {
            await Shell.Current.GoToAsync($"{nameof(RegistroPage)}?id={usuario.Id}");
        }
    }
}