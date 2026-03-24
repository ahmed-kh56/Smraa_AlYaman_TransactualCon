using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Barcodes;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Domain.Common;


namespace Smraa_AlYaman.Application.Barcodes.Commands.CreateBarcode
{
    public class CreateBarcodeCommandHandler
        (IBarcodeRepository _barcodeRepository,
        IProductRepository _productRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateBarcodeCommand, ResultOf<Barcode>>
    {
        public async Task<ResultOf<Barcode>> Handle(CreateBarcodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await _barcodeRepository.ExistsAsync(request.Code))
                    return Error.Conflict(
                        code: "DuplicateBarcode",
                        description: "A barcode with the same code already exists."
                    );

                if (!await _productRepository.ExistsAsync(request.ProductId))
                    return Error.NotFound(
                        code: "ProductNotFound",
                        description: "No product was found with the specified ID."
                    );


                var barcode = new Barcode(
                    request.ProductId,
                    request.Code,
                    (BarcodeType)request.Type,
                    (BarcodePricingUnit)request.Unit,
                    request.UnitsCountPerPackage,
                    request.IsActive,
                    request.IsAllowedOnline,
                    request.Notes,
                    (BarcodeSize)request.Size
                );

                await _unitOfWork.StartTransactionAsync();
                await _barcodeRepository.AddAsync(barcode);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
                return barcode.AsCreated();

            }
            catch(DomainException ex)
            {
                return Error.DomainFailure(code:ex.Code, description: ex.Message);
            }
            catch(Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }

        }
    }
}
