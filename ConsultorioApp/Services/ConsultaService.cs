using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Database;
using ConsultorioApp.Models;

namespace ConsultorioApp.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly AppDatabase _context;

        public ConsultaService(AppDatabase context) => _context = context;

        public async Task<List<Consulta>> GetAllPorPaciente(int pacienteId)
        {
            return await _context.Consultas.GetAllPorPaciente(pacienteId);
        }

        public async Task<int> AddAsync(Consulta consulta)
        {
            return await _context.Consultas.AddAsync(consulta);
        }

        public async Task<int> UpdateAsync(Consulta consulta)
        {
            return await _context.Consultas.UpdateAsync(consulta);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var consulta = await _context.Consultas.GetByIdAsync(id);
            if (consulta != null)
                return await _context.Consultas.DeleteAsync(consulta);

            return -1;
        }
    }
}