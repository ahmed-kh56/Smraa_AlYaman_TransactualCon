using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smraa_AlYaman.Domain.OrderItems;

namespace Smraa_AlYaman.Infrastructure.Persistence.Configurations.Orders
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(oi => oi.Id);
            builder.Property(oi => oi.Barcode)
                   .IsRequired()
                   .HasMaxLength(128);
            builder.Property(oi => oi.OrderId)
                   .IsRequired();
            builder.Property(oi=>oi.Quantity)
                   .IsRequired();
            builder.Property(oi => oi.Discount)
                   .IsRequired();
            builder.Ignore(oi => oi.PriceBeforeDiscount);
            builder.Ignore(oi => oi.TotalPrice);


        }
    }
}
