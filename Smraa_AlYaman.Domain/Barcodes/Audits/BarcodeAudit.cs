using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Domain.Barcodes.Audits
{
    public class BarcodeAudit : IAudit<string>
    {
        public Guid AuditId { get; private set; }


        public string EntityId { get; private set; }
        public string Notes { get; private set; }

        public string Type { get; private set; }
        public string? Size { get; private set; }
        public string Unit { get; private set; }
        public decimal UnitsCountPerPackage { get; private set; }

        public int ProductId { get; private set; }

        public bool IsActive { get; private set; }
        public bool IsAllowedOnline { get; private set; }


        public DateTime From { get; private set; }
        public DateTime ChangedAt { get; private set; }
        public bool IsRecovered {  get; private set; }
        private BarcodeAudit()
        {
        }


        public void MarkAsRecoverd()
        {
            if ( IsRecovered == true )
                throw DomainException.AlreadyRecoveredAudit;
            IsRecovered = true;

        }
    }
}
