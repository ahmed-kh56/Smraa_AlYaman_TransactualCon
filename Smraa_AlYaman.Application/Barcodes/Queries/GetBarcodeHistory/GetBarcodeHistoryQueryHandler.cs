using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Barcodes.Audits;

namespace Smraa_AlYaman.Application.Barcodes.Queries.GetBarcodeHistory
{
    public class GetBarcodeHistoryQueryHandler
        (IBarcodeRepository _barcodeRepository) : IRequestHandler<GetBarcodeHistoryQuery, ResultOf<IEnumerable<BarcodeAudit>>>
    {

        public async Task<ResultOf<IEnumerable<BarcodeAudit>>> Handle(GetBarcodeHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var audits = await _barcodeRepository.GetBarcodeAudits(
                    productId: request.ProductId,
                    barcod: request.Barcode,
                    pageSize: request.PageSize,
                    pageNumber: request.PageNum);

                if (!audits.Any())
                    return Error.NotFound(code: "No deleted or edited Barcodes for the sended product id.");

                return audits.AsDone();

            }
            catch (Exception ex)
            {
                return Error.Failure(
                    description: $"An error occurred while retrieving history for barcode '{request.Barcode}': {ex.Message}",
                    code: "BarcodeHistoryRetrievalError");
            }
        }
    }


}
