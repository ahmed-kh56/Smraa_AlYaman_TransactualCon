using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;

namespace Smraa_AlYaman.Application.DropDowns.GetCatagories;

public record GetCatagoriesDropDownQuery():IRequest<ResultOf<IEnumerable<Catagory>>>;


