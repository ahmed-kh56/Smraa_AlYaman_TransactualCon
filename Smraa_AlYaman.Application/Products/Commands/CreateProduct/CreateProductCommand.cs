using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    string EngName,
    int ItemTransactionType,
    int ItemReceiptType,
    int CatagoryId,
    int BrandId,
    int ProductGroupId,
    int CountryOfOriginId,
    string? MainTax = null,
    string? SubTax = null,
    decimal? TotalTaxAmount = null,
    int State =1,
    bool IsAllowedOnline = true)
    : IRequest<ResultOf<Product>>;
