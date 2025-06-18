using System.Linq;
using ConsultorioApp.Data;
using ConsultorioApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioApp.Helpers;

public static class DatabaseHelper
{
    public static void  InicializarAsync()
    {
        var dbContext = new AppDbContext();
        dbContext.Database.Migrate(); 

        // Agrega un usuario por defecto si no hay ninguno
        if (!dbContext.Usuarios.Any())
        {
            dbContext.Usuarios.Add(new Usuario
            {
                NombreUsuario = "admin@admin",
                Contraseña = "1234"
            });

            dbContext.SaveChangesAsync();
        }
    }
}