using Dapper;
using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.Branchs;
using Smraa_AlYaman.Domain.Branchs.Audits;
using Smraa_AlYaman.Infrastructure.Persistence.DbSettings;
using System.Data;
namespace Smraa_AlYaman.Infrastructure.Persistence.repositries.Branchs
{
    internal class BrancheRepository : IBrancheRepository
    {
        private readonly SmraaAlYamanDbContext _context;
        private readonly IDbSettings _dbSettings;

        public BrancheRepository(SmraaAlYamanDbContext context, IDbSettings dbSettings)
        {
            _context = context;
            _dbSettings = dbSettings;
        }

        public async Task AddAsync(Branch branch)
        {
            await _context.AddAsync(branch);
        }

        public async Task<bool> ExistsAsync(int branchId)
        {
            return await _context.Branches.AnyAsync(b=> b.Id == branchId);
        }

        public async Task<BranchAudit> GetAuditByAuditIdAsync(Guid auditId)
        {
            return await _context.BranchAudits.FirstOrDefaultAsync(ba => ba.AuditId == auditId);
        }

        public async Task<IEnumerable<Branch>> GetBranchesAsync(List<int> ids)
        {
            return await _context.Branches
                .AsNoTracking()
                .Where(b => ids.Contains(b.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Branch>> GetBranchesAsync()
        {
            var sql = "SELECT * From Branches";
            using var conn = _dbSettings.CreateConnection();
            return await conn.QueryAsync<Branch>(sql);
        }

        public async Task<IEnumerable<BranchAudit>> GetBrnchesHistoryAsync(int? branchId, int page, int pageSize)
        {
            return await _context.BranchAudits.AsNoTracking()
                .Where(ba => ba.EntityId == branchId || !branchId.HasValue)
                .Skip(page * pageSize).Take(pageSize)
                .ToListAsync();
        }

        public async Task<Branch> GetByIdAsync(int id)
        {
            return await _context.Branches.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
