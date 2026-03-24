using MediatR;
using Smraa_AlYaman.Application.Common.DataReadingModels.ProductsData;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Products;


namespace Smraa_AlYaman.Application.Products.Queries.GetAllProducts;

public record GetProductsQuery(
    int? GroupeId,
    int? BrandId,
    int? CountryOfOrigenId,
    int? CatagoryId,
    int PageSize = 12,
    int PageNum = 0)
    :IRequest<ResultOf<IEnumerable<ProductDetailsModel>>>;
