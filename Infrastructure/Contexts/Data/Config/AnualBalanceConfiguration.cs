using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Infrastructure.Contexts.Data.Config
{
    public class AnualBalanceConfiguration : IEntityTypeConfiguration<AnualBalance>
    {
        public void Configure(EntityTypeBuilder<AnualBalance> builder)
        {
            builder.Property(a => a.Year).IsRequired();
            builder.HasMany(a => a.Balances).WithOne();
            builder.HasMany(a => a.Savings).WithOne();
            builder.HasMany(a => a.Vehicles).WithOne();
        }
    }
}
