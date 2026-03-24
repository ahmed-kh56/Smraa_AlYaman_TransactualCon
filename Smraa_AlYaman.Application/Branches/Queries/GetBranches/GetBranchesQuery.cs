using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Branchs;

namespace Smraa_AlYaman.Application.Branches.Queries.GetBranches
{
    public record GetBranchesQuery():IRequest<ResultOf<IEnumerable<Branch>>>;
}
