using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;

namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface ICountryOfOriginRepository
    {
        Task<bool> ExistsAsync(int countryId);
        Task<IEnumerable<CountryOfOrigin>> GetCountryOfOriginAsync();
    }
}
