using Smraa_AlYaman.Application.Prices.Commands.CreateProductPrice;
using Smraa_AlYaman.Domain.ProductPrices;

namespace Smraa_AlYaman.Api.Requestes
{
    public class ProductPriceCreateRequest
    {
        public decimal PricePerSmallistUnit { get; set; }
        public decimal WholesalePricePerSmallistUnit { get; set; }
        public decimal LowestPricePerSmallistUnit { get; set; }
        public decimal SmallistUnitCost { get; set; }
        public int ProductPriceUnits { get; set; }
        public string TransactionsSammary { get; set; }
        public string Notes { get; set; }
        public bool IsWaghted { get; set; }
        public bool IsNotSellable { get; set; }
        public CreateProductPriceCommand ToCommand(int productId)
        {
            return new CreateProductPriceCommand(
                productId,
                PricePerSmallistUnit,
                WholesalePricePerSmallistUnit,
                LowestPricePerSmallistUnit,
                SmallistUnitCost,
                ProductPriceUnits,
                TransactionsSammary,
                Notes,
                IsWaghted,
                IsNotSellable);
        }
    }
}
