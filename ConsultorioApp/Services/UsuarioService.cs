using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultorioApp.Database;
using ConsultorioApp.Interfaces;
using ConsultorioApp.Models;
using ConsultorioApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Storage;

namespace ConsultorioApp.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDatabase _context;

        public UsuarioService(AppDatabase context) => _context = context;

        public async Task<bool> ValidarUsuario(string nombreUsuario, string contraseña)
        {
            var user = await _context.Usuarios.GetPorNombreUsuario(nombreUsuario);
        
            if(BCrypt.Net.BCrypt.Verify(contraseña, user.Contraseña))
                return true;

            return  false; 
        }

        public async Task<bool> ExisteUsuario(string nombreUsuario)
        {
            return await _context.Usuarios.AnyAsync(u => u.NombreUsuario == nombreUsuario);
        }

        public async Task RegistrarUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }
        public async Task<bool> UsuarioAutenticadoAsync()
        {
            // Aquí puedes hacer una validación simple, como ver si existe algún usuario logueado
            // O usar un almacenamiento local (ej. Preferences) para saber si se ha iniciado sesión
    
            return Preferences.Get("usuario_logueado", false);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.GetAllAsync();
        }

        public async Task<Usuario> GetUsuarioPorUsuario(string usuario)
        {
            return await _context.Usuarios.GetPorNombreUsuario(usuario);
        }

        public async Task<Usuario> GetByIdAsync(int Id)
        {
            return await _context.Usuarios.GetByIdAsync(Id);
        }
    }
}