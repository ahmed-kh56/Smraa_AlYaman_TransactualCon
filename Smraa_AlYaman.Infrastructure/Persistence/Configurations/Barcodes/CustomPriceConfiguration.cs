using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.CustomPrices;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Barcodes
{
    public class CustomPriceConfiguration : IEntityTypeConfiguration<CustomPrice>
    {
        public void Configure(EntityTypeBuilder<CustomPrice> builder)
        {

            builder.ToTable(tb => tb.HasTrigger("SupplayerAudit"));
            builder.HasKey(pb => new {pb.BranchId,pb.Code });

            builder.Property(pb => pb.BranchId)
                .IsRequired();
            builder.Property(pb => pb.Code)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.LowestPriceForSale)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.HasOne(c => c.Barcode)
                .WithMany(b => b.Prices)
                .HasForeignKey(c => c.Code);



        }
    }
}
