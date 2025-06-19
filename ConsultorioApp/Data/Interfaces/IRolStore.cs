using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Models;

namespace ConsultorioApp.Database
{
    public interface IRolStore
    {
        Task<List<Rol>> GetAllAsync();
        Task<Rol> GetByIdAsync(int id);
        Task<int> AddAsync(Rol item);
        Task<int> UpdateAsync(Rol item);
        Task<int> DeleteAsync(Rol item);
        Task<bool> AnyAsync();
        Task<bool> AnyAsync(Func<Rol, bool> predicate);
    }
}