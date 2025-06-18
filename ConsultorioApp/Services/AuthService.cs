using ConsultorioApp.Data;
using ConsultorioApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.Services;

public class AuthService
{
    private readonly AppDbContext _db;

    public AuthService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Usuario> Login(string nombreUsuario, string contraseña)
    {
        var usuario = await _db.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        if (usuario != null && BCrypt.Net.BCrypt.Verify(contraseña, usuario.Contraseña)) return usuario;
        return null;
    }

    public async Task Registrar(string email, string password)
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(password);
        var usuario = new Usuario { NombreUsuario = email, Contraseña = hash };
        await _db.Usuarios.AddAsync(usuario);
        await _db.SaveChangesAsync();
    }
}