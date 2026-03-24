using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.OrderItems;

namespace Smraa_AlYaman.Domain.Orderes
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid? CustomerId { get; private set; }
        public DateTime? OrderDate { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdated { get; private set; }

        public List<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();
        private Order() { }

        public Order(Guid? customerId =null,DateTime? orderDate= null)
        {
            Id= Guid.NewGuid();
            CustomerId = customerId;
            OrderDate = orderDate;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
