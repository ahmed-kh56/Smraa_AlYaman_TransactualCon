using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Branchs.Audits;

namespace Smraa_AlYaman.Application.Branches.Queries.GetBranchHistory
{
    public class GetBranchHistoryQueryHandler(
        IBrancheRepository _brancheRepository)
        : IRequestHandler<GetBranchHistoryQuery, ResultOf<IEnumerable<BranchAudit>>>
    {
        public async Task<ResultOf<IEnumerable<BranchAudit>>> Handle(GetBranchHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var branches = await _brancheRepository.GetBrnchesHistoryAsync
                    (request.BranchId,
                    request.Page,
                    request.PageSize);

                if (!branches.Any())
                    return Error.NotFound("GetBranchHistoryQueryHandler.Handel_NotFound");

                return branches.AsPartial();

            }
            catch (Exception ex)
            {
                return Error.Failure("GetBranchHistoryQueryHandler.Handel_Failure",ex.Message);
            }
        }
    }
}
