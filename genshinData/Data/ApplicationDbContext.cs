using Microsoft.EntityFrameworkCore;
using genshinData.Models;

namespace genshinData.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
        }
        public DbSet<Region> Regiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
