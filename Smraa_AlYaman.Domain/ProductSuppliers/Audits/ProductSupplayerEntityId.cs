using Microsoft.EntityFrameworkCore;

namespace Smraa_AlYaman.Domain.ProductSuppliers.Audits
{
    [Owned]
    public record ProductSupplayerEntityId
    {
        public int ProductId { get ; set; }
        public int SupplayerId { get ; set; }
    }
}
