using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Domain.Branchs;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Domain.Availablty.Audits
{
    public class AvailabltyAudit : IAudit<AvailabltyEntityId>
    {


        public Guid AuditId { get; private set; } = Guid.NewGuid();

        public AvailabltyEntityId EntityId { get; set; }

        public DateTime From { get; private set; }

        public DateTime ChangedAt { get; private set; }= DateTime.UtcNow;

        public bool IsRecovered { get; private set; } = false;


        private AvailabltyAudit() { }

    }
    [Owned]
    public record AvailabltyEntityId
    {
        public int ProductId { get; set; }
        public int BranchId { get; set; }
    }
}
