using Smraa_AlYaman.Domain.Barcodes;
using Smraa_AlYaman.Domain.Orderes;

namespace Smraa_AlYaman.Domain.OrderItems
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        // order
        public Guid OrderId { get; private set; }
        public Order Order { get; private set; }
        // barcode code
        public string Barcode { get; private set; }
        public Barcode BarcodeNavigation { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }

        public decimal PriceBeforeDiscount => Quantity * UnitPrice;

        public decimal TotalPrice => Quantity * (UnitPrice-(UnitPrice*Discount));
        private OrderItem() { }
        public OrderItem(Guid orderId, string code, int quantity, decimal unitPrice,decimal discount)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            Barcode = code;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
        }
    }
}
