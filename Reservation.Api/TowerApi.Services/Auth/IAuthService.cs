using TowerApi.Models.Auth;

namespace TowerApi.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResult> LoginAsync(
            LoginRequest request,
            string? deviceName,
            string? userAgent,
            string? ipAddress);

        Task<RefreshResult> RefreshAsync(
            string refreshToken);

        Task<LoginResult> SelectRoleAsync(
            long userId,
            Guid sessionId,
            long roleId);

        Task<LoginResult?> GetCurrentUserAsync(
            long userId,
            Guid sessionId);

        Task RevokeSessionAsync(
            Guid sessionId);

        Task RevokeAllSessionsAsync(
            long userId);

        Task RevokeRefreshTokenAsync(
            string refreshToken);
    }
}
