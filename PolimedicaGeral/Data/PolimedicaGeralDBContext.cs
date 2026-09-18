using Microsoft.EntityFrameworkCore;
using PolimedicaGeral.Models;

namespace PolimedicaGeral.Data
{
    public class PolimedicaGeralDBContext : DbContext
    {
        public PolimedicaGeralDBContext(DbContextOptions<PolimedicaGeralDBContext> options)
            : base(options) { }

        public DbSet<Roteiro> Roteiros { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        // Define your DbSets here, for example:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
