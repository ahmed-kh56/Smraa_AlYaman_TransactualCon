using MediatR;
using Smraa_AlYaman.Application.Common.DataReadingModels.ProductsData;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.Products.Queries.GetProductData
{
    public record GetProductDataQuery(int ProductId):IRequest<ResultOf<ProductDetailsModel>>;
}
