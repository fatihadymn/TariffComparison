using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TariffComparison.Items.Entities;

namespace TariffComparison.Data.Configurations
{
    public class TarifConfiguration : IEntityTypeConfiguration<Tariff>
    {
        public void Configure(EntityTypeBuilder<Tariff> builder)
        {
            builder.ToTable("tariffs");

            builder.Property(x => x.Id)
                   .HasColumnType("uuid")
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(x => x.CreatedOn)
                   .HasColumnName("created_on")
                   .HasColumnType("timestamp")
                   .IsRequired();

            builder.Property(x => x.UpdatedOn)
                   .HasColumnName("updated_on")
                   .HasColumnType("timestamp")
                   .IsRequired();

            builder.Property(x => x.IsActive)
                   .HasColumnName("is_active")
                   .HasColumnType("boolean")
                   .IsRequired();

            builder.Property(x => x.Name)
                   .HasColumnName("name")
                   .IsRequired();

            builder.Property(x => x.BaseCost)
                   .HasColumnName("base_cost")
                   .HasColumnType("money")
                   .IsRequired();

            builder.Property(x => x.ExtraCost)
                   .HasColumnName("extra_cost")
                   .HasColumnType("money")
                   .IsRequired();

            builder.Property(x => x.BaseLimit)
                   .HasColumnName("base_limit")
                   .HasColumnType("money")
                   .IsRequired(false);
        }
    }
}
