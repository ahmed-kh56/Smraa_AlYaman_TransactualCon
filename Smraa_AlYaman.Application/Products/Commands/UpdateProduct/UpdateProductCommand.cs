using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Application.Products.Commands.UpdateProduct;




public record UpdateProductCommand(
    int Id,
    string? Name,
    string? EngName,
    int? ItemTransactionType,
    int? ItemReceiptType,
    int? CatagoryId,
    int? BrandId,
    int? ProductGroupId,
    int? CountryOfOriginId,
    string? MainTax,
    string? SubTax,
    decimal? TotalTaxAmount,
    int? State,
    bool? IsAllowedOnline) : IRequest<ResultOf<Product>>;
