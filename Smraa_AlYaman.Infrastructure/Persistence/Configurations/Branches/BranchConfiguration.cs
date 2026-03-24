using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.Branchs;
using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Branches
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable(tb => tb.HasTrigger("BranchAudit"));

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.BranchName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(b => b.BranchAddress)
                   .HasMaxLength(250);

            builder.Property(b => b.BranchPhone)
                   .HasMaxLength(20);
            builder.Property(b => b.CreatedAt)
                   .IsRequired();
            builder.Property(b => b.LastUpdate)
                   .IsRequired(false);
        }
    }

}
