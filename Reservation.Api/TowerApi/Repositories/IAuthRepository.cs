using TowerApi.Models.Auth;

namespace TowerApi.Repositories
{
    public interface IAuthRepository
    {
        Task<LoginResult> LoginAsync(LoginRequest user);
    }

}
