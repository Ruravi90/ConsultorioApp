using System;
using SQLite;

namespace ConsultorioApp.Models
{
    public class Paciente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string NombreCompleto { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string HistorialClinico { get; set; }
    }
}