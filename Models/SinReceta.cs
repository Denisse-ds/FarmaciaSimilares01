namespace FarmaciaSimilares01.Models
{
    public class SinReceta
    {
        public int Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string laboratorio { get; set; } = string.Empty;
        public string presentacion { get; set; } = string.Empty;

        public decimal precio { get; set; }

        public string especialidad { get; set; } = string.Empty;
    }
}
