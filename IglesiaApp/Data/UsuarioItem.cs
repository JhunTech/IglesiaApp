using SQLite;

namespace IglesiaApp
{
    public class UsuarioItem
    {
        [PrimaryKey]
        public string Email { get; set; } 
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public string Tipo { get; set; } 
    }
}
