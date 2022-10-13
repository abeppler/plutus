using Microsoft.EntityFrameworkCore;

namespace Plutus.WebAPI.Data
{
    public class PlutusDbContext : DbContext
    {
        public PlutusDbContext(DbContextOptions<PlutusDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(PlutusDbContext).Assembly);
        }
    }
}
