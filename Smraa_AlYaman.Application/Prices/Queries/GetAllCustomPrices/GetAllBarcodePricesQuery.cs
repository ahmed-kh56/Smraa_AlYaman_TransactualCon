using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CustomPrices;

namespace Smraa_AlYaman.Application.Prices.Queries.GetAllCustomPrices;

public record GetAllCustomPricesQuery(string? Code = null, int? BranchId = null,int? ProductId = null) : IRequest<ResultOf<IEnumerable<CustomPrice>>>;
