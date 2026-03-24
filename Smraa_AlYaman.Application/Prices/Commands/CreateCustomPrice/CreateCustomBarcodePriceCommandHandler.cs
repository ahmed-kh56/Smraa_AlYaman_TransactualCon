using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CustomPrices;


namespace Smraa_AlYaman.Application.Prices.Commands.CreateCustomPrice
{
    public class CreateCustomBarcodePriceCommandHandler(
        IBarcodeRepository _barcodeRepository,
        ICustomPriceRepository _priceRepository,
        IUnitOfWork _unitOfWork,
        IBrancheRepository _brancheRepository)
        : IRequestHandler<CreateCustomBarcodePriceCommand, ResultOf<CustomPrice>>
    {
        public async Task<ResultOf<CustomPrice>> Handle(CreateCustomBarcodePriceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var barcodeExists = await _barcodeRepository.ExistsAsync(request.Code);
                if (!barcodeExists)
                    return Error.Conflict(
                        code: "Conflict.AddCustomPriceToBarcode",
                        description: "Cant add a price to a not existing barcode");
                var branchExists = await _brancheRepository.ExistsAsync(request.BranchId);
                if (!branchExists)
                    return Error.Conflict(
                        code: "Conflict.AddCustomPriceToBarcode",
                        description: "Cant add a price to a not existing barcode");

                var existingPrice = await _priceRepository
                    .GetCustomPriceByBarcodeAndBranchAsync(request.Code, request.BranchId, includeDeleted: true);

                if (existingPrice != null)
                {
                    if (!existingPrice.IsDeleted)
                    {
                        return Error.Conflict(
                            code: "Conflict.CustomPriceAlreadyExists",
                            description: "A price for this barcode already exists in this branch.");
                    }

                    // Recover
                    existingPrice.Recover();
                    existingPrice.Update(request.Price, request.LowistPrice);
                    await _unitOfWork.SaveChangesAsync();

                    return existingPrice.AsNoContent();
                }

                var priceToBeAdded = new CustomPrice(
                    request.Code,
                    request.Price,
                    request.BranchId,
                    request.LowistPrice);

                await _priceRepository.AddAsync(priceToBeAdded);

                await _unitOfWork.SaveChangesAsync();

                return priceToBeAdded.AsCreated();
            }
            catch (Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }
        }
    }

}
