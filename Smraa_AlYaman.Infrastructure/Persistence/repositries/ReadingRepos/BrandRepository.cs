using Dapper;
using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;
using Smraa_AlYaman.Infrastructure.Persistence.DbSettings;

namespace Smraa_AlYaman.Infrastructure.Persistence.repositries.ReadingRepos
{
    public class BrandRepository : IBrandRepository
    {

        private readonly IDbSettings _dbSettings;
        private readonly SmraaAlYamanDbContext _dbContext;
        public BrandRepository(IDbSettings dbSettings, SmraaAlYamanDbContext dbContext)
        {
            _dbSettings = dbSettings;
            _dbContext = dbContext;
        }

        public async Task<bool> ExistsAsync(int brandId)
        {
            return await _dbContext.Brands.AnyAsync(b => b.Id == brandId);
        }

        public Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            using var conn = _dbSettings.CreateConnection();
            var command = "SELECT * FROM Brands";
            return conn.QueryAsync<Brand>(command);

        }

    }
}
