using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Database;
using ConsultorioApp.Interfaces;
using ConsultorioApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly AppDatabase _context;

        public PacienteService(AppDatabase context) => _context = context;

        public async Task<List<Paciente>> GetAllAsync() => await _context.Pacientes.GetAllAsync();

        public async Task<Paciente> GetByIdAsync(int id) => await _context.Pacientes.GetByIdAsync(id);

        public async Task AddAsync(Paciente item)
        {
            await _context.Pacientes.AddAsync(item);
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            await _context.Pacientes.UpdateAsync(paciente);
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