using Dapper;
using System.Data;
using TowerApi.Models.LoginAttempt;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.LoginAttempt
{
    public sealed class LoginAttemptRepository : ILoginAttemptRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public LoginAttemptRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<LoginAttemptStatus> CheckAsync(
            string usernameKey)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleAsync<LoginAttemptStatus>(
                "dbo.App_LoginAttemptCheck",
                new
                {
                    UsernameKey = usernameKey,
                    MaxAttempts = 5,
                    LockoutMinutes = 15
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task FailAsync(string usernameKey)
        {
            using var connection = _connectionFactory.CreateConnection();

            await connection.QuerySingleAsync(
                "dbo.App_LoginAttemptFail",
                new
                {
                    UsernameKey = usernameKey,
                    MaxAttempts = 5,
                    LockoutMinutes = 15
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task ResetAsync(string usernameKey)
        {
            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                "dbo.App_LoginAttemptReset",
                new
                {
                    UsernameKey = usernameKey
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
