using Smraa_AlYaman.Domain.Branchs;
using Smraa_AlYaman.Domain.Branchs.Audits;

namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface IBrancheRepository
    {
        Task AddAsync(Branch branch);
        Task<bool> ExistsAsync(int branchId);
        Task<BranchAudit> GetAuditByAuditIdAsync(Guid auditId);
        Task<IEnumerable<Branch>> GetBranchesAsync(List<int> ids);
        Task<IEnumerable<Branch>> GetBranchesAsync();
        Task<Branch> GetByIdAsync(int id);
        Task<IEnumerable<BranchAudit>> GetBrnchesHistoryAsync(int? branchId, int page, int pageSize);
    }
}
