using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Domain.ProductPrices.Audits
{
    public class ProductPriceAudit : IAudit<int>
    {
        public Guid AuditId { get; private set; }
        public int EntityId { get; private set; }

        public decimal PricePerSmallistUnit { get; private set; }
        public decimal WholesalePricePerSmallistUnit { get; private set; }
        public decimal LowestPricePerSmallistUnit { get; private set; }
        public decimal SmallistUnitCost { get; private set; }
        public int ProductPriceUnits { get; private set; }
        public string TransactionsSammary { get; private set; }
        public string Notes { get; private set; }
        public bool IsWaghted { get; private set; }
        public bool IsNotSellable { get; private set; }

        public DateTime From { get; private set; }
        public DateTime ChangedAt { get; private set; }
        public bool IsRecovered { get; private set; }


        public void MarkAsRecovered()
        {
            if (IsRecovered) throw DomainException.AlreadyRecoveredAudit;
            IsRecovered = true;
        }

        private ProductPriceAudit() { }




    }
}
