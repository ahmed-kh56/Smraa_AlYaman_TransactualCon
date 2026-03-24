using MediatR;
using Smraa_AlYaman.Application.Common.DataReadingModels.Prices;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CustomPrices.Audits;

namespace Smraa_AlYaman.Application.Prices.Queries.GetPriceHistory
{
    public class GetCustomPriceHistoryQueryHandler(
        ICustomPriceRepository _priceRepository)
        :IRequestHandler<GetCustomPriceHistoryQuery, ResultOf<IEnumerable<CustomPriceAuditReadModel>>>
    {

        public async Task<ResultOf<IEnumerable<CustomPriceAuditReadModel>>> Handle(GetCustomPriceHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var audits = await _priceRepository.GetHistoryAsync(
                    barcode: request.Barcode,
                    branchId: request.BranchId,
                    pageSize: request.PageSize,
                    pageNumber: request.PageNum);


                if (!audits.Any())
                    return Error.NotFound(
                        description: $"No history found for the BarcodePrice '{request.Barcode}' in that branch '{request.BranchId.ToString()??""}'",
                        code: "BarcodeHistoryNotFound");


                return audits.AsPartial();

            }
            catch (Exception ex)
            {
                return Error.Failure(
                    description: 
                    $"An error occurred while retrieving history for" +
                    $" barcodePrice '{request.Barcode +"-"+request.BranchId.ToString()??""}': {ex.Message}",
                    code: "BarcodePriceHistoryRetrievalError");
            }



        }
    }
}
