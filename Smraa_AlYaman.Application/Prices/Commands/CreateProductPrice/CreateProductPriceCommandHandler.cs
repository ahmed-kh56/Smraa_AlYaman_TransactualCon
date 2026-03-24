using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.ProductPrices;

namespace Smraa_AlYaman.Application.Prices.Commands.CreateProductPrice
{
    public class CreateProductPriceCommandHandler(
        IProductPriceRepository _productPriceRepository,
        IProductRepository _productRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateProductPriceCommand, ResultOf<ProductPrice>>
    {

        public async Task<ResultOf<ProductPrice>> Handle(CreateProductPriceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(request.Id);
                if (product is null)
                    return Error.Conflict("CreateProductPriceCommandHandler", "Cant Add a price , no product found");

                if (product.IsDeleted)
                    return Error.Conflict("CreateProductPriceCommandHandler", "Cant Add a price , the product is deleted");


                var productPrice = new ProductPrice(
                    request.Id,
                    request.PricePerSmallistUnit,
                    request.WholesalePricePerSmallistUnit,
                    request.LowestPricePerSmallistUnit,
                    request.SmallistUnitCost,
                    (ProductPriceUnits)request.ProductPriceUnits,
                    request.TransactionsSammary,
                    request.Notes,
                    request.IsWaghted,
                    request.IsNotSellable);

                await _productPriceRepository.AddAsync(productPrice);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return productPrice.AsCreated();
            }
            catch(DomainException ex)
            {
                return Error.DomainFailure(code: ex.Code, description: ex.Message, metadata: (Dictionary<string, object>)ex.Data);
            }
            catch(Exception ex)
            {
                return Error.Failure(
                    code: "CreateProductPriceCommandHandler.Handle_Failure",
                    description: ex.Message,
                    metadata: (Dictionary<string, object>)ex.Data);
            }


        }
    }
}