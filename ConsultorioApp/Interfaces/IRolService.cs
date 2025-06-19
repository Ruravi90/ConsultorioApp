using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Models;

namespace ConsultorioApp.Interfaces;

public interface IRolService
{
    Task<List<Rol>> GetAllAsync();
    Task<Rol> GetRolByIdAsync(int id);
    Task AddAsync(Rol rol);
    Task UpdateAsync(Rol rol);
    Task DeleteAsync(int id);
}