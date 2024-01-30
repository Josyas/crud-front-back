using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankCrud.Models;

namespace TankCrud_Infrastructure.EntitiesConfiguration
{
    internal class TankMap : IEntityTypeConfiguration<Tank>
    {
        public void Configure(EntityTypeBuilder<Tank> builder)
        {
            builder.ToTable("Tank");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Deposit)
               .HasColumnType($"VARCHAR({350})");

            builder.Property(x => x.Capacity)
               .HasColumnType($"VARCHAR({350})");

            builder.HasOne(x => x.ProductType)
               .WithMany()
               .HasForeignKey(x => x.ProductTypeId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_ProductType_IdProductType");
        }
    }
}
