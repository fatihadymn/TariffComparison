using TariffComparison.Items.Entities;
using Microsoft.EntityFrameworkCore;

namespace TariffComparison.Data
{
    public class ApplicationContext : DbContext
    {
        private readonly string schema = "tariff_comparison";

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(schema);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataIdentifier).Assembly);
        }

        public DbSet<Tariff> Tariffs { get; set; }
    }
}