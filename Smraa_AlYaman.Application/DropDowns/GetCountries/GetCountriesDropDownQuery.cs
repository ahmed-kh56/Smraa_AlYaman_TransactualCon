using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;

namespace Smraa_AlYaman.Application.DropDowns.GetCountries
{
    public record GetCountriesDropDownQuery():IRequest<ResultOf<IEnumerable<CountryOfOrigin>>>;
}
