using Smraa_AlYaman.Application.Availablty.Common;
using Smraa_AlYaman.Application.Common.DataReadingModels.Availablties;
using Smraa_AlYaman.Domain.Availablty;
using Smraa_AlYaman.Domain.Availablty.Audits;

namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface IAvailabltyRepository
    {
        Task AddRangeAsync(IEnumerable<ProductBranchesAvailability> toAdd);
        Task DeleteRangeAsync(IEnumerable<ProductBranchesAvailability> toDelete);
        Task<IEnumerable<ProductBranchesAvailability>> GetByBranchIdOnProductIdAsync(List<int> BIds, int productId);
        Task<IEnumerable<ProductBranchesAvailability>> GetAllAsync(int? productId = null, int? branchId = null);
        Task<IEnumerable<ProductAvailabltyData>> GetProductAvailablty(int productId);
        Task<IEnumerable<AvailabltyAudit>> GetProductAvailabltyHistory(int? productId = null, int? branchId = null);
    }

}
