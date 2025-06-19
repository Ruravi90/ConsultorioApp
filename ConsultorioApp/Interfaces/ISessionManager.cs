using System.Threading.Tasks;

namespace ConsultorioApp.Services
{
    public interface ISessionManager
    {
        bool EstaLogueado { get; }
        Task<bool> UsuarioAutenticadoAsync();
        Task CerrarSesion();
    }
}