using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Barcodes;
using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Application.Barcodes.Commands.RecoverBarcode
{



    public class RecoverBarcodeCommandHandler(
        IBarcodeRepository _barcodeRepository,
        IProductRepository _productRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<RecoverBarcodeCommand, ResultOf<Barcode>>
    {

        public async Task<ResultOf<Barcode>> Handle(RecoverBarcodeCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var Audit = await _barcodeRepository.GetAuditAsync(request.AuditId);

                if (Audit == null)
                    return Error.NotFound("Barcode audit not found");

                var Barcode = await _barcodeRepository.GetByCodeAsync(Audit.EntityId);

                if (Barcode is null)
                    return Error.Conflict("No Barcode with the same code");


                var Product = await _productRepository.GetByIdAsync(Audit.ProductId);

                if (Product is null)
                    return Error.Conflict("Related product not found or deleted");


                await _unitOfWork.StartTransactionAsync();

                Barcode.RecoverSnapShot(Audit, Product);
                await _barcodeRepository.UpdateAsync(Barcode);



                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();

                return Barcode.AsDone();
            }
            catch (DomainException ex)
            {
                return Error.DomainFailure(code:ex.Code, description: ex.Message);
            }
            catch (Exception ex)
            {
                return Error.Unexpected(description: ex.Message);
            }
        }
    }
}