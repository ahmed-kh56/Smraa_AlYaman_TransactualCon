using MediatR;
using Smraa_AlYaman.Application.Common.DataReadingModels.Supplayeres;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.ProductSupplayers.Queries.GetSupplayersByPhone
{
    public record GetSupplayersByPhoneQuery(
        int? ProductId,
        string? PhoneNumLike,
        string? Name)
        :IRequest<ResultOf<IEnumerable<ProductSupplayerRead>>>;
}
