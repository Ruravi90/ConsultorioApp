using SQLite;

namespace ConsultorioApp.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string NombreUsuario { get; set; } // Puede ser email
        public string Contraseña { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        [Ignore] public Rol Rol { get; set; }
        // Propiedad para mostrar el rol
        [Ignore] public string RolNombre { get; set; }
        public int RolId { get; set; }
    }
}