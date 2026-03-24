using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.ProductPrices;

namespace Smraa_AlYaman.Application.Prices.Commands.UpdateProductPrice
{
    public class UpdateProductPriceCommandHandler(
    IProductPriceRepository _productPriceRepository,
    IUnitOfWork _unitOfWork) : IRequestHandler<UpdateProductPriceCommand, ResultOf<Done>>
    {
        public async Task<ResultOf<Done>> Handle(UpdateProductPriceCommand request, CancellationToken cancellationToken)
        {
            try
            {


                var price = await _productPriceRepository.GetByIdAsync(request.ProductId);
                if (price is null)
                    return Error.Forbidden("Forbidden_RecoverProductPriceCommand", $"No price found with id {request.ProductId}");


                price.UpdatePrice(
                    request.PricePerSmallistUnit,
                    request.WholesalePricePerSmallistUnit,
                    request.LowestPricePerSmallistUnit,
                    request.SmallistUnitCost,
                    (ProductPriceUnits?)request.ProductPriceUnits,
                    request.TransactionsSammary,
                    request.Notes,
                    request.IsWaghted,
                    request.IsNotSellable
                    );

                await _productPriceRepository.UpdateAsync(price);
                await _unitOfWork.SaveChangesAsync();

                return Done.done.AsDone();

            }
            catch (DomainException ex)
            {
                return Error.DomainFailure(code: ex.Code, description: ex.Message);
            }
            catch (Exception ex)
            {
                return Error.Unexpected(description: ex.Message);
            }
        }
    }
}
