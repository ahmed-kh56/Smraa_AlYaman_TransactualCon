using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Domain.CustomPrices.Audits
{
    public class CustomPriceAudit:IAudit<CustomPriceId>
    {

        public Guid AuditId { get; private set; } = Guid.NewGuid();


        public decimal Price { get; private set; }
        public decimal? LowestPriceForSale { get; private set; }
        public bool IsDeleted { get; private set; }

        public DateTime From { get; private set; }

        public DateTime ChangedAt { get; private set; }

        public bool IsRecovered { get; private set; } = false;

        public CustomPriceId EntityId { get; private set; }



        private CustomPriceAudit()
        {
        }



        public void MarkAsRecoverd()
        {
            if (IsRecovered == true)
                throw DomainException.AlreadyDeletedEntity;
            IsRecovered = true;

        }

    }
    [Owned]
    public record CustomPriceId
    {
        public int BranchId { get; set; }
        public string Barcode { get; set; }
    }
}
