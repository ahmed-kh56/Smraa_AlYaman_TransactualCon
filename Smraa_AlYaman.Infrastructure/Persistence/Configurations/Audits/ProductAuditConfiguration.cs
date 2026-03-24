using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.Products.Audits;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Audits
{
    public class ProductAuditConfiguration : IEntityTypeConfiguration<ProductAudit>
    {
        public void Configure(EntityTypeBuilder<ProductAudit> builder)
        {


            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.EnglishName)
                   .HasMaxLength(200);



            builder.Property(p => p.TransactionType)
                    .HasConversion<string>()
                    .HasMaxLength(30)
                    .IsRequired();
            builder.Property(p => p.TransactionType)
                    ;
            builder.Property(p => p.ReceiptType)
                    .HasConversion<string>()
                    .HasMaxLength(30)
                    .IsRequired();

            builder.Property(p => p.State)
                    .HasMaxLength(30)
                    .HasConversion<string>()
                    .IsRequired();

            builder.Property(p => p.IsAllowedOnline)
                        .IsRequired();
            builder.Property(p => p.CatagoryId)
                        .IsRequired();
            builder.Property(p => p.BrandId)
                        .IsRequired();
            builder.Property(p => p.ProductGroupId)
                        .IsRequired();
            builder.Property(p => p.CountryOfOriginId)
                        .IsRequired();
            builder.Property(p => p.MainTax)
                        .HasMaxLength(100)
                        .IsRequired(false);
            builder.Property(p => p.SubTax)
                        .HasMaxLength(100)
                        .IsRequired(false);
            builder.Property(p => p.TotalTaxAmount)
                        .IsRequired(false);


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
