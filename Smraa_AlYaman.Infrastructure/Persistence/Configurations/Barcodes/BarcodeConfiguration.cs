using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.Barcodes;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Pricing
{

    public class BarcodeConfiguration : IEntityTypeConfiguration<Barcode>
    {
        public void Configure(EntityTypeBuilder<Barcode> builder)
        {
            builder.ToTable(tb => tb.HasTrigger("barcodeaudit"));

            builder.HasKey(b => b.Code);
            builder.Property(b => b.Code)
                   .IsRequired()
                   .HasMaxLength(128);

            builder.Property(b => b.Unit)
                    .HasConversion<string>()
                    .HasMaxLength(30)
                    .IsRequired();

            builder.Property(b=> b.ProductId)
                    .IsRequired();

            builder.Property(b => b.Type)
                   .HasConversion<string>()
                   .IsRequired();
            builder.Property(b => b.Type)
                    .HasMaxLength(30);
            builder.Property(b=>b.Size)
                   .HasConversion<string?>()
                   .IsRequired(false)
                   .HasMaxLength(12);


            builder.Property(p => p.Notes)
                    .HasMaxLength(800);

            builder.Property(b => b.CreatedAt)
                   .IsRequired();

            builder.Property(b => b.LastUpdate)
                   .IsRequired(false);


        }
    }

}
