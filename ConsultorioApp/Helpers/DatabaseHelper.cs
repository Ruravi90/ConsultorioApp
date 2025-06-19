using System.Linq;
using ConsultorioApp.Database;
using ConsultorioApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.Helpers;

public static class DatabaseHelper
{
    public async static void  InicializarAsync(AppDatabase dbContext)
    {
        //Agrega un usuario por defecto si no hay ninguno
        var roles = await  dbContext.Roles.AnyAsync();
        if (!roles)
        {
            dbContext.Roles.AddAsync(new Rol { Nombre = "Admin" });
            dbContext.Roles.AddAsync(new Rol { Nombre = "Médico" });
            dbContext.Roles.AddAsync(new Rol { Nombre = "Paciente" });
        }

        // Agrega un usuario por defecto si no hay ninguno
        var usuarios = await  dbContext.Usuarios.AnyAsync();
        if (!usuarios)
        {
            var admin = new Usuario
            {
                NombreUsuario = "ruravi@icloud.com",
                Contraseña = BCrypt.Net.BCrypt.HashPassword("Ruravi90"),
                NombreCompleto = "Admin",
                RolId = 1,
                Telefono = "1234567890"
            };

            dbContext.Usuarios.AddAsync(admin);
        }
        
    }
}