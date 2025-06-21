using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Models;

namespace ConsultorioApp.Database
{
    public interface ICitaStore
    {
        Task<List<Cita>> GetAllAsync();
        Task<Cita> GetByIdAsync(int id);
        Task<int> AddAsync(Cita item);
        Task<int> UpdateAsync(Cita item);
        Task<int> DeleteAsync(Cita item);
        Task<bool> AnyAsync();
        Task<bool> AnyAsync(Func<Cita, bool> predicate);
    }
}