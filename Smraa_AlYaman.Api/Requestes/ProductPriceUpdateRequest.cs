using Smraa_AlYaman.Application.Prices.Commands.UpdateProductPrice;

namespace Smraa_AlYaman.Api.Requestes
{
    public class ProductPriceUpdateRequest
    {
        public decimal? PricePerSmallistUnit { get; set; } = default;
        public decimal? WholesalePricePerSmallistUnit { get; set; } = default;
        public decimal? LowestPricePerSmallistUnit { get; set; } = default;
        public decimal? SmallistUnitCost { get; set; } = default;
        public int? ProductPriceUnits { get; set; } = default;
        public string? TransactionsSammary { get; set; } = default;
        public string? Notes { get; set; } = default;
        public bool? IsWaghted { get; set; } = default;
        public bool? IsNotSellable { get; set; } = default;
        public UpdateProductPriceCommand ToCommand(int productId)
        {
            return new UpdateProductPriceCommand(
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
