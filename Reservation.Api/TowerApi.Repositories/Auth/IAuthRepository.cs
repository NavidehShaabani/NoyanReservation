using TowerApi.Models.Auth;

namespace TowerApi.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<LoginResult> LoginAsync(LoginRequest user);
        Task<LoginResult?> GetUserForRefreshAsync(long userId);
        Task<LoginResult?> GetCurrentUserAsync(long userId);
    }

}
