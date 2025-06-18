using SQLite;

namespace ConsultorioApp.Models;

public class Usuario
{
    [PrimaryKey]
    [AutoIncrement]
    public int Id { get; set; }
    public string NombreUsuario { get; set; }
    public string Contraseña { get; set; }
}