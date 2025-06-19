using SQLite;

namespace ConsultorioApp.Models
{
    public class Rol
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}