using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.ProductPrices.Audits;
using Smraa_AlYaman.Domain.Products;
using System.Text.Json.Serialization;

namespace Smraa_AlYaman.Domain.ProductPrices
{
    public class ProductPrice
    {
        public int Id { get; private set; }
        [JsonIgnore]
        public Product Product { get; private set; }
        public decimal PricePerSmallistUnit { get; private set; }
        public decimal WholesalePricePerSmallistUnit { get; private set; }
        public decimal LowestPricePerSmallistUnit { get; private set; }
        public decimal SmallistUnitCost { get; private set; }
        public ProductPriceUnits ProductPriceUnits { get; private set; }
        public string TransactionsSammary { get; private set; }
        public string Notes {  get; private set; }
        public bool IsWaghted { get; private set; }
        public bool IsNotSellable { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }

        private ProductPrice() { }

        public ProductPrice(
            int productId,
            decimal pricePerSmallistUnit,
            decimal wholesalePricePerSmallistUnit,
            decimal lowestPricePerSmallistUnit,
            decimal smallistUnitCost,
            ProductPriceUnits productPriceUnits,
            string transactionsSammary,
            string notes,
            bool isWaghted,
            bool isNotSellable)
        {
            Id = productId;
            PricePerSmallistUnit = pricePerSmallistUnit;
            WholesalePricePerSmallistUnit = wholesalePricePerSmallistUnit;
            LowestPricePerSmallistUnit = lowestPricePerSmallistUnit;
            SmallistUnitCost = smallistUnitCost;
            ProductPriceUnits = productPriceUnits;
            TransactionsSammary = transactionsSammary;
            Notes = notes;
            IsWaghted = isWaghted;
            IsNotSellable = isNotSellable;
            CreatedAt = DateTime.Now;
        }
        public void UpdatePrice(
            decimal? pricePerSmallistUnit = null,
            decimal? wholesalePricePerSmallistUnit = null,
            decimal? lowestPricePerSmallistUnit = null,
            decimal? smallistUnitCost = null,
            ProductPriceUnits? productPriceUnits = null,
            string? transactionsSammary = null,
            string? notes = null,
            bool? isWaghted = null,
            bool? isNotSellable = null)
        {
            PricePerSmallistUnit = pricePerSmallistUnit ?? PricePerSmallistUnit;
            WholesalePricePerSmallistUnit = wholesalePricePerSmallistUnit ?? WholesalePricePerSmallistUnit;
            LowestPricePerSmallistUnit = lowestPricePerSmallistUnit ?? LowestPricePerSmallistUnit;
            SmallistUnitCost = smallistUnitCost ?? SmallistUnitCost;
            ProductPriceUnits = productPriceUnits ?? ProductPriceUnits;

            TransactionsSammary = transactionsSammary ?? TransactionsSammary;
            Notes = notes ?? Notes;
            IsWaghted = isWaghted ?? IsWaghted;
            IsNotSellable = isNotSellable ?? IsNotSellable;

            LastUpdate = DateTime.Now;
        }

        public void RecoverFromSnapshot(ProductPriceAudit snapshot)
        {
            PricePerSmallistUnit = snapshot.PricePerSmallistUnit;
            WholesalePricePerSmallistUnit = snapshot.WholesalePricePerSmallistUnit;
            LowestPricePerSmallistUnit = snapshot.LowestPricePerSmallistUnit;
            SmallistUnitCost = snapshot.SmallistUnitCost;
            ProductPriceUnits = (ProductPriceUnits)snapshot.ProductPriceUnits;
            TransactionsSammary = snapshot.TransactionsSammary;
            Notes = snapshot.Notes;
            IsWaghted = snapshot.IsWaghted;
            IsNotSellable = snapshot.IsNotSellable;
            LastUpdate = DateTime.Now;
            snapshot.MarkAsRecovered();

        }

    }
}
