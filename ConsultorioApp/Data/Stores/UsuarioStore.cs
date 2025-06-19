using System.Threading.Tasks;
using ConsultorioApp.Models;
using SQLite;

namespace ConsultorioApp.Database
{
    public class UsuarioStore : BaseStore<Usuario>, IUsuarioStore
    {
        public UsuarioStore(SQLiteAsyncConnection connection) : base(connection)
        {
        }

        public async Task<Usuario> GetPorNombreUsuario(string nombreUsuario)
        {
            var user = await Connection.Table<Usuario>()
                .Where(u => u.NombreUsuario.Contains(nombreUsuario))
                .FirstOrDefaultAsync();
            var rol = await Connection.Table<Rol>().Where(r=> r.Id == user.RolId).FirstAsync();
            user.Rol = rol;
            return user;
        }
        
    }
}