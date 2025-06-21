using System;
using SQLite;

namespace ConsultorioApp.Models
{
    public class Consulta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int PacienteId { get; set; }
        public string Motivo { get; set; } // Motivo de la consulta
        public string Sintomas { get; set; }
        public string DiagnosticoPreliminar { get; set; }
        public string Observaciones { get; set; }

        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public bool Activa { get; set; } = true;
    }
}