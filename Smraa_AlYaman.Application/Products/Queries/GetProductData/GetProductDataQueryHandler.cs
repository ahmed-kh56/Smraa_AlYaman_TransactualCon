using MediatR;
using Smraa_AlYaman.Application.Common.DataReadingModels.ProductsData;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.Products.Queries.GetProductData
{
    public class GetProductDataQueryHandler
        (IProductRepository _productRepository): IRequestHandler<GetProductDataQuery, ResultOf<ProductDetailsModel>>
    {
        public async Task<ResultOf<ProductDetailsModel>> Handle(GetProductDataQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var productData = await _productRepository.GetDataModelAsync(request.ProductId);
                if (productData is null)
                {
                    return Error.NotFound(description: "Product May not be data added with this Id or data not enough");
                }
                return productData.AsDone();

            }
            catch (Exception ex)
            {
                return Error.Failure(description:ex.Message);
            }

        }
    }
}
