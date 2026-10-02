using Microsoft.Extensions.Configuration;
using TowerApi.Models.Auth;
using TowerApi.Models.User;
using TowerApi.Repositories.Auth;
using TowerApi.Repositories.RefreshTokens;

namespace TowerApi.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly RefreshTokenService _refreshTokenService;
        private readonly IConfiguration _configuration;

        public AuthService( IAuthRepository authRepository,
                            IJwtService jwtService,
                            IRefreshTokenRepository refreshTokenRepository,
                            RefreshTokenService refreshTokenService,
                            IConfiguration configuration)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
            _refreshTokenRepository = refreshTokenRepository;
            _refreshTokenService = refreshTokenService;
            _configuration = configuration;
        }

        public async Task<LoginResult> LoginAsync(
    LoginRequest user,
    string? deviceName,
    string? userAgent,
    string? ipAddress)
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
                return result;

            if (result.User == null)
            {
                return new LoginResult
                {
                    ResultCode = 500,
                    ResultMessage = "اطلاعات کاربر پس از ورود دریافت نشد."
                };
            }

            if (result.Roles == null || !result.Roles.Any())
            {
                return new LoginResult
                {
                    ResultCode = 403,
                    ResultMessage = "کاربر فاقد نقش فعال است."
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
                Roles = result.Roles
            };

            var accessToken = _jwtService.GenerateToken(userSession);

            var refreshDays =
                _configuration.GetValue<int>("Jwt:RefreshTokenDays", 30);

            var refreshToken = _refreshTokenService.GenerateToken();
            var refreshTokenHash = _refreshTokenService.HashToken(refreshToken);
            var expiresAt = DateTime.UtcNow.AddDays(refreshDays);

            // هر Login یک SessionId مستقل دارد.
            var sessionId = Guid.NewGuid();

            await _refreshTokenRepository.SaveAsync(
                result.User.UserId,
                sessionId,
                refreshTokenHash,
                expiresAt,
                deviceName,
                userAgent,
                ipAddress
            );

            result.AccessToken = accessToken;
            result.ExpiresIn =
                _configuration.GetValue<int>("Jwt:ExpireMinutes");

            result.RefreshToken = refreshToken;
            result.RefreshTokenExpiresAt = expiresAt;

            return result;
        }
        public async Task<LoginResult> RefreshAsync(string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                return new LoginResult
                {
                    ResultCode = 401,
                    ResultMessage = "Refresh Token معتبر نیست."
                };
            }

            var oldHash = _refreshTokenService.HashToken(refreshToken);

            var storedToken =
                await _refreshTokenRepository.GetActiveTokenAsync(oldHash);

            if (storedToken == null)
            {
                return new LoginResult
                {
                    ResultCode = 401,
                    ResultMessage = "Refresh Token منقضی یا باطل شده است."
                };
            }

            var userResult =
                await _authRepository.GetUserForRefreshAsync(storedToken.UserId);

            if (userResult == null ||
                userResult.ResultCode != 200 ||
                userResult.User == null)
            {
                await _refreshTokenRepository.RevokeAsync(oldHash);

                return new LoginResult
                {
                    ResultCode = 401,
                    ResultMessage = "کاربر معتبر نیست."
                };
            }

            var userSession = new UserSession
            {
                UserId = userResult.User.UserId,
                Username = userResult.User.Username,
                FirstName = userResult.User.FirstName,
                LastName = userResult.User.LastName,
                FullName = userResult.User.FullName,
                Email = userResult.User.Email,
                Mobile = userResult.User.Mobile,
                NationalId = userResult.User.NationalId,
                Gender = userResult.User.Gender,
                BirthDate = userResult.User.BirthDate,
                PhoneVerified = userResult.User.PhoneVerified,
                LastLoginAt = userResult.User.LastLoginAt,
                CreatedAt = userResult.User.CreatedAt,
                Roles = userResult.Roles
            };

            var accessToken = _jwtService.GenerateToken(userSession);

            var refreshDays =
                _configuration.GetValue<int>("Jwt:RefreshTokenDays", 30);

            var newRefreshToken = _refreshTokenService.GenerateToken();
            var newHash = _refreshTokenService.HashToken(newRefreshToken);
            var newExpiresAt = DateTime.UtcNow.AddDays(refreshDays);

            var rotated = await _refreshTokenRepository.RotateAsync(
                storedToken.Id,
                newHash,
                newExpiresAt);

            if (!rotated)
            {
                return new LoginResult
                {
                    ResultCode = 401,
                    ResultMessage = "Refresh Token قبلاً استفاده شده است."
                };
            }

            return new LoginResult
            {
                ResultCode = 200,
                ResultMessage = "توکن با موفقیت تمدید شد.",
                User = userResult.User,
                Roles = userResult.Roles,
                AccessToken = accessToken,
                ExpiresIn = _configuration.GetValue<int>("Jwt:ExpireMinutes"),
                RefreshToken = newRefreshToken,
                RefreshTokenExpiresAt = newExpiresAt
            };
        }

        public async Task RevokeRefreshTokenAsync(string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
                return;

            var hash = _refreshTokenService.HashToken(refreshToken);

            await _refreshTokenRepository.RevokeAsync(hash);
        }

        public async Task<LoginResult?> GetCurrentUserAsync(long userId)
        {
            return await _authRepository.GetUserForRefreshAsync(userId);
        }
        public async Task RevokeAllSessionsAsync(long userId)
        {
            await _refreshTokenRepository.RevokeAllSessionsAsync(userId);
        }
    }
}