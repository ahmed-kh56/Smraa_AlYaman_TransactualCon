using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.Availablty;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Availability
{
    public class ProductBranchesAvailabilityConfiguration : IEntityTypeConfiguration<ProductBranchesAvailability>
    {
        public void Configure(EntityTypeBuilder<ProductBranchesAvailability> builder)
        {
            builder.ToTable(tb => tb.HasTrigger("tr_AvailabltyAudit"));

            builder.HasKey(pba => new { pba.ProductId, pba.BrancheId });
            builder.Property(pba => pba.ProductId)
                    .IsRequired();
            builder.Property(pba => pba.BrancheId)
                    .IsRequired();
            builder.Property(pba => pba.CreatedAt)
                    .IsRequired();

        }
    }
}
