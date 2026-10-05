using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TowerApi.Extensions;
using TowerApi.Models.Auth;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Auth;
using TowerApi.Services.Helper;
using TowerApi.Services.Localization;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILocalizationService _localization;
        private readonly IApiResponseFactory _responseFactory;
        private readonly IWebHostEnvironment _environment;

        public AuthController(
            IAuthService authService,
            ILocalizationService localization,
            IApiResponseFactory responseFactory, 
            IWebHostEnvironment environment)
        {
            _authService = authService;
            _localization = localization;
            _responseFactory = responseFactory;
            _environment = environment;
        }

        // =========================================
        // Login
        // POST: /api/Auth/login
        // =========================================

        [HttpPost("login")]
        [AllowAnonymous]
        
        public async Task<IActionResult> Login(
            [FromBody] LoginRequest request,
            [FromHeader(Name = "X-Device-Name")] string? deviceName)
        {
            if (request == null)
            {
                return BadRequest(
                    _responseFactory.Error(
                        400,
                        "Auth.LoginInformationRequired"));
            }

            if (string.IsNullOrWhiteSpace(request.Username))
            {
                return BadRequest(
                    _responseFactory.Error(
                        400,
                        "Auth.UsernameRequired"));
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(
                    _responseFactory.Error(
                        400,
                        "Auth.PasswordRequired"));
            }

            try
            {
                var userAgent = Request.Headers.UserAgent.ToString();

                var ipAddress =
                    HttpContext.Connection.RemoteIpAddress?.ToString();

                var result = await _authService.LoginAsync(
                    request,
                    deviceName,
                    userAgent,
                    ipAddress);

                if (result == null || result.ResultCode != 200)
                {
                    var errorCode = result?.ResultCode ?? 500;

                    return StatusCode(
                        ApiResponseMessageMapper.GetHttpStatusCode(
                            errorCode),
                        _responseFactory.Error(
                            errorCode,
                            result?.ResultMessage
                                ?? "Auth.LoginFailed"));
                }

                if (result.User == null)
                {
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        _responseFactory.Error(
                            500,
                            "Auth.UserNotFoundAfterLogin"));
                }

                if (string.IsNullOrWhiteSpace(result.AccessToken))
                {
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        _responseFactory.Error(
                            500,
                            "Auth.LoginFailed"));
                }

                if (string.IsNullOrWhiteSpace(result.RefreshToken) ||
                    result.RefreshTokenExpiresAt == null)
                {
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        _responseFactory.Error(
                            500,
                            "Auth.LoginFailed"));
                }

                // Refresh Token فقط در کوکی قرار می‌گیرد.
                SetRefreshTokenCookie(
                    result.RefreshToken,
                    result.RefreshTokenExpiresAt.Value);

                // توکن خام در پاسخ JSON قرار نمی‌گیرد.
                return Ok(new
                {
                    success = true,
                    code = 200,
                    messageKey = "Auth.LoginSuccessfully",
                    message = _localization.Get(
                        "Auth.LoginSuccessfully"),

                    accessToken = result.AccessToken,
                    expiresIn = result.ExpiresIn,

                    user = new
                    {
                        userId = result.User.UserId,
                        username = result.User.Username,
                        fullName = result.User.FullName,
                        roles = result.Roles
                    }
                });
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    _responseFactory.Error(
                        500,
                        "Auth.LoginFailed"));
            }
        }

        // =========================================
        // Refresh
        // POST: /api/Auth/refresh
        // =========================================

        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken =
                Request.Cookies["refreshToken"];

            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                ClearRefreshTokenCookie();

                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Auth.RefreshTokenRequired"));
            }

            try
            {
                var result =
                    await _authService.RefreshAsync(refreshToken);

                if (result == null ||
                    result.ResultCode != 200 ||
                    string.IsNullOrWhiteSpace(result.AccessToken) ||
                    string.IsNullOrWhiteSpace(result.RefreshToken) ||
                    result.RefreshTokenExpiresAt == null)
                {
                    ClearRefreshTokenCookie();

                    return Unauthorized(
                        _responseFactory.Error(
                            401,
                            "Auth.RefreshTokenInvalid"));
                }

                // کوکی همین دستگاه با توکن چرخش‌یافته جایگزین می‌شود.
                SetRefreshTokenCookie(
                    result.RefreshToken,
                    result.RefreshTokenExpiresAt.Value);

                return Ok(new
                {
                    success = true,
                    code = 200,
                    accessToken = result.AccessToken,
                    expiresIn = result.ExpiresIn
                });
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    _responseFactory.Error(
                        500,
                        "Auth.RefreshFailed"));
            }
        }

        // =========================================
        // Me
        // GET: /api/Auth/me
        // =========================================

        [HttpGet("ReloadUserInfo")]
        [Authorize]
        public async Task<IActionResult> ReloadUserInfo()
        {
            var userIdClaim = User.FindFirst(
                ClaimTypes.NameIdentifier);

            if (userIdClaim == null ||
                !long.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Auth.InvalidAccessToken"));
            }

            try
            {
                var result =
                    await _authService.GetCurrentUserAsync(userId);

                if (result == null ||
                    result.ResultCode != 200 ||
                    result.User == null ||
                    result.Roles == null ||
                    !result.Roles.Any())
                {
                    return Unauthorized(
                        _responseFactory.Error(
                            401,
                            "Auth.UserNotFound"));
                }

                return Ok(new
                {
                    success = true,
                    code = 200,

                    user = new
                    {
                        userId = result.User.UserId,
                        username = result.User.Username,
                        firstName = result.User.FirstName,
                        lastName = result.User.LastName,
                        fullName = result.User.FullName,
                        email = result.User.Email,
                        mobile = result.User.Mobile,
                        roles = result.Roles
                    }
                });
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    _responseFactory.Error(
                        500,
                        "Auth.GetCurrentUserFailed"));
            }
        }

        // =========================================
        // Logout current device
        // POST: /api/Auth/logout
        // =========================================

        [HttpPost("logout")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            var refreshToken =
                Request.Cookies["refreshToken"];

            try
            {
                if (!string.IsNullOrWhiteSpace(refreshToken))
                {
                    await _authService.RevokeRefreshTokenAsync(
                        refreshToken);
                }

                ClearRefreshTokenCookie();

                return Ok(new
                {
                    success = true,
                    code = 200,
                    message = "خروج از این دستگاه با موفقیت انجام شد."
                });
            }
            catch (Exception)
            {
                ClearRefreshTokenCookie();

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    _responseFactory.Error(
                        500,
                        "Auth.LogoutFailed"));
            }
        }

        // =========================================
        // Logout all devices
        // POST: /api/Auth/logout-all
        // =========================================

        [Authorize]
        [HttpPost("logout-all")]
        public async Task<IActionResult> LogoutAll()
        {
            var userIdValue = User.FindFirst(
                ClaimTypes.NameIdentifier)?.Value;

            if (!long.TryParse(userIdValue, out var userId))
            {
                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Auth.InvalidAccessToken"));
            }

            try
            {
                await _authService.RevokeAllSessionsAsync(userId);

                // کوکی دستگاه فعلی هم پاک می‌شود.
                ClearRefreshTokenCookie();

                return Ok(new
                {
                    success = true,
                    code = 200,
                    message = "نشست‌های فعال همه دستگاه‌ها باطل شدند."
                });
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    _responseFactory.Error(
                        500,
                        "Auth.LogoutFailed"));
            }
        }

        // =========================================
        // Cookie Helpers
        // =========================================

        private void SetRefreshTokenCookie(string token, DateTime expiresAt)
        {
            var isDevelopment = _environment.IsDevelopment();

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = !isDevelopment,
                SameSite = isDevelopment
                    ? SameSiteMode.Lax
                    : SameSiteMode.None,
                Path = "/api/Auth",
                Expires = expiresAt
            };

            Response.Cookies.Append(
                "refreshToken",
                token,
                cookieOptions);
        }

        private void ClearRefreshTokenCookie()
        {
            var isDevelopment = _environment.IsDevelopment();

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = !isDevelopment,
                SameSite = isDevelopment
                    ? SameSiteMode.Lax
                    : SameSiteMode.None,
                Path = "/api/Auth"
            };

            Response.Cookies.Delete(
                "refreshToken",
                cookieOptions);
        }
    }
}

