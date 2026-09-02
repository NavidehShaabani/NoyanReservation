using System.Data;
using Microsoft.Data.SqlClient;

namespace Reservation.Api.Data
{
    public class DatabaseConnection
    {
        private readonly IConfiguration _configuration;

        public DatabaseConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string is NULL or EMPTY!");
            }

            return new SqlConnection(connectionString);
        }
    }
}