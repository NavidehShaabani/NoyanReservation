using TowerApi.Model.Auth;

namespace TowerApi.Services
{
    public interface IAuthService
    {
        Task<LoginResult> LoginAsync(LoginRequest user);
    }
}
