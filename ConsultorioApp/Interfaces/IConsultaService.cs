using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Models;

namespace ConsultorioApp.Services
{
    public interface IConsultaService
    {
        Task<List<Consulta>> GetAllPorPaciente(int pacienteId);
        Task<int> AddAsync(Consulta consulta);
        Task<int> UpdateAsync(Consulta consulta);
        Task<int> DeleteAsync(int id);
    }
}