using TowerApi.Models.Auth;

namespace TowerApi.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<LoginResult> LoginAsync(LoginRequest user);
    }

}
