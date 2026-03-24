using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;

namespace Smraa_AlYaman.Application.DropDowns.GetCatagories
{
    public class GetCatagoriesDropDownQueryHandler
        (ICatagoryRepository _catagoryRepository)
        : IRequestHandler<GetCatagoriesDropDownQuery, ResultOf<IEnumerable<Catagory>>>
    {
        public async Task<ResultOf<IEnumerable<Catagory>>> Handle(GetCatagoriesDropDownQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var catagories = await _catagoryRepository.GetCatagoriesAsync();
                if (catagories == null)
                {
                    return Error.NotFound(description: "No catagories found.");
                }
                return catagories.AsDone();
            }
            catch (Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }
        }
    }
}


