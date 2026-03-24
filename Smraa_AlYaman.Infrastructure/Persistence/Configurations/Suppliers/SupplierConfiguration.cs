using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.Suppliers;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Suppliers
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplayer>
    {
        public void Configure(EntityTypeBuilder<Supplayer> builder)
        {
            builder.ToTable(tb => tb.HasTrigger("SupplayerAudit"));

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.ContactPhone)
                   .HasMaxLength(20);

            builder.Property(s => s.Scope)
                   .HasConversion<string>()
                   .IsRequired();
            builder.Property(p => p.Scope)
                    .HasMaxLength(30);

            builder.Property(s => s.CreatedAt)
                   .IsRequired();

            builder.Property(s => s.LastUpdate)
                   .IsRequired(false);

        }
    }
}
