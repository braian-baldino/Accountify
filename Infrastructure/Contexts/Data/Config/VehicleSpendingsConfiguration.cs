using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Infrastructure.Contexts.Data.Config
{
    public class VehicleSpendingsConfiguration : IEntityTypeConfiguration<VehicleSpending>
    {
        public void Configure(EntityTypeBuilder<VehicleSpending> builder)
        {
            builder.Property(vs => vs.VehicleId).IsRequired();
            builder.Property(vs => vs.Amount).IsRequired();
            builder.Property(vs => vs.Category).IsRequired();
        }
    }
}
