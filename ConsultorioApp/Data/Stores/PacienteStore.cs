using System.Threading.Tasks;
using ConsultorioApp.Models;
using ConsultorioApp.Services;
using SQLite;

namespace ConsultorioApp.Database
{
    public class PacienteStore : BaseStore<Paciente>, IPacienteStore
    {
        public PacienteStore(SQLiteAsyncConnection connection) : base(connection)
        {
        }
        
    }
}