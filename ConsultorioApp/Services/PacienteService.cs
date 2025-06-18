using ConsultorioApp.Data;
using ConsultorioApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.Services;

public class PacienteService
{
    private readonly AppDbContext _db;

    public PacienteService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Paciente>> GetAll()
    {
        return await _db.Pacientes.ToListAsync();
    }

    public async Task Add(Paciente paciente)
    {
        await _db.Pacientes.AddAsync(paciente);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Paciente paciente)
    {
        _db.Pacientes.Update(paciente);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var paciente = await _db.Pacientes.FindAsync(id);
        if (paciente != null)
        {
            _db.Pacientes.Remove(paciente);
            await _db.SaveChangesAsync();
        }
    }
}