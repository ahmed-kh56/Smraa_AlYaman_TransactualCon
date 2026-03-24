using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.Orderes;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Orders
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(o => o.CustomerId).IsRequired(false);
            builder.Property(o=>o.OrderDate).IsRequired(false);
            builder.Property(o => o.CreatedAt).IsRequired();
            builder.Property(o => o.LastUpdated).IsRequired(false);
        }
    }
}
