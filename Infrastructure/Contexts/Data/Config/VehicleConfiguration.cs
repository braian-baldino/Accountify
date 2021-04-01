using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Infrastructure.Contexts.Data.Config
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(v => v.Brand).IsRequired();
            builder.Property(v => v.Model).IsRequired();
            builder.Property(v => v.Patent).IsRequired();
            builder.Property(v => v.ModelYear).IsRequired();
        }
    }
}
