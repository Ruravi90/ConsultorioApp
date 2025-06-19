using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Models;

namespace ConsultorioApp.Interfaces;

public interface ICitaService
{
    Task<List<Cita>> GetAllAsync();
    Task<Cita> GetByIdAsync(int id);
    Task AddAsync(Cita cita);
    Task UpdateAsync(Cita cita);
    Task DeleteAsync(int id);
}