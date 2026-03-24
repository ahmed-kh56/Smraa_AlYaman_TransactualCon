using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.ProductPrices;

namespace Smraa_AlYaman.Application.Prices.Commands.RecoverProductPrice
{
    public record RecoverProductPriceCommand(Guid AuditId) : IRequest<ResultOf<ProductPrice>>;
}
