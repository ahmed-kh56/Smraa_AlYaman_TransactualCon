using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.Products;
using Smraa_AlYaman.Domain.ProductSuppliers.Audits;
using Smraa_AlYaman.Domain.Suppliers;
using System.Text.Json.Serialization;

namespace Smraa_AlYaman.Domain.ProductSuppliers
{
    public class ProductSupplayer
    {
        public int ProductId { get; private set; }
        public int SupplayerId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        [JsonIgnore]
        public Product Product { get; private set; }
        [JsonIgnore]

        public Supplayer Supplayer { get; private set; }

        private ProductSupplayer()
        {
        }

        public ProductSupplayer(int productId, int supplierId)
        {
            ProductId = productId;
            SupplayerId = supplierId;
            IsDeleted = false;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsDeleted()
        {
            if (IsDeleted) throw DomainException.AlreadyDeletedEntity;
            IsDeleted = true;
        }


        public void RecoverDeletedProductSupplayer(ProductSupplayerAudit audit)
        {

            ProductId = audit.EntityId.ProductId;
            SupplayerId = audit.EntityId.SupplayerId;
            IsDeleted = audit.IsDeleted;
            CreatedAt = DateTime.UtcNow;
            audit.MarkAsRecoverd();
        }

        public void Recover()
        {
            IsDeleted = false;
            CreatedAt = DateTime.UtcNow;
        }
    }

}
