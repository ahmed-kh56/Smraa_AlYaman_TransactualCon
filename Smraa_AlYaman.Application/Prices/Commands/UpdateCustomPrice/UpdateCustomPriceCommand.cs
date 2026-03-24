using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CustomPrices;

namespace Smraa_AlYaman.Application.Prices.Commands.UpdateCustomPrice
{
    public record UpdateCustomPriceCommand(
        string Code,
        decimal? Price,
        decimal? LowistPrice,
        int BranchId)
        : IRequest<ResultOf<CustomPrice>>;


}
