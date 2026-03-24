using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Barcodes;
using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Application.Commands.Barcodes.UpdateBarcode
{
    public class UpdateBarcodeCommandHandler
        (IBarcodeRepository _barcodeRepository,
        IUnitOfWork _unitOfWork): IRequestHandler<UpdateBarcodeCommand, ResultOf<Barcode>>
    {

        public async Task<ResultOf<Barcode>> Handle(UpdateBarcodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var barcode = await _barcodeRepository.GetByCodeAsync(request.Code);
                if (barcode == null)
                {
                    return Error.NotFound("Barcode not found");
                }
                if(barcode.IsDeleted)
                {
                    return Error.Conflict("Deleted Barcode cant be updated");
                }
                barcode.Update(
                    request.UnitsCountPerPackage,
                    request.IsActive,
                    (BarcodeType)request.Type,
                    (BarcodeSize)request.Size,
                    (BarcodePricingUnit)request.Unit,
                    request.IsAllowedOnline,
                    request.Notes);

                _unitOfWork.StartTransactionAsync();

                _barcodeRepository.UpdateAsync(barcode);


                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();


                return  barcode.AsDone();
            }
            catch (DomainException ex)
            {
                return Error.DomainFailure(code: ex.Code, description: ex.Message);
            }
            catch (Exception ex)
            {
                return Error.Failure($"An error occurred while updating the barcode: {ex.Message}");
            }


        }
    }


}
