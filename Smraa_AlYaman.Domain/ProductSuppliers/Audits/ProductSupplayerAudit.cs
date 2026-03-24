using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Domain.ProductSuppliers.Audits
{
    public class ProductSupplayerAudit : IAudit<ProductSupplayerEntityId>
    {


        public Guid AuditId { get; private set; } = Guid.NewGuid();


        public ProductSupplayerEntityId EntityId { get; private set; }
        public bool IsDeleted { get; private set; }



        public DateTime From { get; private set; }

        public DateTime ChangedAt { get; private set; }

        public bool IsRecovered { get; private set; } = false;

        private ProductSupplayerAudit()
        {
        }
        public void MarkAsRecoverd()
        {
            if (IsRecovered) throw DomainException.AlreadyRecoveredAudit;
            IsRecovered = true;
        }

    }
}
