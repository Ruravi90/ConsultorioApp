using System.IO;
using ConsultorioApp.Models;
using Microsoft.Maui.Storage;
using SQLite;

namespace ConsultorioApp.Database
{
    public class AppDatabase
    {
        private readonly SQLiteAsyncConnection _connection;

        public IUsuarioStore Usuarios { get; }
        public IRolStore Roles { get; }
        public ICitaStore Citas { get; }
        public IPacienteStore Pacientes { get; }
        

        public AppDatabase()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "consultorio.db");
            _connection = new SQLiteAsyncConnection(dbPath);

            // Inicializa las stores
            Usuarios = new UsuarioStore(_connection);
            Roles = new RolStore(_connection);
            Citas = new CitaStore(_connection);
            Pacientes = new PacienteStore(_connection);
        }
    }
}