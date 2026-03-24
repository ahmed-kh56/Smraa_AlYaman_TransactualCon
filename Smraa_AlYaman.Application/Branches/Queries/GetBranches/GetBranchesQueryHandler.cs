using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Branchs;

namespace Smraa_AlYaman.Application.Branches.Queries.GetBranches
{
    public class GetBranchesQueryHandler
        (IBrancheRepository _brancheReadRepository) : IRequestHandler<GetBranchesQuery, ResultOf<IEnumerable<Branch>>>
    {
        public async Task<ResultOf<IEnumerable<Branch>>> Handle(GetBranchesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var branchs = await _brancheReadRepository.GetBranchesAsync();
                if (!branchs.Any())
                    return Error.NotFound();
                return branchs.AsDone();

            }
            catch (Exception ex)
            {
                return Error.Failure(description:ex.Message);
            }




        }
    }
}
