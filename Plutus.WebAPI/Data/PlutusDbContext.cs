using Microsoft.EntityFrameworkCore;

namespace Plutus.WebAPI.Data
{
    public class PlutusDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public PlutusDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(Configuration.GetConnectionString("PlutusDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(PlutusDbContext).Assembly);
        }
    }
}
