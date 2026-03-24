using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;

namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface IProductGroupRepository
    {
        Task<bool> ExistsAsync(int productGroupId);
        Task<IEnumerable<Group>> GetProductGroupsAsync();
    }
}
