namespace FarmaciaSimilares01.Models
{
    public class ProductoTodos
    {
        public int Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string laboratorio { get; set; } = string.Empty;
        public string presentacion { get; set; } = string.Empty;

        public decimal precio { get; set; }

        public bool requierereceta { get; set; } = false;

        public string especialidad { get; set; } = string.Empty;

        public int  especialidadId { get; set; }
    }
}
