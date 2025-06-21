using System.Linq;
using System.Threading.Tasks;
using ConsultorioApp.Database;
using ConsultorioApp.Models;
using Microsoft.EntityFrameworkCore;
using SQLite;

namespace ConsultorioApp.Helpers;

public static class DatabaseHelper
{
    private static AppDatabase _appDatabase;

    public static async Task InicializarAsync(string dbPath)
    {
        var connection = new SQLiteAsyncConnection(dbPath);
        // Inicializa AppDatabase con esa conexión
        var dbContext = new AppDatabase(connection);
        
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
                NombreUsuario = "admin",
                Contraseña = BCrypt.Net.BCrypt.HashPassword("Ruravi90"),
                NombreCompleto = "Ruravi Aguilar",
                RolId = 1,
                Telefono = "1234567890"
            };

            dbContext.Usuarios.AddAsync(admin);
        }
        
    }
}