using MediatR;
using Smraa_AlYaman.Application.Common.DataReadingModels.ProductsData;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Products;


namespace Smraa_AlYaman.Application.Products.Queries.GetAllProducts
{
    public class GetProductsQueryHandler
        (IProductRepository _productRepository)
        : IRequestHandler<GetProductsQuery, ResultOf<IEnumerable<ProductDetailsModel>>>
    {

        public async Task<ResultOf<IEnumerable<ProductDetailsModel>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productRepository.GetAllAsync(
                    countryOfOrigenId:request.CountryOfOrigenId,
                    brandId:request.BrandId,
                    catagoryId: request.CatagoryId,
                    groupeId: request.GroupeId,
                    pageNum: request.PageNum,
                    pageSize: request.PageSize);


                if (products == null || !products.Any())
                {
                    return Error.NotFound(description: "No products found.");
                }
                return products.AsDone();
            }
            catch (Exception ex)
            {
                return Error.Failure(description:ex.Message);
            }
        }
    }



}
