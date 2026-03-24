using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.Prices.Commands.DeleteCustomPrice
{
    public class DeletePriceCommandHandler
        (IBarcodeRepository _barcodeRepository,
        ICustomPriceRepository _priceRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<DeletePriceCommand, ResultOf<Done>>
    {
        public async Task<ResultOf<Done>> Handle(DeletePriceCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var priceToBeDeleted = await _priceRepository.GetCustomPriceByBarcodeAndBranchAsync(request.Code,request.BranchId);
                if (priceToBeDeleted is null)
                    return Error.NotFound(
                        description: "no prices allocated for that branch with this barcode");


                priceToBeDeleted.MarkAsDeleted();

                await _priceRepository.UpdateAsync(priceToBeDeleted);

                await _unitOfWork.SaveChangesAsync();

                return Done.done.AsNoContent();

            }
            catch(Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }



        }
    }

}
