namespace FarmaciaSimilares01.Data
{
    using FarmaciaSimilares01.Models;
    using Microsoft.EntityFrameworkCore;

    public class MedicamentosDbContext : DbContext
    {
        public MedicamentosDbContext(DbContextOptions<MedicamentosDbContext> options)
            : base(options) { }

        // Cada DbSet = una tabla en la base de datos
        public DbSet<Cliente> ClientesF { get; set; }
        public DbSet<Ticket> TicketsF { get; set; }
        public DbSet<DetalleTicket> DetalleTicketsF { get; set; }
    }

}
