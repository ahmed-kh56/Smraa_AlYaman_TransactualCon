using Dapper;
using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;
using Smraa_AlYaman.Infrastructure.Persistence.DbSettings;

namespace Smraa_AlYaman.Infrastructure.Persistence.repositries.ReadingRepos
{
    internal class CatagoryRepository : ICatagoryRepository
    {
        private readonly IDbSettings _dbSettings;
        private readonly SmraaAlYamanDbContext _dbContext;


        public CatagoryRepository(IDbSettings dbSettings, SmraaAlYamanDbContext dbContext)
        {
            _dbSettings = dbSettings;
            _dbContext = dbContext;
        }

        public async Task<bool> ExistsAsync(int catagoryId)
        {
            return await _dbContext.Catagories.AnyAsync(c => c.Id == catagoryId);
        }

        public async Task<IEnumerable<Catagory>> GetCatagoriesAsync()
        {
            using var conn = _dbSettings.CreateConnection();
            var command = "SELECT * FROM Catagories";
            return await conn.QueryAsync<Catagory>(command);

        }

    }
}
