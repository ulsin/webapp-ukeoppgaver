using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace webapp_ukeoppgaver.Models
{
    public class HolbergDb : DbContext
    {
        public HolbergDb(DbContextOptions<HolbergDb> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        // Tror det er her man liksom setter tables. Vet ikke hvordan man linker de tho
        public DbSet<Bestilling> Bestillinger { get; set; }
        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Pizza> Pizzaer { get; set; }
    }
}