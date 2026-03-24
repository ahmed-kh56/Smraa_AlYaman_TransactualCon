using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.ProductPrices.Audits;

namespace Smraa_AlYaman.Application.Prices.Queries.GetProductPriceHistory;

public record GetProductPriceHistoryQuery(
    int? ProductId,
    int PageSize,
    int PageNum)
    : IRequest<ResultOf<IEnumerable<ProductPriceAudit>>>;
