using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(tb => tb.HasTrigger("ProductAudit"));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.EnglishName)
                   .HasMaxLength(200);



            builder.Property(p => p.TransactionType)
                    .HasConversion<string>()
                    .HasMaxLength(30)
                    .IsRequired();

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


            builder.Property(p => p.CreatedAt)
                   .IsRequired();

            builder.Property(p => p.LastUpdate)
                   .IsRequired(false);







        }
    }
}
