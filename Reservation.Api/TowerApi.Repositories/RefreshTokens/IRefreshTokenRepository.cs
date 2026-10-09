using TowerApi.Models.Common;
using TowerApi.Models.Auth;

namespace TowerApi.Repositories.RefreshTokens
{
    public interface IRefreshTokenRepository
    {
        Task SaveAsync(
            long userId,
            string tokenHash,
            DateTime expiresAt,
            DateTime createdAt,
            Guid sessionId,
            string? deviceName,
            string? userAgent,
            string? createdIp);

        Task<RefreshToken?> GetActiveTokenAsync(
            string tokenHash);

        Task<ProcedureResult> RotateAsync(
            string oldTokenHash,
            string newTokenHash,
            DateTime newExpiresAt,
            DateTime newCreatedAt);

        Task RevokeAsync(string tokenHash);

        Task RevokeSessionAsync(Guid sessionId);

        Task RevokeAllSessionsAsync(long userId);

        Task CleanupExpiredAsync();

        Task<IReadOnlyList<RefreshToken>> GetActiveSessionsAsync(
            long userId);
    }
}