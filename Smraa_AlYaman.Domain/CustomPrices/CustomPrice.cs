using Smraa_AlYaman.Domain.Barcodes;
using Smraa_AlYaman.Domain.Branchs;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.CustomPrices.Audits;

namespace Smraa_AlYaman.Domain.CustomPrices
{
    public class CustomPrice
    {
        public string Code { get; private set; }
        public Barcode Barcode { get; private set; }

        public int BranchId { get; private set; }
        public Branch Branch { get; private set; }
        public decimal Price { get; private set; }
        public decimal? LowestPriceForSale { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public bool IsDeleted { get; private set; }

        private CustomPrice() { }


        public CustomPrice(string barcode, decimal price, int branchId, decimal? lowestPrice = null)
        {

            Code = barcode;
            BranchId = branchId;
            Price = price;
            LowestPriceForSale = lowestPrice ?? price;
            CreatedAt = DateTime.UtcNow;
            LastUpdate = null;
        }


        public void Update(decimal? price = null,decimal? lowistPrice =null)
        {
            if (price.HasValue)
                Price = price.Value;

            if(lowistPrice.HasValue)
                LowestPriceForSale = lowistPrice.Value;


            LastUpdate = DateTime.UtcNow;

        }
        public void MarkAsDeleted()
        {
            if (IsDeleted) throw DomainException.AlreadyDeletedEntity;
            IsDeleted = true;
            LastUpdate = DateTime.UtcNow;
        }


        public void RecoverSnapShot(CustomPriceAudit audit)
        {
            Price = audit.Price;
            LowestPriceForSale = audit.LowestPriceForSale;
            LastUpdate = DateTime.UtcNow;
            audit.MarkAsRecoverd();
        }

        public void Recover()
        {
            IsDeleted = false;
            CreatedAt = DateTime.UtcNow;
            LastUpdate = DateTime.UtcNow;
        }
    }
}
