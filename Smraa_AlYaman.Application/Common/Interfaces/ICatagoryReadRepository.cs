using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;

namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface ICatagoryRepository
    {
        Task<bool> ExistsAsync(int catagoryId);
        Task<IEnumerable<Catagory>> GetCatagoriesAsync();
    }
}
