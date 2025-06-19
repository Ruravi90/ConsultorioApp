using System;
using SQLite;

namespace ConsultorioApp.Models;

public class Paciente
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public DateTime FechaNacimiento { get; set; }
}