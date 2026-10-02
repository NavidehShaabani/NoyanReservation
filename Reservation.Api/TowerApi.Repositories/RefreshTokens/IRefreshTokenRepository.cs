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
        Guid sessionId,
        string tokenHash,
        DateTime expiresAt,
        string? deviceName,
        string? userAgent,
        string? createdIp);

        Task<RefreshToken?> GetActiveTokenAsync(string tokenHash);

        Task<bool> RotateAsync(
            long oldTokenId,
            string newTokenHash,
            DateTime newExpiresAt);

        Task RevokeAsync(string tokenHash);

        Task RevokeSessionAsync(Guid sessionId);

        Task RevokeAllSessionsAsync(long userId);

        Task<int> CleanupExpiredAsync();

        Task<IReadOnlyList<RefreshToken>> GetActiveSessionsAsync(long userId);
    }
}
