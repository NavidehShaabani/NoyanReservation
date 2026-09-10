using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TowerApi.Repositories.DataBase
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                var connection = new SqlConnection(
                    string.IsNullOrWhiteSpace(connectionString) ?
                    throw new InvalidOperationException("DefaultConnection is not configured.")
                    : connectionString);

                connection.Open();

                return connection;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
