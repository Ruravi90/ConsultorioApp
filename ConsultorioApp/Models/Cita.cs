using System;
using SQLite;

namespace ConsultorioApp.Models;

public class Cita
{
    [PrimaryKey]
    [AutoIncrement]
    public int Id { get; set; }
    public int PacienteId { get; set; }
    public Paciente Paciente { get; set; }
    public DateTime Fecha { get; set; }
    public string Motivo { get; set; }
}