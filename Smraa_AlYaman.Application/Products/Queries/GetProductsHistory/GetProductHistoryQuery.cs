using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Products.Audits;


namespace Smraa_AlYaman.Application.Products.Queries.GetProductsHistory
{
    public record GetProductHistoryQuery(
        int? Id,
        int PageSize,
        int PageNum,
        int? GroupId,
        int? CountryOfOriginId,
        int? BrandId,
        int? CatagoryId,
        int? ProductState,
        int? ReceiptType,
        int? TransactionType)
        :IRequest<ResultOf<IEnumerable<ProductAudit>>>;
}
