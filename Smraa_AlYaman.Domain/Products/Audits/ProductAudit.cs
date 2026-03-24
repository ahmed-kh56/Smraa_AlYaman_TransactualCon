using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Domain.Products.Audits
{
    public class ProductAudit : IAudit<int>
    {
        public Guid AuditId { get; private set; }
        public int EntityId { get; private set; }

        public string Name { get; private set; }
        public string EnglishName { get; private set; }

        public string State { get; private set; }
        public bool IsAllowedOnline { get; private set; }

        public string TransactionType { get; private set; }
        public string ReceiptType { get; private set; }

        public int CatagoryId { get; private set; }
        public int BrandId { get; private set; }
        public int ProductGroupId { get; private set; }
        public int CountryOfOriginId { get; private set; }

        public string? MainTax { get; private set; }
        public string? SubTax { get; private set; }
        public decimal? TotalTaxAmount { get; private set; }
        public bool IsDeleted { get; private set; }

        public DateTime From { get; private set; }
        public DateTime ChangedAt { get; private set; }
        public bool IsRecovered { get; private set; }

        public void MarkAsRecovered()
        {
            if (IsRecovered) throw DomainException.AlreadyRecoveredAudit;
            IsRecovered = true;
        }

        private ProductAudit() { }

    }



}
