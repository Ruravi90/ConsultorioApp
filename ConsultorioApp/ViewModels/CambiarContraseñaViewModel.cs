using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioApp.Database;
using Microsoft.Maui.Controls;
using ConsultorioApp.Models;
using ConsultorioApp.Services;
using Microsoft.Maui.Storage;

namespace ConsultorioApp.ViewModels
{
    public partial class CambiarContraseñaViewModel : ObservableObject
    {
        private readonly IUsuarioStore _usuarioStore;

        [ObservableProperty]
        private string contraseñaActual;

        [ObservableProperty]
        private string nuevaContraseña;

        [ObservableProperty]
        private string confirmarContraseña;

        [ObservableProperty]
        private string mensajeError;

        public CambiarContraseñaViewModel(IUsuarioStore usuarioStore)
        {
            _usuarioStore = usuarioStore;
        }

        [RelayCommand]
        private async Task GuardarContraseña()
        {
            int usuarioId = Preferences.Get("usuario_id", -1);
            if (usuarioId == -1) return;

            var usuario = await _usuarioStore.GetByIdAsync(usuarioId);

            // Validaciones
            if (string.IsNullOrWhiteSpace(ContraseñaActual))
            {
                MensajeError = "La contraseña actual es obligatoria";
                return;
            }

            if (!BCrypt.Net.BCrypt.Verify(ContraseñaActual, usuario.Contraseña))
            {
                MensajeError = "La contraseña actual es incorrecta";
                return;
            }

            if (string.IsNullOrWhiteSpace(NuevaContraseña) || NuevaContraseña.Length < 6)
            {
                MensajeError = "La nueva contraseña debe tener al menos 6 caracteres";
                return;
            }

            if (NuevaContraseña != ConfirmarContraseña)
            {
                MensajeError = "Las contraseñas no coinciden";
                return;
            }

            // Encriptar y guardar
            usuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(NuevaContraseña);
            await _usuarioStore.UpdateAsync(usuario);

            await Shell.Current.DisplayAlert("Éxito", "Contraseña actualizada correctamente", "Aceptar");
            await Shell.Current.GoToAsync("..");
        }
    }
}