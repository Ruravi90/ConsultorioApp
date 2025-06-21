using System.IO;
using ConsultorioApp.Models;
using ConsultorioApp.Services;
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
        public IConsultaStore Consultas { get; }

        public AppDatabase(SQLiteAsyncConnection connection)
        {
            _connection = connection;
            
            // Inicializa los stores con la conexión compartida
            Usuarios = new UsuarioStore(connection);
            Roles = new RolStore(connection);
            Citas = new CitaStore(connection);
            Pacientes = new PacienteStore(connection);
            Consultas = new ConsultaStore(connection);
        }
    }
}