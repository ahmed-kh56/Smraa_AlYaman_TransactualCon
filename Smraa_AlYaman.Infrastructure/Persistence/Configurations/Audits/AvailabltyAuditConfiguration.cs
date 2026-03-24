using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.Availablty.Audits;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Audits
{
    internal class AvailabltyAuditConfiguration
        : IEntityTypeConfiguration<AvailabltyAudit>
    {
        public void Configure(EntityTypeBuilder<AvailabltyAudit> builder)
        {
            builder.HasKey(p => p.AuditId);

            builder.Property(p => p.AuditId)
                   .ValueGeneratedNever();

            builder.Property(p => p.From)
                   .IsRequired();

            builder.Property(p => p.ChangedAt)
                   .IsRequired();



            builder.OwnsOne(p => p.EntityId)
                   .Property(p => p.ProductId)
                   .HasColumnName("ProductId")
                   .IsRequired();

            builder.OwnsOne(p => p.EntityId)
                   .Property(p => p.BranchId)
                   .HasColumnName("BranchId")
                   .IsRequired();
        }
    }
}
