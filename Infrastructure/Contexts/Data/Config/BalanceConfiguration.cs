using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Infrastructure.Contexts.Data.Config
{
    public class BalanceConfiguration : IEntityTypeConfiguration<Balance>
    {
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.Property(b => b.AnualBalanceId).IsRequired();
            builder.Property(b => b.Month).IsRequired();
            builder.HasMany(b => b.Incomes).WithOne();
            builder.HasMany(b => b.Spendings).WithOne();
        }
    }
}
