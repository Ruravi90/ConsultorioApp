using System.IO;
using ConsultorioApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Storage;

namespace ConsultorioApp.Data;

public class AppDbContext: DbContext
{
    private const string DB_NAME = "consultorio.daB3";
    public DbSet<Usuario> Usuarios { get; set;}
    public DbSet<Paciente> Pacientes { get; set;}
    public DbSet<Cita> Citas { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string conexionDB = $"Filename={Path.Combine(FileSystem.AppDataDirectory,DB_NAME)}";
        optionsBuilder.UseSqlite(conexionDB);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(col => col.Id);
            entity.Property(col => col.Id).IsRequired().ValueGeneratedOnAdd();
        });
        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(col => col.Id);
            entity.Property(col => col.Id).IsRequired().ValueGeneratedOnAdd();
        });
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(col => col.Id);
            entity.Property(col => col.Id).IsRequired().ValueGeneratedOnAdd();
        });
    }
}