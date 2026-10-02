using TowerApi.Models.Auth;

namespace TowerApi.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResult> LoginAsync(LoginRequest user,string? deviceName,string? userAgent,string? ipAddress);
        Task<LoginResult> RefreshAsync(string refreshToken);
        Task RevokeRefreshTokenAsync(string refreshToken);
        Task<LoginResult?> GetCurrentUserAsync(long userId);
        Task RevokeAllSessionsAsync(long userId);
    }
}
