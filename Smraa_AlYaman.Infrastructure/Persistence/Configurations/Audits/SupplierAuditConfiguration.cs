using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.Suppliers.Audits;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Audits
{
    public class SupplierAuditConfiguration : IEntityTypeConfiguration<SupplayerAudit>
    {
        public void Configure(EntityTypeBuilder<SupplayerAudit> builder)
        {
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






            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.ContactPhone)
                   .HasMaxLength(20);

            builder.Property(s => s.Scope)
                   .IsRequired();
            builder.Property(p => p.Scope)
                    .HasMaxLength(30);

        }
    }
}
