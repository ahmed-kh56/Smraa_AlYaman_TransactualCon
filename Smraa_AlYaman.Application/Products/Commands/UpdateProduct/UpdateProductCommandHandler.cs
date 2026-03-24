using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler(
        IProductGroupRepository _productGroupRepository,
        ICatagoryRepository _catagoryRepository,
        IProductRepository _productRepository,
        ICountryOfOriginRepository _countryOfOriginRepository,
        IBrandRepository _brandRRepository,
        IUnitOfWork _unitOfWork) : IRequestHandler<UpdateProductCommand, ResultOf<Product>>
    {

        public async Task<ResultOf<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {


                var productToUpdate = await _productRepository.GetByIdAsync(request.Id);
                if (productToUpdate == null)
                {
                    return Error.NotFound(code: "Product not found.");
                }


                if (request.ProductGroupId.HasValue)
                {
                    if (!await _productGroupRepository.ExistsAsync(request.ProductGroupId.Value))
                    {
                        return Error.Conflict(code: "ProductGroup not found.");
                    }
                }
                if (request.CatagoryId.HasValue)
                {
                    if (!await _catagoryRepository.ExistsAsync(request.CatagoryId.Value))
                    {
                        return Error.Conflict(code: "Catafory not found.");
                    }
                }
                if (request.CountryOfOriginId.HasValue)
                {
                    if (!await _countryOfOriginRepository.ExistsAsync(request.CountryOfOriginId.Value))
                    {
                        return Error.Conflict(code: "CountryOfOrigin not found.");
                    }
                }
                if (request.BrandId.HasValue)
                {
                    if (!await _brandRRepository.ExistsAsync(request.BrandId.Value))
                    {
                        return Error.Conflict(code: "Brand not found.");
                    }
                }

                productToUpdate.Update(
                    name: request.Name,
                    englishName: request.EngName,
                    state: request.State.HasValue ? (ProductState?)request.State.Value : null,
                    isAllowedOnline: request.IsAllowedOnline,
                    transactionType: request.ItemTransactionType.HasValue ? (ProductTransactionType?)request.ItemTransactionType.Value : null,
                    receiptType: request.ItemReceiptType.HasValue ? (ProductReceiptType?)request.ItemReceiptType.Value : null,
                    catagoryId: request.CatagoryId,
                    brandId: request.BrandId,
                    productGroupId: request.ProductGroupId,
                    countryOfOriginId: request.CountryOfOriginId,
                    mainTax: request.MainTax,
                    subTax: request.SubTax,
                    totalTaxAmount: request.TotalTaxAmount
                    );

                await _productRepository.UpdateAsync(productToUpdate);
                await _unitOfWork.SaveChangesAsync();

                return productToUpdate.AsDone();




            }
            catch (Exception ex)
            {
                return Error.Unexpected(code: "Unexpected_UpdateProductCommandHandler",
                    description: ex.Message);
            }
        }
    }


}
