using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CustomPrices;

namespace Smraa_AlYaman.Application.Prices.Queries.GetAllCustomPrices
{
    public class GetAllCustomPricesQueryHandler(
        ICustomPriceRepository _priceRepository)
        : IRequestHandler<GetAllCustomPricesQuery,ResultOf<IEnumerable<CustomPrice>>>
    {
        public async Task<ResultOf<IEnumerable<CustomPrice>>> Handle(GetAllCustomPricesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var prices = await _priceRepository.GetAllCustomPricesAsync(
                    code: request.Code,
                    branchId: request.BranchId,
                    productId: request.ProductId);

                if(!prices.Any())
                {
                    return Error.NotFound(
                        code: "GetAllCustomPricesQueryHandler_NotFound",
                        description: "No custom prices found matching the specified criteria.");
                }

                return prices.AsPartial();

            }
            catch (Exception ex)
            {
                return Error.NotFound(
                    code: "GetAllCustomPricesQueryHandler_NotFound",
                    description: ex.Message);
            }
        }
    }
}
