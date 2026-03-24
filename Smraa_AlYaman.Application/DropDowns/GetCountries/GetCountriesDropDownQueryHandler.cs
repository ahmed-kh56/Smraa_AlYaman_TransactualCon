using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;

namespace Smraa_AlYaman.Application.DropDowns.GetCountries
{
    public class GetCountriesDropDownQueryHandler 
        (ICountryOfOriginRepository _countryOfOriginRepository)
        : IRequestHandler<GetCountriesDropDownQuery, ResultOf<IEnumerable<CountryOfOrigin>>>
    {
        public async Task<ResultOf<IEnumerable<CountryOfOrigin>>> Handle(GetCountriesDropDownQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var countries = await _countryOfOriginRepository.GetCountryOfOriginAsync();
                if (countries == null)
                {
                    return Error.NotFound(description: "No countries found.");
                }
                return countries.AsDone();
            }
            catch (Exception ex)
            {
                return Error.Failure(description: ex.Message);
            }

        }
    }
}
