using Dapper;
using System.Data;
using TowerApi.Models.Auth;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.RefreshTokens
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public RefreshTokenRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task SaveAsync(
            long userId,
            string tokenHash,
            DateTime expiresAt,
            DateTime createdAt,
            Guid sessionId,
            string? deviceName,
            string? userAgent,
            string? createdIp)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@UserId", userId, DbType.Int64);
            parameters.Add("@TokenHash", tokenHash, DbType.AnsiStringFixedLength);
            parameters.Add("@ExpiresAt", expiresAt, DbType.DateTime);
            parameters.Add("@CreatedAt", createdAt, DbType.DateTime);
            parameters.Add("@SessionId", sessionId, DbType.Guid);
            parameters.Add("@DeviceName", deviceName, DbType.String);
            parameters.Add("@UserAgent", userAgent, DbType.String);
            parameters.Add("@CreatedIp", createdIp, DbType.String);

            await connection.ExecuteAsync(
                "dbo.App_RefreshTokenSave",
                parameters,
                commandType: CommandType.StoredProcedure);
        }


        public async Task<RefreshToken?> GetActiveTokenAsync(
            string tokenHash)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@TokenHash",
                tokenHash,
                DbType.AnsiStringFixedLength);

            return await connection.QueryFirstOrDefaultAsync<RefreshToken>(
                "dbo.App_RefreshTokenGetActive",
                parameters,
                commandType: CommandType.StoredProcedure);
        }


        public async Task<bool> RotateAsync(
            string oldTokenHash,
            string newTokenHash,
            DateTime newExpiresAt,
            DateTime newCreatedAt)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@OldTokenHash",
                oldTokenHash,
                DbType.AnsiStringFixedLength);

            parameters.Add(
                "@NewTokenHash",
                newTokenHash,
                DbType.AnsiStringFixedLength);

            parameters.Add(
                "@NewExpiresAt",
                newExpiresAt,
                DbType.DateTime);

            parameters.Add(
                "@NewCreatedAt",
                newCreatedAt,
                DbType.DateTime);

            await connection.ExecuteAsync(
                "dbo.App_RefreshTokenRotate",
                parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }


        public async Task RevokeAsync(
            string tokenHash)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@TokenHash",
                tokenHash,
                DbType.AnsiStringFixedLength);

            await connection.ExecuteAsync(
                "dbo.App_RefreshTokenRevoke",
                parameters,
                commandType: CommandType.StoredProcedure);
        }


        public async Task RevokeSessionAsync(
            Guid sessionId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@SessionId",
                sessionId,
                DbType.Guid);

            await connection.ExecuteAsync(
                "dbo.App_RefreshTokenRevokeSession",
                parameters,
                commandType: CommandType.StoredProcedure);
        }


        public async Task RevokeAllSessionsAsync(
            long userId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@UserId",
                userId,
                DbType.Int64);

            await connection.ExecuteAsync(
                "dbo.App_RefreshTokenRevokeAll",
                parameters,
                commandType: CommandType.StoredProcedure);
        }


        public async Task CleanupExpiredAsync()
        {
            using var connection =
                _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                "dbo.App_RefreshTokenCleanupExpired",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IReadOnlyList<RefreshToken>> GetActiveSessionsAsync(
            long userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sessions = await connection.QueryAsync<RefreshToken>(
                "dbo.App_RefreshTokenGetActiveSessions",
                new { UserId = userId },
                commandType: CommandType.StoredProcedure
            );

            return sessions.ToList();
        }
    }

}
