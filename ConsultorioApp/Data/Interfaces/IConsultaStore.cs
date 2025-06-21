using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Models;

namespace ConsultorioApp.Database
{
    public interface IConsultaStore
    {
        Task<List<Consulta>> GetAllPorPaciente(int pacienteId);
        Task<List<Consulta>> GetAllAsync();
        Task<Consulta> GetByIdAsync(int id);
        Task<int> AddAsync(Consulta item);
        Task<int> UpdateAsync(Consulta item);
        Task<int> DeleteAsync(Consulta item);
        Task<bool> AnyAsync();
        Task<bool> AnyAsync(Func<Consulta, bool> predicate);
    }
}