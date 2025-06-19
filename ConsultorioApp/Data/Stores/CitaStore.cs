using System.Threading.Tasks;
using ConsultorioApp.Models;
using SQLite;

namespace ConsultorioApp.Database
{
    public class CitaStore : BaseStore<Cita>, ICitaStore
    {
        public CitaStore(SQLiteAsyncConnection connection) : base(connection)
        {
        }
        
    }
}