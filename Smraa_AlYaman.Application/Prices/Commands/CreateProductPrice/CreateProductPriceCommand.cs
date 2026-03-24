using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.ProductPrices;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Application.Prices.Commands.CreateProductPrice
{
    public record CreateProductPriceCommand(
        int Id,
        decimal PricePerSmallistUnit,
        decimal WholesalePricePerSmallistUnit,
        decimal LowestPricePerSmallistUnit,
        decimal SmallistUnitCost,
        int ProductPriceUnits,
        string TransactionsSammary,
        string Notes,
        bool IsWaghted,
        bool IsNotSellable)
    : IRequest<ResultOf<ProductPrice>>;

}