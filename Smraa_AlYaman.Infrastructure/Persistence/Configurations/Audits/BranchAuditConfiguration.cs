using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.Branchs.Audits;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Audits
{
    public class BranchAuditConfiguration : IEntityTypeConfiguration<BranchAudit>
    {
        public void Configure(EntityTypeBuilder<BranchAudit> builder)
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



            builder.Property(b => b.BranchName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(b => b.BranchAddress)
                   .HasMaxLength(250);

            builder.Property(b => b.BranchPhone)
                   .HasMaxLength(20);
        }
    }
}
