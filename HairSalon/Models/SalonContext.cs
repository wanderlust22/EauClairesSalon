using Microsoft.EntityFrameworkCore;

namespace Salon.Models
{
    public class SalonContext : DbContext
    {
        public DbSet<Stylist> Stylist { get; set; }
        public DbSet<Client> Client { get; set; }
        public SalonContext(DbContextOptions options) : base(options) {}
    }
}