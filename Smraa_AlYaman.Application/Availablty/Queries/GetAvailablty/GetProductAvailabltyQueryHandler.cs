using MediatR;
using Smraa_AlYaman.Application.Common.DataReadingModels.Availablties;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.Availablty.Queries.GetAvailablty
{
    public class GetProductAvailabltyQueryHandler(
        IAvailabltyRepository _availabltyRepository)
        : IRequestHandler<GetProductAvailabltyQuery, ResultOf<IEnumerable<ProductAvailabltyData>>>
    {
        public async Task<ResultOf<IEnumerable<ProductAvailabltyData>>> Handle(GetProductAvailabltyQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var availablties = await _availabltyRepository.GetProductAvailablty(request.ProductId);
                
                if (availablties.Count() == 0)
                    return Error.NotFound("ProductAvailabltyNotFound", $"No availablty found for product with id {request.ProductId}");



                return availablties.AsDone();
            }
            catch (Exception ex)
            {
                return Error.Failure( "GetProductAvailabltyQuery_Fialure", ex.Message);
            }
        }
    }
}


