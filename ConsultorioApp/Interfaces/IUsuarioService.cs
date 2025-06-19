using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Models;

namespace ConsultorioApp.Interfaces;

public interface IUsuarioService
{
    Task<bool> ValidarUsuario(string nombreUsuario, string contraseña);
    Task RegistrarUsuario(Usuario usuario);
    Task<bool> ExisteUsuario(string nombreUsuario);
    Task<bool> UsuarioAutenticadoAsync();
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario> GetUsuarioPorUsuario(string usuario);
    Task<Usuario> GetByIdAsync(int usuarioId);
}