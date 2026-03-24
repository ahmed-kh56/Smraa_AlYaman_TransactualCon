using Dapper;
using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Application.Availablty.Common;
using Smraa_AlYaman.Application.Common.DataReadingModels.Availablties;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.Availablty;
using Smraa_AlYaman.Domain.Availablty.Audits;
using Smraa_AlYaman.Infrastructure.Persistence.DbSettings;

namespace Smraa_AlYaman.Infrastructure.Persistence.repositries.Availablties
{
    public class AvailabltyRepository : IAvailabltyRepository
    {
        private readonly SmraaAlYamanDbContext _context;
        private readonly IDbSettings _dbSettings;

        public AvailabltyRepository(SmraaAlYamanDbContext context, IDbSettings dbSettings)
        {
            _context = context;
            _dbSettings = dbSettings;
        }

        public async Task AddRangeAsync(IEnumerable<ProductBranchesAvailability> toAdd)
        {
            await _context.Availabilities.AddRangeAsync(toAdd);
        }

        public Task DeleteRangeAsync(IEnumerable<ProductBranchesAvailability> toDelete)
        {
            _context.Availabilities.RemoveRange(toDelete);
            return Task.CompletedTask;
        }


        public async Task<IEnumerable<ProductBranchesAvailability>> GetByBranchIdOnProductIdAsync(List<int> BIds, int productId)
        {
            return await _context.Availabilities.Where(a => a.ProductId == productId && BIds.Contains(a.BrancheId)).ToListAsync();
        }


        public async Task<IEnumerable<AvailabltyAudit>> GetProductAvailabltyHistory(int? productId = null, int? branchId = null)
        {
            return await _context.AvailabltyAudits
                .Where(aa => (!productId.HasValue || aa.EntityId.ProductId == productId.Value)
                    && (!branchId.HasValue || aa.EntityId.BranchId == branchId.Value))
                .ToListAsync();
        }
        //need a view to be impleminted 
        /*
         * product: Id, Name, EngName
         * Branch: Id, Name, OtherTable
         * should be left join the all branches should be shown
         */
        //DONE
        public async Task<IEnumerable<ProductAvailabltyData>> GetProductAvailablty(int productId)
        {
            var param = new { ProductId = productId};
            var query = "AvailabltyData.sp_GetProductAvailablty";
            using var conn = _dbSettings.CreateConnection();
            return await conn.QueryAsync<ProductAvailabltyData>(query, param);
        }

        public async Task<IEnumerable<ProductBranchesAvailability>> GetAllAsync(int? productId = null, int? branchId = null)
        {
            return await _context.Availabilities
                .Where(aa => (!productId.HasValue || aa.ProductId == productId.Value)
                    && (!branchId.HasValue || aa.BrancheId == branchId.Value))
                .ToListAsync();
        }
    }
}
