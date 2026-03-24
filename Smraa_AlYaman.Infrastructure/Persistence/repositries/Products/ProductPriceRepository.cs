using Dapper;
using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.ProductPrices;
using Smraa_AlYaman.Domain.ProductPrices.Audits;
using Smraa_AlYaman.Infrastructure.Persistence.DbSettings;
using System.Data;

namespace Smraa_AlYaman.Infrastructure.Persistence.repositries.Products
{
    internal class ProductPriceRepository : IProductPriceRepository
    {
        private readonly SmraaAlYamanDbContext _context;

        private readonly IDbSettings _dbSettings;

        public ProductPriceRepository(IDbSettings dbSettings, SmraaAlYamanDbContext context)
        {
            _dbSettings = dbSettings;
            _context = context;
        }

        public async Task AddAsync(ProductPrice productPrice)
        {
            await _context.ProductPrices.AddAsync(productPrice);
        }

        public async Task<IEnumerable<ProductPriceAudit>> GetAllHistoriesAsync(
            int? id = null,
            int pageSize = 12,
            int pageNumber = 0)
        {
            var sql = "ProductPriceData.sp_GetProductPriceHistory";

            var parameters = new
            {
                Id = id,
                PageSize = pageSize,
                PageNumber = pageNumber
            };
            using var connection = _dbSettings.CreateConnection();
            return await connection.QueryAsync<ProductPriceAudit>(
                sql,
                parameters,
                commandType:CommandType.StoredProcedure);

        }

        public async Task<ProductPriceAudit> GetAuditByIdAsync(Guid id)
        {
            return await _context.PriceAudits.FirstOrDefaultAsync(audit => audit.AuditId == id);
        }

        public async Task<ProductPrice> GetByIdAsync(int entityId)
        {
           return await _context.ProductPrices.FirstOrDefaultAsync(productPrice => productPrice.Id == entityId);
        }

        public Task UpdateAsync(ProductPrice productPrice)
        {
            _context.ProductPrices.Update(productPrice);
            return Task.CompletedTask;
        }

        public Task UpdateAuditAsync(ProductPriceAudit audit)
        {
            _context.PriceAudits.Update(audit);
            return Task.CompletedTask;
        }
    }
}
