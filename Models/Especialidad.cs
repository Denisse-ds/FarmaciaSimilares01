namespace FarmaciaSimilares01.Models
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }

    public class ServicioMedica
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public decimal Precio { get; set; }
        public int Duracion { get; set; }
        public bool RequiereCita { get; set; }
        public string Especialidad { get; set; } = "";
        public int EspecialidadId { get; set; }
    }
}
