using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Infrastructure.Contexts.Data.Config
{
    public class SpendingConfiguration : IEntityTypeConfiguration<Spending>
    {
        public void Configure(EntityTypeBuilder<Spending> builder)
        {
            builder.Property(i => i.BalanceId).IsRequired();
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.Category).IsRequired();
            builder.Property(i => i.Amount).IsRequired();
        }
    }
}
