using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.CustomPrices;

namespace Smraa_AlYaman.Application.Prices.Commands.RecoverCustomPrice
{

    public class RecoverCustomPriceCommandHandler(
        ICustomPriceRepository _customPriceRepository,
        IBarcodeRepository _barcodeRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<RecoverCustomPriceCommand, ResultOf<CustomPrice>>
    {

        public async Task<ResultOf<CustomPrice>> Handle(RecoverCustomPriceCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var Audit = await _customPriceRepository.GetAuditAsync(request.AuditId);

                if (Audit == null)
                    return Error.NotFound("Audit audit not found");



                var Price = await _customPriceRepository.GetCustomPriceByBarcodeAndBranchAsync(
                    Audit.EntityId.Barcode,
                    Audit.EntityId.BranchId);


                if (Price is null)
                    return Error.Conflict("No Barcode with the same code");



                var Barcode = await _barcodeRepository.GetByCodeAsync(Audit.EntityId.Barcode);

                if (Barcode is null)
                    return Error.Conflict("Related Barcode not found or deleted");



                Price.RecoverSnapShot(Audit);

                await _unitOfWork.StartTransactionAsync();
                await _customPriceRepository.UpdateAsync(Price);

                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();

                return Price!.AsDone();

            }
            catch(DomainException ex)
            {
                return Error.DomainFailure(description: ex.Message);
            }
            catch (Exception ex)
            {
                return Error.Unexpected(description: ex.Message);
            }

        }
    }
}