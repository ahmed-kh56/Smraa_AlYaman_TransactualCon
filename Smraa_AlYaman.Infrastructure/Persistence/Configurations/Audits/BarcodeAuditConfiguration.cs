using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.Barcodes.Audits;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Audits
{
    public class BarcodeAuditConfiguration : IEntityTypeConfiguration<BarcodeAudit>
    {
        public void Configure(EntityTypeBuilder<BarcodeAudit> builder)
        {




            builder.Property(b => b.EntityId)
                   .IsRequired()
                   .HasMaxLength(128);

            builder.Property(b => b.Unit)
                    .HasConversion<string>()
                    .HasMaxLength(30)
                    .IsRequired();

            builder.Property(b => b.ProductId)
                    .IsRequired();

            builder.Property(b => b.Size)
                   .HasConversion<string?>()
                   .IsRequired(false)
                   .HasMaxLength(12);


            builder.Property(p => p.Notes)
                    .HasMaxLength(800);




            builder.Property(p => p.AuditId)
                    .ValueGeneratedNever();
            builder.HasKey(p => p.AuditId);
            builder.Property(p => p.EntityId)
                    .IsRequired();

            builder.Property(p => p.From)
                    .IsRequired();
            builder.Property(p => p.ChangedAt)
                    .IsRequired();

            builder.Property(p=>p.IsRecovered)
                    .IsRequired()
                    .HasDefaultValue(false);
        }
    }
}
