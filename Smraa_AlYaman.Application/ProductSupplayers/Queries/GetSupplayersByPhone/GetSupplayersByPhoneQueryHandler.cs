using MediatR;
using Smraa_AlYaman.Application.Common.DataReadingModels.Supplayeres;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.ProductSupplayers.Queries.GetSupplayersByPhone
{
    public class GetSupplayersByPhoneQueryHandler(
        IProductSupplayerRepository _supplayerRepository)
        : IRequestHandler<GetSupplayersByPhoneQuery, ResultOf<IEnumerable<ProductSupplayerRead>>>
    {
        public async Task<ResultOf<IEnumerable<ProductSupplayerRead>>> Handle(GetSupplayersByPhoneQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var supplayers = await _supplayerRepository.GetByPhoneAsync(request.ProductId, request.PhoneNumLike, request.Name);
                return supplayers.AsDone();
            }
            catch (Exception ex)
            {
                return Error.Failure(
                    code: "GetSupplayersByPhoneQueryHandler_Failure",
                    description: ex.Message);
            }

        }
    }
}
