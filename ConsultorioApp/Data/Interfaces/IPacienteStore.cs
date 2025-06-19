using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Models;

namespace ConsultorioApp.Database
{
    public interface IPacienteStore
    {
        Task<List<Paciente>> GetAllAsync();
        Task<Paciente> GetByIdAsync(int id);
        Task<int> AddAsync(Paciente item);
        Task<int> UpdateAsync(Paciente item);
        Task<int> DeleteAsync(Paciente item);
        Task<bool> AnyAsync();
        Task<bool> AnyAsync(Func<Paciente, bool> predicate);
    }
}