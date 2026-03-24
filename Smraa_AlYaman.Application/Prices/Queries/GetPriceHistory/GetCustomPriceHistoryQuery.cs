using MediatR;
using Smraa_AlYaman.Application.Common.DataReadingModels.Prices;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CustomPrices.Audits;

namespace Smraa_AlYaman.Application.Prices.Queries.GetPriceHistory;

public record GetCustomPriceHistoryQuery(
    string? Barcode,
    int? BranchId,
    int PageSize,
    int PageNum)
    : IRequest<ResultOf<IEnumerable<CustomPriceAuditReadModel>>>;
