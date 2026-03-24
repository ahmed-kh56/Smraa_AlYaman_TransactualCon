using Microsoft.Data.SqlClient;
using System.Data;

namespace Smraa_AlYaman.Infrastructure.Persistence.DbSettings
{
    public class ReadingDbSettings : IDbSettings
    {
        public string ConnectionString { get; }

        public ReadingDbSettings(string? readCs)
        {
            ConnectionString = readCs
                ?? throw new ArgumentNullException(nameof(readCs));
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

    }

}