using Dapper;
using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Application.Common.DataReadingModels.Prices;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.CustomPrices;
using Smraa_AlYaman.Domain.CustomPrices.Audits;
using Smraa_AlYaman.Infrastructure.Persistence.DbSettings;
using System.Data;

namespace Smraa_AlYaman.Infrastructure.Persistence.repositries.Barcdes
{
    internal class CustomPriceRepository : ICustomPriceRepository
    {
        private readonly SmraaAlYamanDbContext _dbContext;
        private readonly IDbSettings _dbSettings;

        public CustomPriceRepository(IDbSettings dbSettings, SmraaAlYamanDbContext dbContext)
        {
            _dbSettings = dbSettings;
            _dbContext = dbContext;
        }

        public async Task AddAsync(CustomPrice price)
        {
            await _dbContext.CustomPrices.AddAsync(price);
        }


        public async Task AddRangeAsync(IEnumerable<CustomPrice> prices)
        {
            await _dbContext.CustomPrices.AddRangeAsync(prices);
        }

        public Task DeleteAsync(CustomPrice price)
        {
            _dbContext.CustomPrices.Remove(price);
            return Task.CompletedTask;
        }



        /*
         need a view and proc 
        */
        // DONE
        public async Task<IEnumerable<CustomPrice>> GetAllCustomPricesAsync(
            string? code = null,
            int? productId = null,
            int? branchId = null)
        {
            const string sql = "CustomPriceData.GetAllPrices";

            var parameters = new
            {
                Code = code,
                ProductId = productId,
                BranchId = branchId
            };

            using var connection = _dbSettings.CreateConnection();

            return await connection.QueryAsync<CustomPrice>(
                sql,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<CustomPrice>> EFCGetAllCustomPricesAsync(
            string? code = null,
            int? productId = null,
            int? branchId = null)
        {
            var query = from cp in _dbContext.CustomPrices
                        join b in _dbContext.Barcodes
                            on cp.Code equals b.Code
                        where (string.IsNullOrEmpty(code) || cp.Code == code) &&
                              (!branchId.HasValue || cp.BranchId == branchId) &&
                              (!productId.HasValue || b.ProductId == productId)
                        select cp;

            return await query.ToListAsync();
        }
        /*
         need a view and proc 
        */
        // DONE
        public async Task<IEnumerable<CustomPriceAuditReadModel>> GetHistoryAsync(
            string? barcode = null,
            int? branchId = null,
            int pageSize = 12,
            int pageNumber = 0)
        {
            var command = "CustomPriceData.GetCustomPriceAudits";
            var param = new
            {
                BranchId = branchId,
                Barcode = barcode,
                PageSize = pageSize,
                PageNumber = pageNumber
            };
            using var conn = _dbSettings.CreateConnection();
            return await conn.QueryAsync<CustomPriceAuditReadModel>(command, param);
        }
        public async Task<CustomPriceAudit> GetAuditAsync(Guid auditId)
        {
            return await _dbContext.CustomPriceAudits.Where(a => a.AuditId == auditId).FirstOrDefaultAsync();
        }

        public async Task<CustomPrice> GetCustomPriceByBarcodeAndBranchAsync(
            string code,
            int branchId,
            bool includeDeleted = false)
        {
            var query = _dbContext.CustomPrices
                .Where(p => p.Code == code && p.BranchId == branchId);

            if (!includeDeleted)
                query = query.Where(p => !p.IsDeleted);

            return await query.FirstOrDefaultAsync();
        }



        public Task UpdateAsync(CustomPrice price)
        {
            _dbContext.CustomPrices.Update(price);
            return Task.CompletedTask;
        }
    }
}
