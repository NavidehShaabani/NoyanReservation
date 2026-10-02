using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerApi.Models.Auth;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.RefreshTokens
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public RefreshTokenRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task SaveAsync(
            long userId,
            Guid sessionId,
            string tokenHash,
            DateTime expiresAt,
            string? deviceName,
            string? userAgent,
            string? createdIp)
        {
            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                "dbo.RefreshTokenSave",
                new
                {
                    UserId = userId,
                    SessionId = sessionId,
                    TokenHash = tokenHash,
                    ExpiresAt = expiresAt,
                    DeviceName = deviceName,
                    UserAgent = userAgent,
                    CreatedIp = createdIp
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<RefreshToken?> GetActiveTokenAsync(string tokenHash)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<RefreshToken>(
                "dbo.RefreshTokenGetActive",
                new { TokenHash = tokenHash },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<bool> RotateAsync(
            long oldTokenId,
            string newTokenHash,
            DateTime newExpiresAt)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleAsync<bool>(
                "dbo.RefreshTokenRotate",
                new
                {
                    OldTokenId = oldTokenId,
                    NewTokenHash = newTokenHash,
                    NewExpiresAt = newExpiresAt
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task RevokeAsync(string tokenHash)
        {
            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                "dbo.RefreshTokenRevoke",
                new { TokenHash = tokenHash },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task RevokeSessionAsync(Guid sessionId)
        {
            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                "dbo.RefreshTokenRevokeSession",
                new { SessionId = sessionId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task RevokeAllSessionsAsync(long userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                "dbo.RefreshTokenRevokeAll",
                new { UserId = userId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> CleanupExpiredAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleAsync<int>(
                "dbo.RefreshTokenCleanupExpired",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IReadOnlyList<RefreshToken>> GetActiveSessionsAsync(
            long userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sessions = await connection.QueryAsync<RefreshToken>(
                "dbo.RefreshTokenGetActiveSessions",
                new { UserId = userId },
                commandType: CommandType.StoredProcedure
            );

            return sessions.ToList();
        }
    }

}
