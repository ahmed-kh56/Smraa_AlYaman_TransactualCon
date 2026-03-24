using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.ProductPrices.Audits;

namespace Smraa_AlYaman.Application.Prices.Queries.GetProductPriceHistory
{
    public class GetProductPriceHistoryQueryHandler(
        IProductPriceRepository _priceRepository)
        :IRequestHandler<GetProductPriceHistoryQuery, ResultOf<IEnumerable<ProductPriceAudit>>>
    {

        public async Task<ResultOf<IEnumerable<ProductPriceAudit>>> Handle(GetProductPriceHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var audits = await _priceRepository.GetAllHistoriesAsync(
                    id: request.ProductId,
                    pageSize: request.PageSize,
                    pageNumber: request.PageNum);


                if (!audits.Any())
                    return Error.NotFound(
                        description: $"No history found for the price",
                        code: "BarcodeHistoryNotFound");


                return audits.AsPartial();

            }
            catch (Exception ex)
            {
                return Error.Failure(
                    description: 
                    $"An error occurred while retrieving history :{ex.Message}",
                    code: "BarcodePriceHistoryRetrievalError");
            }



        }
    }
}
