using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Database;
using ConsultorioApp.Interfaces;
using ConsultorioApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.Services
{
    public class RolService : IRolService
    {
        private readonly AppDatabase _context;

        public RolService(AppDatabase context) => _context = context;

        public async Task<List<Rol>> GetAllAsync() => await _context.Roles.GetAllAsync();

        public async Task<Rol> GetRolByIdAsync(int id) => await _context.Roles.GetByIdAsync(id);

        public async Task AddAsync(Rol rol)
        {
            await _context.Roles.AddAsync(rol);
        }

        public async Task UpdateAsync(Rol rol)
        {
            await _context.Roles.UpdateAsync(rol);
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