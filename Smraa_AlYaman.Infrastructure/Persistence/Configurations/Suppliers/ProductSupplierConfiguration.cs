using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.ProductSuppliers;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Suppliers
{
    public class ProductSupplierConfiguration : IEntityTypeConfiguration<ProductSupplayer>
    {
        public void Configure(EntityTypeBuilder<ProductSupplayer> builder)
        {
            builder.ToTable(tb => tb.HasTrigger("ProductSupplayerAudit"));
            builder.HasKey(ps => new { ps.ProductId, ps.SupplayerId });

            builder.Property(ps => ps.ProductId)
                   .IsRequired();
            builder.Property(ps => ps.SupplayerId)
                   .IsRequired();

            builder.Property(ps => ps.CreatedAt)
                   .IsRequired();




        }
    }
}
