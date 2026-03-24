using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Availablty.Audits;

namespace Smraa_AlYaman.Application.Availablty.Queries.GetAvailabltyhistory
{



    public class GetAvailabltyHiestoryQueryHandler(
        IAvailabltyRepository _availabltyRepository)
        : IRequestHandler<GetAvailabltyHiestoryQuery, ResultOf<IEnumerable<AvailabltyAudit>>>
    {

        public async Task<ResultOf<IEnumerable<AvailabltyAudit>>> Handle(GetAvailabltyHiestoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var audit = await _availabltyRepository.GetProductAvailabltyHistory(request.ProductId, request.BranchId);

                if (audit == null || !audit.Any())
                {
                    return Error.NotFound(
                        "NoAvailabilityHistory",
                        "No availability history found for the specified product and branch.");
                }

                return audit.AsDone();
            }
            catch (Exception ex)
            {
                return Error.Unexpected("GetAvailabilityHistoryFailed", $"An unexpected error occurred while retrieving availability history: {ex.Message}");
            }
        }
    }
}