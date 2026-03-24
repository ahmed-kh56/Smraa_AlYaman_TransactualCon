using Smraa_AlYaman.Domain.Barcodes.Audits;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.CustomPrices;
using Smraa_AlYaman.Domain.Products;
using System.Security.AccessControl;
using System.Text.Json.Serialization;

namespace Smraa_AlYaman.Domain.Barcodes
{
    public class Barcode
    {
        public string Code { get; private set; }
        public string Notes { get; private set; }

        public BarcodeType Type { get; private set; }
        public BarcodeSize? Size { get; private set; }
        public BarcodePricingUnit Unit { get; private set; }
        public decimal UnitsCountPerPackage { get; private set; }

        public int ProductId { get; private set; }

        public bool IsActive { get; private set; }
        public bool IsAllowedOnline { get; private set; }


        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public bool IsDeleted { get; private set; }
        [JsonIgnore]
        public Product Product { get; private set; }
        public ICollection<CustomPrice> Prices = new List<CustomPrice>();
        public Barcode(
            int productId,
            string code,
            BarcodeType type,
            BarcodePricingUnit unit,
            decimal unitsCountPerPackage,
            bool isActive= false,
            bool isAllowedOnline=false,
            string? notes = null,
            BarcodeSize? size = null)
        {
            Code = code;
            Type = type;
            Notes = notes ?? "";
            ProductId = productId;
            UnitsCountPerPackage = unitsCountPerPackage;
            IsActive = isActive;
            IsAllowedOnline = isAllowedOnline;
            Size = size;
            Unit = unit;
            CreatedAt = DateTime.UtcNow;
            LastUpdate = null;
        }

        public void Update(
            decimal? unitsCountPerPackage = null,
            bool? isActive = null,
            BarcodeType? type = null,
            BarcodeSize? size = null,
            BarcodePricingUnit? unit = null,
            bool? isAllowedOnline = null,
            string? notes = null)
        {

            if (!string.IsNullOrWhiteSpace(notes))
                Notes = notes;

            if (unitsCountPerPackage.HasValue)
                UnitsCountPerPackage = unitsCountPerPackage.Value;

            if (unit.HasValue)
                Unit = unit.Value;

            if (type.HasValue)
                Type = type.Value;

            if (size.HasValue)
                Size = size.Value;


            if (isActive.HasValue)
                IsActive = isActive.Value;

            if (isAllowedOnline.HasValue)
                IsAllowedOnline = isAllowedOnline.Value;


            LastUpdate = DateTime.UtcNow;
        }



        public void MarkAsDeleted()
        {
            if (IsDeleted) throw DomainException.AlreadyDeletedEntity;
            IsDeleted = true;
            LastUpdate = DateTime.UtcNow;
        }

        public void RecoverSnapShot(BarcodeAudit audit,Product product)
        {

            Notes = audit.Notes;
            Size = Enum.TryParse<BarcodeSize>(audit.Size,out var size)
                ? size
                : throw new DomainException(massage:"Inconsistant Enum Value.");

            Type = Enum.TryParse<BarcodeType>(audit.Type, out var type) 
                ? type
                : throw new DomainException(massage:"Inconsistant Enum Value.");

            Unit = Enum.TryParse<BarcodePricingUnit>(audit.Unit,out var unit) 
                ? unit
                : throw new DomainException(massage:"Inconsistant Enum Value.");

            UnitsCountPerPackage = audit.UnitsCountPerPackage;
            if (!product.IsAllowedOnline && audit.IsAllowedOnline )
            {
                throw new DomainException(massage: "Cannot recover barcode to be allowed online when the related product is not allowed online.");
            }
            IsAllowedOnline = audit.IsAllowedOnline;
            if (!(product.State == ProductState.Active) && audit.IsActive)
            {
                throw new DomainException(massage: "Cannot recover barcode to be active when the related product is not active.");
            }
            IsActive = audit.IsActive;
            audit.MarkAsRecoverd();
            LastUpdate = DateTime.UtcNow;
        }

        private Barcode() { }


    }
}
