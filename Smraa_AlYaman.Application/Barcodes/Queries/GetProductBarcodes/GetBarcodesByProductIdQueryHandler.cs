using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Barcodes;

namespace Smraa_AlYaman.Application.Barcodes.Queries.GetProductBarcodes
{
    public class GetBarcodesByProductIdQueryHandler(
        IBarcodeRepository _readRepository)
        : IRequestHandler<GetBarcodesByProductIdQuery, ResultOf<IEnumerable<Barcode>>>
    {

        public async Task<ResultOf<IEnumerable<Barcode>>> Handle(GetBarcodesByProductIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var barcodes = await _readRepository.GetBarcodesAsync(request.ProductId);


                if (barcodes is null || !barcodes.Any())
                {
                    return Error.NotFound(description: "no barcode prices found for that place");
                }





                return barcodes.AsDone();

            }
            catch (Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }

        }
    }
}
