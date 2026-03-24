using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Domain.Branchs.Audits
{
    public class BranchAudit : IAudit<int>
    {
        public Guid AuditId { get; private set; } = Guid.NewGuid();

        public int EntityId { get; private set; }

        public string BranchName { get; private set; }
        public string? BranchAddress { get; private set; }
        public string? BranchPhone { get; private set; }
        public bool IsDeleted { get; private set; }

        public DateTime From { get; private set; }

        public DateTime ChangedAt { get; private set; } = DateTime.UtcNow;

        public bool IsRecovered { get; private set; } = false;






        private BranchAudit() { }


    }
}
