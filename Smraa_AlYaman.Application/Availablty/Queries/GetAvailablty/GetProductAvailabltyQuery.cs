using MediatR;
using Smraa_AlYaman.Application.Availablty.Common;
using Smraa_AlYaman.Application.Common.DataReadingModels.Availablties;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.Availablty.Queries.GetAvailablty;

public record GetProductAvailabltyQuery(int ProductId):IRequest<ResultOf<IEnumerable<ProductAvailabltyData>>>;
