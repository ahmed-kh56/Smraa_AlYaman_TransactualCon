using MediatR;
using Smraa_AlYaman.Application.Availablty.Common;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.Availablty.Commands.ChangeProductAvailablty
{
    public record ChangeProductAvailabltyCommand(List<ProductBrancheChangeDto> ChangeDtos):IRequest<ResultOf<Done>>;
}
