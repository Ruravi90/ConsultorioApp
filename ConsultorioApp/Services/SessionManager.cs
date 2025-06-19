using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using ConsultorioApp.Database;
using Microsoft.Maui.Storage;

namespace ConsultorioApp.Services
{
    public class SessionManager : ISessionManager
    {
        private readonly IUsuarioStore _usuarioStore;

        public SessionManager(IUsuarioStore usuarioStore)
        {
            _usuarioStore = usuarioStore;
        }

        public bool EstaLogueado => Preferences.Get("usuario_logueado", false);

        public int? UsuarioId => EstaLogueado ? Preferences.Get("usuario_id", -1) : (int?)null;

        public string RolNombre => Preferences.Get("usuario_rol_nombre", "Invitado");

        public async Task<bool> UsuarioAutenticadoAsync()
        {
            return EstaLogueado && 
                   !string.IsNullOrEmpty(Preferences.Get("usuario_email", "")) &&
                   await _usuarioStore.AnyAsync(u => u.NombreUsuario == Preferences.Get("usuario_email", ""));
        }

        public async Task IniciarSesion(string nombreUsuario, string contraseña)
        {
            var usuario = await _usuarioStore.GetPorNombreUsuario(nombreUsuario);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(contraseña, usuario.Contraseña))
            {
                throw new Exception("Credenciales inválidas");
            }

            // Guarda datos en sesión
            Preferences.Set("usuario_logueado", true);
            Preferences.Set("usuario_id", usuario.Id);
            Preferences.Set("usuario_rol_nombre", usuario.Rol.Nombre);
        }

        public async Task CerrarSesion()
        {
            Preferences.Remove("usuario_logueado");
            Preferences.Remove("usuario_id");
            Preferences.Remove("usuario_rol_nombre");

            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}