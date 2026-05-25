namespace FarmaciaSimilares01.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = "";

        public string Telefono { get; set; } = "";

        public string Email { get; set; } = "";

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Un cliente puede tener muchos tickets
        public List<Ticket> Tickets { get; set; } = new();
    }

    public class Ticket
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public decimal Total { get; set; }

        public string Estado { get; set; } = "";

        // Relación con Cliente
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        // Un ticket tiene muchos detalles (productos)
        public List<DetalleTicket> Detalles { get; set; } = new();
    }

    public class DetalleTicket
    {
        public int Id { get; set; }

        public int ProductoApiId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        // Relación con el Ticket padre
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
