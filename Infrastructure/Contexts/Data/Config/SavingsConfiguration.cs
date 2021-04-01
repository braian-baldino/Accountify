using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Infrastructure.Contexts.Data.Config
{
    public class SavingsConfiguration : IEntityTypeConfiguration<Savings>
    {
        public void Configure(EntityTypeBuilder<Savings> builder)
        {
            builder.Property(s => s.Amount).IsRequired();
            builder.Property(s => s.Type).IsRequired();
        }
    }
}
