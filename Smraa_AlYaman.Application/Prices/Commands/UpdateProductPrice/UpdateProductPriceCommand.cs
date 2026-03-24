using MediatR;
using Smraa_AlYaman.Application.Prices.Commands.RecoverProductPrice;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.Prices.Commands.UpdateProductPrice
{
    public record UpdateProductPriceCommand(
        int ProductId,
        decimal? PricePerSmallistUnit,
        decimal? WholesalePricePerSmallistUnit,
        decimal? LowestPricePerSmallistUnit,
        decimal? SmallistUnitCost,
        int? ProductPriceUnits,
        string? TransactionsSammary,
        string? Notes,
        bool? IsWaghted,
        bool? IsNotSellable) : IRequest<ResultOf<Done>>;
}
