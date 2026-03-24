using Dapper;
using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.CatagoryGroupAndBrand;
using Smraa_AlYaman.Infrastructure.Persistence.DbSettings;


namespace Smraa_AlYaman.Infrastructure.Persistence.repositries.ReadingRepos
{
    internal class CountryOfOriginRepository: ICountryOfOriginRepository
    {
        private readonly IDbSettings _dbSettings;
        private readonly SmraaAlYamanDbContext _dbContext;

        public CountryOfOriginRepository(IDbSettings dbSettings, SmraaAlYamanDbContext dbContext)
        {
            _dbSettings = dbSettings;
            _dbContext = dbContext;
        }

        public async Task<bool> ExistsAsync(int catagoryId)
        {
            return await _dbContext.CountriesOfOrigin.AnyAsync(c => c.Id == catagoryId);
        }

        public Task<IEnumerable<CountryOfOrigin>> GetCountryOfOriginAsync()
        {
            var conn = _dbSettings.CreateConnection();
            var command = "SELECT * FROM CountriesOfOrigin";
            return conn.QueryAsync<CountryOfOrigin>(command);

        }
    }
}
