using Dapper;
using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;
using Smraa_AlYaman.Infrastructure.Persistence.DbSettings;

namespace Smraa_AlYaman.Infrastructure.Persistence.repositries.ReadingRepos
{
    internal class ProductGroupRepository : IProductGroupRepository
    {
        private readonly IDbSettings _dbSettings;
        private readonly SmraaAlYamanDbContext _dbContext;

        public ProductGroupRepository(IDbSettings dbSettings, SmraaAlYamanDbContext dbContext)
        {
            _dbSettings = dbSettings;
            _dbContext = dbContext;
        }
        public Task<IEnumerable<Group>> GetProductGroupsAsync()
        {
            var conn = _dbSettings.CreateConnection();
            var command = "SELECT Id,Name FROM ProductGroups";
            return conn.QueryAsync<Group>(command);
        }

        public async Task<bool> ExistsAsync(int productGroupId)
        {
            return await _dbContext.ProductGroups.AnyAsync(g => g.Id == productGroupId);
        }


    }
}
