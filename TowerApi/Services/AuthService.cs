using TowerApi.Model.Auth;
using TowerApi.Repositories;


namespace TowerApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<LoginResult> LoginAsync(LoginRequest user)
        {
            return await _authRepository.LoginAsync(user);
        }
    }
}
