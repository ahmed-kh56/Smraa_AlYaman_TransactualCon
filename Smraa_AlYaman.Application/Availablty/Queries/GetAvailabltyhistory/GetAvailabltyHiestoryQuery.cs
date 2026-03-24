using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Availablty.Audits;

namespace Smraa_AlYaman.Application.Availablty.Queries.GetAvailabltyhistory;

public record GetAvailabltyHiestoryQuery(int ProductId,int? BranchId):IRequest<ResultOf<IEnumerable<AvailabltyAudit>>>;
