using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Domain.CustomPrices.Audits;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Audits
{
    internal class CustomPriceAuditConfiguration : IEntityTypeConfiguration<CustomPriceAudit>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CustomPriceAudit> builder)
        {

            builder.OwnsOne(p => p.EntityId)
                   .Property(p => p.Barcode)
                   .HasColumnName("Barcode")
                   .IsRequired();

            builder.OwnsOne(p => p.EntityId)
                   .Property(p => p.BranchId)
                   .HasColumnName("BranchId")
                   .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.LowestPriceForSale)
                .HasColumnType("decimal(18,2)")
                .IsRequired();



            builder.Property(p => p.AuditId)
                    .ValueGeneratedNever();
            builder.HasKey(p => p.AuditId);


            builder.Property(p => p.From)
                    .IsRequired();
            builder.Property(p => p.ChangedAt)
                    .IsRequired();


            builder.Property(p => p.IsRecovered)
                    .IsRequired()
                    .HasDefaultValue(false);




        }
    }
}
