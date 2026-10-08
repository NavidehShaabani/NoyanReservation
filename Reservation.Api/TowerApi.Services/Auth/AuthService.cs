using Microsoft.Extensions.Configuration;
using TowerApi.Models.Auth;
using TowerApi.Models.User;
using TowerApi.Repositories.Auth;
using TowerApi.Repositories.LoginAttempt;
using TowerApi.Repositories.RefreshTokens;
using TowerApi.Repositories.SessionRepository;

namespace TowerApi.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        private readonly IUserSessionRepository _userSessionRepository;

        private readonly IRefreshTokenRepository _refreshTokenRepository;

        private readonly IJwtService _jwtService;

        private readonly IConfiguration _configuration;

        public AuthService(
            IAuthRepository authRepository,
            IUserSessionRepository userSessionRepository,
            IRefreshTokenRepository refreshTokenRepository,
            IJwtService jwtService,
            IConfiguration configuration)
        {
            _authRepository = authRepository;

            _userSessionRepository =
                userSessionRepository;

            _refreshTokenRepository =
                refreshTokenRepository;

            _jwtService = jwtService;

            _configuration = configuration;
        }


        /* =====================================================
           LOGIN
           ===================================================== */

        public async Task<LoginResult> LoginAsync(
            LoginRequest request,
            string? deviceName,
            string? userAgent,
            string? ipAddress)
        {
            var result =
                await _authRepository.LoginAsync(request);


            if (result == null)
            {
                return new LoginResult
                {
                    ResultCode = 500,
                    ResultMessage =
                        "خطا در انجام عملیات ورود."
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


            /*
             * Session
             */

            var sessionId =
                Guid.NewGuid();


            /*
             * فقط در صورتی که دقیقاً یک Role وجود دارد،
             * همان Role به صورت خودکار فعال می‌شود.
             */

            long? activeRoleId = null;


            if (result.Roles.Count == 1)
            {
                activeRoleId =
                    result.Roles[0].RoleId;
            }


            var session =
                new UserSessionEntity
                {
                    SessionId = sessionId,

                    UserId =
                        result.User.UserId,

                    ActiveRoleId =
                        activeRoleId,

                    DeviceName =
                        deviceName,

                    UserAgent =
                        userAgent,

                    CreatedIp =
                        ipAddress
                };


            var createdSession =
                await _userSessionRepository
                    .CreateAsync(session);


            if (createdSession == null)
            {
                return new LoginResult
                {
                    ResultCode = 500,
                    ResultMessage =
                        "ایجاد نشست کاربر ناموفق بود."
                };
            }


            /*
             * JWT
             */

            var userSession =
                BuildJwtUserSession(
                    result.User,
                    result.Roles,
                    sessionId,
                    activeRoleId);


            result.AccessToken =
                _jwtService.GenerateToken(
                    userSession);


            result.ExpiresIn =
                _configuration.GetValue<int>(
                    "Jwt:ExpireMinutes");


            /*
             * Refresh Token
             */

            var refreshToken =
                RefreshTokenGenerator.Generate();


            var refreshTokenHash =
                RefreshTokenGenerator.Hash(
                    refreshToken);


            var refreshMinutes =
                _configuration.GetValue<int>(
                    "Jwt:RefreshTokenMinutes",
                    60 * 24 * 30);


            var refreshExpiresAt =
                DateTime.UtcNow.AddMinutes(
                    refreshMinutes);


            await _refreshTokenRepository.SaveAsync(
                result.User.UserId,
                refreshTokenHash,
                refreshExpiresAt,
                DateTime.UtcNow,
                sessionId,
                deviceName,
                userAgent,
                ipAddress);


            result.RefreshToken =
                refreshToken;

            result.RefreshTokenExpiresAt =
                refreshExpiresAt;

            result.SessionId =
                sessionId;

            result.ActiveRoleId =
                activeRoleId;


            return result;
        }


        /* =====================================================
           REFRESH
           ===================================================== */

        public async Task<RefreshResult> RefreshAsync(
            string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(
                refreshToken))
            {
                return new RefreshResult
                {
                    ResultCode = 401,
                    ResultMessage =
                        "Refresh Token الزامی است."
                };
            }


            var oldHash =
                RefreshTokenGenerator.Hash(
                    refreshToken);


            var oldToken =
                await _refreshTokenRepository
                    .GetActiveTokenAsync(
                        oldHash);


            if (oldToken == null)
            {
                return new RefreshResult
                {
                    ResultCode = 401,
                    ResultMessage =
                        "Refresh Token معتبر نیست."
                };
            }


            var session =
                await _userSessionRepository
                    .GetByIdAsync(
                        oldToken.SessionId);


            if (session == null ||
                session.RevokedAt.HasValue)
            {
                return new RefreshResult
                {
                    ResultCode = 401,
                    ResultMessage =
                        "نشست کاربر معتبر نیست."
                };
            }


            /*
             * گرفتن اطلاعات کامل User + Roles
             */

            var userResult =
                await _authRepository
                    .GetCurrentUserAsync(
                        oldToken.UserId);


            if (userResult == null ||
                userResult.User == null)
            {
                return new RefreshResult
                {
                    ResultCode = 401,
                    ResultMessage =
                        "کاربر معتبر نیست."
                };
            }


            /*
             * اگر Role فعال قبلاً حذف/منقضی شده باشد،
             * دیگر Role را داخل JWT قرار نمی‌دهیم.
             */

            long? activeRoleId =
                session.ActiveRoleId;

            UserRole? activeRole = null;

            if (activeRoleId.HasValue)
            {
                activeRole =
                    userResult.Roles.FirstOrDefault(
                        x => x.RoleId == activeRoleId.Value);

                if (activeRole == null)
                {
                    activeRoleId = null;
                }
            }
            if (activeRoleId.HasValue)
            {
                var validRole =
                    userResult.Roles.Any(
                        x =>
                            x.RoleId ==
                            activeRoleId.Value);


                if (!validRole)
                {
                    activeRoleId = null;
                }
            }


            /*
             * Refresh Token جدید
             */

            var newRefreshToken =
                RefreshTokenGenerator.Generate();


            var newHash =
                RefreshTokenGenerator.Hash(
                    newRefreshToken);


            var refreshMinutes =
                _configuration.GetValue<int>(
                    "Jwt:RefreshTokenMinutes",
                    60 * 24 * 30);


            var newExpiresAt =
                DateTime.UtcNow.AddMinutes(
                    refreshMinutes);


            var rotated =
                await _refreshTokenRepository
                    .RotateAsync(
                        oldHash,
                        newHash,
                        newExpiresAt,
                        DateTime.UtcNow);


            if (!rotated)
            {
                return new RefreshResult
                {
                    ResultCode = 401,
                    ResultMessage =
                        "Refresh Token قابل استفاده نیست."
                };
            }


            /*
             * JWT جدید
             */

            var jwtUser =
                BuildJwtUserSession(
                    userResult.User,
                    userResult.Roles,
                    session.SessionId,
                    activeRoleId);


            var accessToken =
                _jwtService.GenerateToken(
                    jwtUser);


            var expiresIn =
                _configuration.GetValue<int>(
                    "Jwt:ExpireMinutes");


            await _userSessionRepository
                .UpdateLastSeenAsync(
                    session.SessionId);


            return new RefreshResult
            {
                ResultCode = 200,

                ResultMessage =
        "Refresh موفق بود.",

                AccessToken =
        accessToken,

                ExpiresIn =
        expiresIn,

                RefreshToken =
        newRefreshToken,

                RefreshTokenExpiresAt =
        newExpiresAt,

                SessionId =
        session.SessionId,

                ActiveRoleId =
        activeRoleId,

                ActiveRoleCode =
        activeRole?.RoleCode
            };
        }


        /* =====================================================
           SELECT ROLE
           ===================================================== */

        public async Task<LoginResult> SelectRoleAsync(
            long userId,
            Guid sessionId,
            long roleId)
        {
            var changed =
                await _userSessionRepository
                    .SetActiveRoleAsync(
                        sessionId,
                        userId,
                        roleId);


            if (!changed)
            {
                return new LoginResult
                {
                    ResultCode = 403,
                    ResultMessage =
                        "کاربر به این نقش دسترسی ندارد."
                };
            }


            var result =
                await _authRepository
                    .GetCurrentUserAsync(
                        userId);


            if (result == null ||
                result.User == null)
            {
                return new LoginResult
                {
                    ResultCode = 401,
                    ResultMessage =
                        "کاربر معتبر نیست."
                };
            }


            var roleExists =
                result.Roles.Any(
                    x => x.RoleId == roleId);


            if (!roleExists)
            {
                return new LoginResult
                {
                    ResultCode = 403,
                    ResultMessage =
                        "نقش انتخاب‌شده معتبر نیست."
                };
            }


            var userSession =
                BuildJwtUserSession(
                    result.User,
                    result.Roles,
                    sessionId,
                    roleId);


            result.AccessToken =
                _jwtService.GenerateToken(
                    userSession);


            result.ExpiresIn =
                _configuration.GetValue<int>(
                    "Jwt:ExpireMinutes");


            result.SessionId =
                sessionId;

            result.ActiveRoleId =
                roleId;


            return result;
        }


        /* =====================================================
           ME
           ===================================================== */

        public async Task<LoginResult?> GetCurrentUserAsync(
            long userId,
            Guid sessionId)
        {
            var session =
                await _userSessionRepository
                    .GetByIdAsync(
                        sessionId);


            if (session == null ||
                session.UserId != userId)
            {
                return null;
            }


            var result =
                await _authRepository
                    .GetCurrentUserAsync(
                        userId);


            if (result == null ||
                result.User == null)
            {
                return null;
            }


            result.SessionId =
                sessionId;

            result.ActiveRoleId =
                session.ActiveRoleId;


            return result;
        }


        /* =====================================================
           LOGOUT CURRENT SESSION
           ===================================================== */

        public async Task RevokeSessionAsync(
            Guid sessionId)
        {
            await _userSessionRepository
                .RevokeAsync(
                    sessionId);
        }


        /* =====================================================
           LOGOUT ALL
           ===================================================== */

        public async Task RevokeAllSessionsAsync(
            long userId)
        {
            await _userSessionRepository
                .RevokeAllAsync(
                    userId);
        }


        /* =====================================================
           LEGACY REFRESH REVOKE
           ===================================================== */

        public async Task RevokeRefreshTokenAsync(
            string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(
                refreshToken))
            {
                return;
            }


            var hash =
                RefreshTokenGenerator.Hash(
                    refreshToken);


            var token =
                await _refreshTokenRepository
                    .GetActiveTokenAsync(
                        hash);


            if (token == null)
            {
                return;
            }


            await _userSessionRepository
                .RevokeAsync(
                    token.SessionId);
        }


        /* =====================================================
           JWT USER
           ===================================================== */

        private static UserSession BuildJwtUserSession(
            UserInfo user,
            List<UserRole> roles,
            Guid sessionId,
            long? activeRoleId)
        {
            return new UserSession
            {
                SessionId =
                    sessionId,

                UserId =
                    user.UserId,

                ActiveRoleId =
                    activeRoleId,

                Username =
                    user.Username ?? string.Empty,

                FirstName =
                    user.FirstName,

                LastName =
                    user.LastName,

                FullName =
                    user.FullName,

                Email =
                    user.Email,

                Mobile =
                    user.Mobile,

                NationalId =
                    user.NationalId,

                Gender =
                    user.Gender,

                BirthDate =
                    user.BirthDate,

                PhoneVerified =
                    user.PhoneVerified,

                LastLoginAt =
                    user.LastLoginAt,

                CreatedAt =
                    user.CreatedAt,

                Roles =
                    roles
            };
        }
    }
}