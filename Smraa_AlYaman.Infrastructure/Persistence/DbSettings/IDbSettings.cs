using System.Data;

namespace Smraa_AlYaman.Infrastructure.Persistence.DbSettings
{
    public interface IDbSettings
    {
        public string ConnectionString { get; }
        IDbConnection CreateConnection();
    }

}
