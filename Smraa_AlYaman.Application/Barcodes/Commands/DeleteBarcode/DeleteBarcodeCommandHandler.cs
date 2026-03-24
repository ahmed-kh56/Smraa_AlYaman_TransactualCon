using MediatR;
using Smraa_AlYaman.Application.Barcodes.Commands.DeleteBarcode;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Application.Commands.Barcodes.DeleteBarcode
{
    public class DeleteBarcodeCommandHandler
        (IBarcodeRepository _barcodeRepository,
        IUnitOfWork _unitOfWork,
        IOrderItemsRepository _orderItemsRepository) : IRequestHandler<DeleteBarcodeCommand, ResultOf<Done>>
    {

        public async Task<ResultOf<Done>> Handle(DeleteBarcodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var barcode = await _barcodeRepository.GetByCodeAsync(request.Code);
                if (barcode == null)
                {
                    return Error.NotFound(
                        code: "BarcodeNotFound",
                        description: "no barcode found with the sended code");
                }

                var exists = await _orderItemsRepository.ExistsAsync(barcode: request.Code);
                if (exists)
                    return Error.Conflict(
                        code: "DeleteBarcodeConflict",
                        description: "Can't Delete the Barcode.Some Invoices is related");

                barcode.MarkAsDeleted();


                await _barcodeRepository.UpdateAsync(barcode);

                await _unitOfWork.SaveChangesAsync();

                return Done.done.AsNoContent();
            }
            catch (DomainException ex)
            {
                return Error.DomainFailure(code: ex.Code, description: ex.Message);
            }
            catch (Exception ex)
            {
                return Error.Failure(
                    code: "DeleteBarcodeFailure",
                    description: $"An error occurred while deleting the barcode: {ex.Message}");
            }
        }
    }
}
