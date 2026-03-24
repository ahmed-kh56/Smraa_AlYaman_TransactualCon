using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Branchs.Audits;

namespace Smraa_AlYaman.Application.Branches.Queries.GetBranchHistory
{
    public record GetBranchHistoryQuery(int? BranchId = null, int Page = 0, int PageSize = 12) : IRequest<ResultOf<IEnumerable<BranchAudit>>>;
}
