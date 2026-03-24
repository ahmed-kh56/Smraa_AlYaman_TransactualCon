using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Products.Audits;


namespace Smraa_AlYaman.Application.Products.Queries.GetProductsHistory
{
    public class GetProductHistoryQueryHandler
        (IProductRepository _productRepository)
        : IRequestHandler<GetProductHistoryQuery, ResultOf<IEnumerable<ProductAudit>>>
    {

        public async Task<ResultOf<IEnumerable<ProductAudit>>> Handle(GetProductHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var productHistories = await _productRepository.GetAllHistoriesAsync(
                    id: request.Id,
                    brandId: request.BrandId,
                    catagoryId: request.CatagoryId,
                    countryOfOriginId: request.CountryOfOriginId,
                    groupId: request.GroupId,
                    productState: request.ProductState,
                    receiptType: request.ReceiptType,
                    transactionType: request.TransactionType,
                    pageSize: request.PageSize,
                    pageNumber: request.PageNum);


                if (productHistories == null || !productHistories.Any())
                {
                    return Error.NotFound(description: "No history found for the specified product ID.");
                }

                return productHistories.AsDone();

            }
            catch (Exception ex)
            {
                return Error.Failure(description: "An error occurred while retrieving the product history.\n"+ex.Message);
            }
        }
    }
}
