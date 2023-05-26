using Microsoft.EntityFrameworkCore;

namespace PinkPanther.Database
{
    public class PinkPantherDbContex : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Type> Types { get; set; }

        public PinkPantherDbContex(DbContextOptions options) : base(options)
        {
            
        }
    }
}
