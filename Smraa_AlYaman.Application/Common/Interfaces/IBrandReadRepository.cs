using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;

namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface IBrandRepository
    {
        Task<bool> ExistsAsync(int brandId);
        Task<IEnumerable<Brand>> GetBrandsAsync();
    }
}
