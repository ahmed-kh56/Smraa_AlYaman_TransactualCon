using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(
        IProductGroupRepository _productGroupRepository,
        ICatagoryRepository _catagoryRepository,
        IProductRepository _productRepository,
        ICountryOfOriginRepository _countryOfOriginRepository,
        IBrandRepository _brandRRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateProductCommand, ResultOf<Product>>
    {
        public async Task<ResultOf<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if ( !await _productGroupRepository.ExistsAsync(request.ProductGroupId))
                {
                    return Error.Conflict(code:"ProductGroup not found.");
                }
                if ( !await _catagoryRepository.ExistsAsync(request.CatagoryId))
                {
                    return Error.Conflict(code:"Catafory not found.");
                }
                if ( !await _countryOfOriginRepository.ExistsAsync(request.CountryOfOriginId))
                {
                    return Error.Conflict(code: "CountryOfOrigin not found.");
                }
                if ( !await _brandRRepository.ExistsAsync(request.BrandId))
                {
                    return Error.Conflict(code:"Brand not found.");
                }

                var Product = new Product(
                    name: request.Name,
                    englishName: request.EngName,
                    state: (ProductState)request.State,
                    isAllowedOnline: request.IsAllowedOnline,
                    transactionType: (ProductTransactionType)request.ItemTransactionType,
                    receiptType: (ProductReceiptType)request.ItemReceiptType,
                    catagoryId: request.CatagoryId,
                    brandId: request.BrandId,
                    productGroupId: request.ProductGroupId,
                    countryOfOriginId: request.CountryOfOriginId,
                    mainTax: request.MainTax,
                    subTax:  request.SubTax,
                    totalTaxAmount: request.TotalTaxAmount);

                await _productRepository.AddAsync(Product);
                await _unitOfWork.SaveChangesAsync();
                return Product.AsCreated();
            }
            catch (Exception ex)
            {
                return Error.Unexpected(description: ex.Message);
            }
        }
    }
}
