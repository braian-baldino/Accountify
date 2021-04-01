using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Infrastructure.Contexts.Data.Config
{
    public class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.Property(i => i.BalanceId).IsRequired();
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.Category).IsRequired();
            builder.Property(i => i.Amount).IsRequired();
        }
    }
}
