using TowerApi.Model.Auth;
using TowerApi.Repositories;

namespace TowerApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _configuration;

        public AuthService(
            IAuthRepository authRepository,
            IJwtService jwtService,
            IConfiguration configuration)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
            _configuration = configuration;
        }

        public async Task<LoginResult> LoginAsync(LoginRequest user)
        {
            var result = await _authRepository.LoginAsync(user);

            if (result == null)
            {
                return new LoginResult
                {
                    ResultCode = 500,
                    ResultMessage = "خطا در انجام عملیات ورود."
                };
            }

            if (result.ResultCode != 200)
            {
                return result;
            }

            if (result.User == null)
            {
                return new LoginResult
                {
                    ResultCode = 500,
                    ResultMessage =
                        "اطلاعات کاربر پس از ورود دریافت نشد."
                };
            }

            var userSession = new UserSession
            {
                UserId = result.User.UserId,
                Username = result.User.Username,
                FirstName = result.User.FirstName,
                LastName = result.User.LastName,
                FullName = result.User.FullName,
                Email = result.User.Email,
                Mobile = result.User.Mobile,
                NationalId = result.User.NationalId,
                Gender = result.User.Gender,
                BirthDate = result.User.BirthDate,
                PhoneVerified = result.User.PhoneVerified,
                LastLoginAt = result.User.LastLoginAt,
                CreatedAt = result.User.CreatedAt,
                Avatar = null,
                Roles = result.Roles,
                Menus = result.Menus
            };

            var token = _jwtService.GenerateToken(userSession);

            result.AccessToken = token;

            result.ExpiresIn =
                _configuration.GetValue<int>("Jwt:ExpireMinutes");

            return result;
        }
    }
}