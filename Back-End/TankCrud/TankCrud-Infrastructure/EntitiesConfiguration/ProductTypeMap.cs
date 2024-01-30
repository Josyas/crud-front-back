using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankCrud.Models;

namespace TankCrud_Infrastructure.EntitiesConfiguration
{
    public class ProductTypeMap : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductType");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
               .HasColumnType($"VARCHAR({350})");
        }
    }
}
