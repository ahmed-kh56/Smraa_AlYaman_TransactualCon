using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CustomPrices;

namespace Smraa_AlYaman.Application.Prices.Commands.UpdateCustomPrice
{
    public class UpdateCustomPriceCommandHandler(
        ICustomPriceRepository _priceRepository,
        IBarcodeRepository _barcodeRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<UpdateCustomPriceCommand, ResultOf<CustomPrice>>
    {

        public async Task<ResultOf<CustomPrice>> Handle(UpdateCustomPriceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existing = await _barcodeRepository.ExistsAsync(request.Code);
                if (!existing)
                {
                    return Error.NotFound(description:$"Barcode with code {request.Code} not found.");
                }

                var priceEntry = await _priceRepository.GetCustomPriceByBarcodeAndBranchAsync(request.Code, request.BranchId);

                if (priceEntry is null)
                {
                    return Error.NotFound(description:$"price wasnt found for barcode{request.Code} at branch {request.BranchId}");
                }

                if (priceEntry.IsDeleted)
                {
                    return Error.NotFound(description:$"price entry for barcode {request.Code} at branch {request.BranchId} is marked as deleted.");
                }

                priceEntry.Update(request.Price, request.LowistPrice);

                await _unitOfWork.SaveChangesAsync();

                return priceEntry.AsDone();

            }
            catch (Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }


        }
    }


}
