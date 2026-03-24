using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.ProductPrices.Audits;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Audits
{
    public class ProductPriceAuditConfiguration : IEntityTypeConfiguration<ProductPriceAudit>
    {
        public void Configure(EntityTypeBuilder<ProductPriceAudit> builder)
        {

            builder.Property(p => p.EntityId).IsRequired();

            builder.Property(x => x.PricePerSmallistUnit)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.WholesalePricePerSmallistUnit)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.LowestPricePerSmallistUnit)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.SmallistUnitCost)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ProductPriceUnits)
                   .IsRequired()
                   .HasConversion<int>();

            builder.Property(x => x.TransactionsSammary)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.Notes)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.IsWaghted)
                   .IsRequired();

            builder.Property(x => x.IsNotSellable)
                   .IsRequired();








            builder.Property(p => p.AuditId)
                    .ValueGeneratedNever();
            builder.HasKey(p => p.AuditId);
            builder.Property(p => p.EntityId)
                    .IsRequired();

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
