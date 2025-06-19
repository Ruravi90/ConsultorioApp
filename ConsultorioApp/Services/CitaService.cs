using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Database;
using ConsultorioApp.Interfaces;
using ConsultorioApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.Services
{
    public class CitaService : ICitaService
    {
        private readonly AppDatabase _context;

        public CitaService(AppDatabase context) => _context = context;

        public async Task<List<Cita>> GetAllAsync() => await _context.Citas.GetAllAsync();

        public async Task<Cita> GetByIdAsync(int id) => await _context.Citas.GetByIdAsync(id);

        public async Task AddAsync(Cita cita)
        {
            await _context.Citas.AddAsync(cita);
        }

        public async Task UpdateAsync(Cita cita)
        {
            await _context.Citas.UpdateAsync(cita);
        }

        public async Task DeleteAsync(int id)
        {
            var rol = await _context.Roles.GetByIdAsync(id);
            if (rol != null)
            {
                await _context.Roles.DeleteAsync(rol);
            }
        }
    }
}