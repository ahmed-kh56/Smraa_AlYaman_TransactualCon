using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;

namespace Smraa_AlYaman.Application.DropDowns.GetGroup
{
    public class GetGroupDropDownQueryHandler
        (IProductGroupRepository _groupReadRepository) : IRequestHandler<GetGroupDropDownQuery, ResultOf<IEnumerable<Group>>>
    {

        public async Task<ResultOf<IEnumerable<Group>>> Handle(GetGroupDropDownQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var groups = await _groupReadRepository.GetProductGroupsAsync();
                if (groups == null)
                {
                    return Error.NotFound(description: "No groups found.");
                }
                return groups.ToResultOf();
            }
            catch (Exception ex)
            {
                return Error.Failure(description:ex.Message);
            }


        }
    }
}
