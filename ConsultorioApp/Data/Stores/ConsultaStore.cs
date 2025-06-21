using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Models;
using SQLite;

namespace ConsultorioApp.Database
{
    public class ConsultaStore : BaseStore<Consulta>, IConsultaStore
    {
        public ConsultaStore(SQLiteAsyncConnection connection) : base(connection)
        {
        }
        
        public async Task<List<Consulta>> GetAllPorPaciente(int pacienteId)
        {
            var consultas = await Connection.Table<Consulta>()
                .Where(u => u.PacienteId == pacienteId)
                .ToListAsync();
  
            return consultas;
        }
        
    }
}