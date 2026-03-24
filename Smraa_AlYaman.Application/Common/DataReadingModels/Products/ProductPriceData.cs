using Smraa_AlYaman.Domain.ProductPrices;

namespace Smraa_AlYaman.Application.Common.DataReadingModels.ProductsData
{
    public class ProductPriceData
    {
        public decimal PricePerSmallistUnit { get; set; }
        public decimal WholesalePricePerSmallistUnit { get; set; }
        public decimal LowestPricePerSmallistUnit { get; set; }
        public decimal SmallistUnitCost { get; set; }

        public ProductPriceUnits ProductPriceUnits { get; set; }

        public string TransactionsSammary { get; set; }
        public string Notes { get; set; }

        public bool IsWaghted { get; set; }
        public bool IsNotSellable { get; set; }

        public DateTime PriceCreatedAt { get; set; }
        public DateTime? PriceLastUpdate { get; set; }
    }

}
