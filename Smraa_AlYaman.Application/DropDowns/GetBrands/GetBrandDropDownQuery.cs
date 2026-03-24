using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;


namespace Smraa_AlYaman.Application.DropDowns.GetBrands;

public record GetBrandDropDownQuery():IRequest<ResultOf<IEnumerable<Brand>>>;
