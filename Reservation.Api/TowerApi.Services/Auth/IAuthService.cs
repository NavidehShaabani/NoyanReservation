using TowerApi.Models.Auth;

namespace TowerApi.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResult> LoginAsync(LoginRequest user);
    }
}
