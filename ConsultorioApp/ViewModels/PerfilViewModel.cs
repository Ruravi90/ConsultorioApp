using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioApp.Database;
using Microsoft.Maui.Controls;
using ConsultorioApp.Models;
using ConsultorioApp.Services;
using ConsultorioApp.Views;
using Microsoft.Maui.Storage;

namespace ConsultorioApp.ViewModels
{
    public partial class PerfilViewModel : ObservableObject
    {
        private readonly IUsuarioStore _usuarioStore;
        private readonly IRolStore _rolStore;

        [ObservableProperty]
        private Usuario usuario;
        public ObservableCollection<Rol> Roles { get; set; } = new();

        [ObservableProperty]
        private Rol rolSeleccionado;

        public PerfilViewModel(IUsuarioStore usuarioStore, IRolStore rolStore)
        {
            _usuarioStore = usuarioStore;
            _rolStore = rolStore;
            CargarDatos();
        }

        [ObservableProperty]
        private bool puedeEditar;

        private async Task CargarDatos()
        {
            int usuarioId = Preferences.Get("usuario_id", -1);
            if (usuarioId == -1) return;

            var usuario = await _usuarioStore.GetByIdAsync(usuarioId);
            Usuario = usuario;
            
            var roles = await _rolStore.GetAllAsync();
            foreach (var rol in roles)
            {
                Roles.Add(rol);
            }
            
            // Selecciona el rol actual
            RolSeleccionado = Roles.FirstOrDefault(r => r.Id == usuario.RolId);
        }

        [RelayCommand]
        private async Task GuardarCambios()
        {
            await _usuarioStore.UpdateAsync(Usuario);
            await Shell.Current.DisplayAlert("Éxito", "Cambios guardados.", "Aceptar");
        }
        
        [RelayCommand]
        private async Task IrACambiarContraseña()
        {
            await Shell.Current.GoToAsync(nameof(CambiarContraseñaPage));
        }
    }
}