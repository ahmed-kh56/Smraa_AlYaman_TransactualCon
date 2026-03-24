using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;

namespace Smraa_AlYaman.Application.DropDowns.GetGroup
{
    public record GetGroupDropDownQuery()
        :IRequest<ResultOf<IEnumerable<Group>>>;
}
