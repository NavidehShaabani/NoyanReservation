using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        Task<bool> RotateAsync(
            string oldTokenHash,
            string newTokenHash,
            DateTime newExpiresAt,
            DateTime newCreatedAt);

        Task RevokeAsync(
            string tokenHash);

        Task RevokeSessionAsync(
            Guid sessionId);

        Task RevokeAllSessionsAsync(
            long userId);

        Task CleanupExpiredAsync();

        Task<IReadOnlyList<RefreshToken>> GetActiveSessionsAsync(long userId);
    }
}
