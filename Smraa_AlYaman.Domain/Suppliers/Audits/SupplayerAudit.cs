using Smraa_AlYaman.Domain.Common;
using System.Runtime.InteropServices.Java;

namespace Smraa_AlYaman.Domain.Suppliers.Audits
{
    public class SupplayerAudit : IAudit<int>
    {
        public Guid AuditId { get; private set; } = Guid.NewGuid();

        public int EntityId { get; private set; }
        public string Name { get; private set; }
        public string ContactPhone { get; private set; }

        public string Scope { get; private set; }


        public DateTime From { get; private set; }

        public DateTime ChangedAt { get; private set; }

        public bool IsRecovered { get; private set; } = false;
        public bool IsDeleted { get; private set; }

        public void MarkAsRecovered()
        {
            if (IsRecovered) throw DomainException.AlreadyRecoveredAudit;
            IsRecovered = true;
        }
    }
}
