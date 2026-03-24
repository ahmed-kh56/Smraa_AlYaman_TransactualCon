using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.ProductPrices;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.ProductPrices
{
    internal class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
    {
        public void Configure(EntityTypeBuilder<ProductPrice> builder)
        {
            builder.ToTable(tb => tb.HasTrigger("PriceAudit"));

            // Primary Key
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

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

            builder.Property(x => x.CreatedAt)
                   .IsRequired();

            builder.Property(x => x.LastUpdate)
                   .IsRequired(false);
            builder.HasOne(pc => pc.Product)
                   .WithOne(p => p.ProductPrice)
                   .HasForeignKey<ProductPrice>(pc => pc.Id)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }

}
