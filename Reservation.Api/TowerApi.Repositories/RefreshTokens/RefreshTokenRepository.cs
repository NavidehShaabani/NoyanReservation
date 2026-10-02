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

        public RefreshTokenRepository(
            IDbConnectionFactory connectionFactory)
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

            const string sql = @"
                INSERT INTO dbo.RefreshTokens
                (
                    UserId,
                    SessionId,
                    TokenHash,
                    ExpiresAt,
                    DeviceName,
                    UserAgent,
                    CreatedIp
                )
                VALUES
                (
                    @UserId,
                    @SessionId,
                    @TokenHash,
                    @ExpiresAt,
                    @DeviceName,
                    @UserAgent,
                    @CreatedIp
                );";

            await connection.ExecuteAsync(sql, new
            {
                UserId = userId,
                SessionId = sessionId,
                TokenHash = tokenHash,
                ExpiresAt = expiresAt,
                DeviceName = deviceName,
                UserAgent = userAgent,
                CreatedIp = createdIp
            });
        }

        public async Task<RefreshToken?> GetActiveTokenAsync(
            string tokenHash)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = @"
                SELECT TOP (1)
                    Id,
                    UserId,
                    SessionId,
                    TokenHash,
                    ExpiresAt,
                    CreatedAt,
                    RevokedAt,
                    ReplacedByTokenHash,
                    DeviceName,
                    UserAgent,
                    CreatedIp
                FROM dbo.RefreshTokens
                WHERE TokenHash = @TokenHash
                  AND RevokedAt IS NULL
                  AND ExpiresAt > SYSUTCDATETIME();";

            return await connection.QueryFirstOrDefaultAsync<RefreshToken>(
                sql,
                new { TokenHash = tokenHash });
        }

        public async Task<bool> RotateAsync(
            long oldTokenId,
            string newTokenHash,
            DateTime newExpiresAt)
        {
            using var connection = _connectionFactory.CreateConnection();

            if (connection.State != ConnectionState.Open)
                connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                const string sql = @"
                    DECLARE @UserId BIGINT;
                    DECLARE @SessionId UNIQUEIDENTIFIER;
                    DECLARE @DeviceName NVARCHAR(200);
                    DECLARE @UserAgent NVARCHAR(1000);
                    DECLARE @CreatedIp NVARCHAR(64);

                    SELECT
                        @UserId = UserId,
                        @SessionId = SessionId,
                        @DeviceName = DeviceName,
                        @UserAgent = UserAgent,
                        @CreatedIp = CreatedIp
                    FROM dbo.RefreshTokens WITH (UPDLOCK, ROWLOCK)
                    WHERE Id = @OldTokenId
                      AND RevokedAt IS NULL
                      AND ExpiresAt > SYSUTCDATETIME();

                    IF @UserId IS NULL
                    BEGIN
                        SELECT CAST(0 AS BIT);
                        RETURN;
                    END;

                    UPDATE dbo.RefreshTokens
                    SET
                        RevokedAt = SYSUTCDATETIME(),
                        ReplacedByTokenHash = @NewTokenHash
                    WHERE Id = @OldTokenId
                      AND RevokedAt IS NULL;

                    IF @@ROWCOUNT <> 1
                    BEGIN
                        SELECT CAST(0 AS BIT);
                        RETURN;
                    END;

                    INSERT INTO dbo.RefreshTokens
                    (
                        UserId,
                        SessionId,
                        TokenHash,
                        ExpiresAt,
                        DeviceName,
                        UserAgent,
                        CreatedIp
                    )
                    VALUES
                    (
                        @UserId,
                        @SessionId,
                        @NewTokenHash,
                        @NewExpiresAt,
                        @DeviceName,
                        @UserAgent,
                        @CreatedIp
                    );

                    SELECT CAST(1 AS BIT);";

                var rotated = await connection.QuerySingleAsync<bool>(
                    sql,
                    new
                    {
                        OldTokenId = oldTokenId,
                        NewTokenHash = newTokenHash,
                        NewExpiresAt = newExpiresAt
                    },
                    transaction);

                if (!rotated)
                {
                    transaction.Rollback();
                    return false;
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task RevokeAsync(string tokenHash)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = @"
                UPDATE dbo.RefreshTokens
                SET RevokedAt = SYSUTCDATETIME()
                WHERE TokenHash = @TokenHash
                  AND RevokedAt IS NULL;";

            await connection.ExecuteAsync(
                sql,
                new { TokenHash = tokenHash });
        }

        public async Task RevokeSessionAsync(Guid sessionId)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = @"
                UPDATE dbo.RefreshTokens
                SET RevokedAt = SYSUTCDATETIME()
                WHERE SessionId = @SessionId
                  AND RevokedAt IS NULL;";

            await connection.ExecuteAsync(
                sql,
                new { SessionId = sessionId });
        }

        public async Task RevokeAllSessionsAsync(long userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = @"
                UPDATE dbo.RefreshTokens
                SET RevokedAt = SYSUTCDATETIME()
                WHERE UserId = @UserId
                  AND RevokedAt IS NULL;";

            await connection.ExecuteAsync(
                sql,
                new { UserId = userId });
        }

        public async Task<int> CleanupExpiredAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = @"
                DELETE FROM dbo.RefreshTokens
                WHERE
                    (RevokedAt IS NOT NULL
                     AND RevokedAt < DATEADD(DAY, -30, SYSUTCDATETIME()))
                    OR
                    (ExpiresAt < DATEADD(DAY, -30, SYSUTCDATETIME()));";

            return await connection.ExecuteAsync(sql);
        }

        public async Task<IReadOnlyList<RefreshToken>> GetActiveSessionsAsync(
            long userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = @"
                ;WITH LatestSessionTokens AS
                (
                    SELECT
                        *,
                        ROW_NUMBER() OVER
                        (
                            PARTITION BY SessionId
                            ORDER BY CreatedAt DESC, Id DESC
                        ) AS RowNumber
                    FROM dbo.RefreshTokens
                    WHERE UserId = @UserId
                )
                SELECT
                    Id,
                    UserId,
                    SessionId,
                    TokenHash,
                    ExpiresAt,
                    CreatedAt,
                    RevokedAt,
                    ReplacedByTokenHash,
                    DeviceName,
                    UserAgent,
                    CreatedIp
                FROM LatestSessionTokens
                WHERE RowNumber = 1
                  AND RevokedAt IS NULL
                  AND ExpiresAt > SYSUTCDATETIME()
                ORDER BY CreatedAt DESC;";

            var sessions = await connection.QueryAsync<RefreshToken>(
                sql,
                new { UserId = userId });

            return sessions.ToList();
        }
    }
}
