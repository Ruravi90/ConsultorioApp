using ConsultorioApp.Data;
using ConsultorioApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.Services;

public class CitaService
{
    private readonly AppDbContext _db;

    public CitaService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Cita>> GetAll()
    {
        return await _db.Citas.Include(c => c.Paciente).ToListAsync();
    }

    public async Task Add(Cita cita)
    {
        await _db.Citas.AddAsync(cita);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Cita cita)
    {
        _db.Citas.Update(cita);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var cita = await _db.Citas.FindAsync(id);
        if (cita != null)
        {
            _db.Citas.Remove(cita);
            await _db.SaveChangesAsync();
        }
    }
}