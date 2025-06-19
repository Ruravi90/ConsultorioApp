using System.Threading.Tasks;
using ConsultorioApp.Models;
using SQLite;

namespace ConsultorioApp.Database
{
    public class RolStore : BaseStore<Rol>, IRolStore
    {
        public RolStore(SQLiteAsyncConnection connection) : base(connection)
        {
        }
        
    }
}