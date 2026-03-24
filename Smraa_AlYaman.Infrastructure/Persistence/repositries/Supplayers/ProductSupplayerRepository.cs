using Dapper;
using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Application.Common.DataReadingModels.Supplayeres;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.ProductSuppliers;
using Smraa_AlYaman.Domain.ProductSuppliers.Audits;
using Smraa_AlYaman.Infrastructure.Persistence.DbSettings;
using System.Data;

namespace Smraa_AlYaman.Infrastructure.Persistence.repositries.Supplayers
{
    public class ProductSupplayerRepository : IProductSupplayerRepository
    {
        private readonly IDbSettings _dbSettings;
        private readonly SmraaAlYamanDbContext _dbContext;


        public ProductSupplayerRepository(IDbSettings dbSettings, SmraaAlYamanDbContext dbContext)
        {
            _dbSettings = dbSettings;
            _dbContext = dbContext;
        }
        /*
         * as you know this need to be implmentd
         */
        // DONE
        public async Task<IEnumerable<ProductSupplayerRead>> GetByPhoneAsync(
            int? productId = null,
            string? phone = null,
            string? name = null)
        {
            var procName = "ProductSupplayerData.sp_GetProductSupplayers";

            var parameters = new { ProductId = productId, Phone = phone, Name = name };

            using var conn = _dbSettings.CreateConnection();
            return await conn.QueryAsync<ProductSupplayerRead>(
                sql: procName,
                param: parameters,
                commandType: CommandType.StoredProcedure
            );

        }
        public async Task AddAsync(ProductSupplayer productSupplayer)
        {
            await _dbContext.ProductSupplayers.AddAsync(productSupplayer);
        }

        public Task UpdateBulkAsync(IEnumerable<ProductSupplayer> productSupplayeres)
        {
            _dbContext.ProductSupplayers.UpdateRange(productSupplayeres);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<ProductSupplayer>> GetAllByProductIdAndSupplayerId(
            int? productId = null,
            int? supplayerId = null,
            bool includeDeleted = false)
        {
            var query = _dbContext.ProductSupplayers.AsQueryable();

            if (!includeDeleted)
                query = query.Where(ps => !ps.IsDeleted);

            if (productId.HasValue)
                query = query.Where(ps => ps.ProductId == productId.Value);

            if (supplayerId.HasValue)
                query = query.Where(ps => ps.SupplayerId == supplayerId.Value);

            return await query.ToListAsync();
        }

        public async Task<ProductSupplayer?> GetByIdsAsync(
            int productId,
            int supplayerId,
            bool includeDeleted = false)
        {
            var query = _dbContext.ProductSupplayers.AsQueryable();

            if (!includeDeleted)
                query = query.Where(ps => !ps.IsDeleted);

            return await query.FirstOrDefaultAsync(ps =>
                ps.ProductId == productId &&
                ps.SupplayerId == supplayerId);
        }


    }
}
