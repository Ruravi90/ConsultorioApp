using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Models;

namespace ConsultorioApp.Services
{
    public interface IPacienteStore
    {
        Task<List<Paciente>> GetAllAsync();
        Task<Paciente> GetByIdAsync(int id);
        Task<int> AddAsync(Paciente paciente);
        Task<int> UpdateAsync(Paciente paciente);
        Task<int> DeleteAsync(Paciente paciente);
    }
}