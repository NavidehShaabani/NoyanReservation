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


        public AuthController(
            IAuthService authService,
            ILocalizationService localization,
            IApiResponseFactory responseFactory)
        {
            _authService = authService;

            _localization = localization;

            _responseFactory = responseFactory;
        }


        /* =====================================================
           LOGIN
           ===================================================== */

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(
            [FromBody] LoginRequest request,
            [FromHeader(Name = "X-Device-Name")]
        string? deviceName)
        {
            if (request == null)
            {
                return BadRequest(
                    _responseFactory.Error(
                        400,
                        "Auth.LoginInformationRequired"));
            }


            if (string.IsNullOrWhiteSpace(
                request.Username))
            {
                return BadRequest(
                    _responseFactory.Error(
                        400,
                        "Auth.UsernameRequired"));
            }


            if (string.IsNullOrWhiteSpace(
                request.Password))
            {
                return BadRequest(
                    _responseFactory.Error(
                        400,
                        "Auth.PasswordRequired"));
            }


            var userAgent =
                Request.Headers.UserAgent.ToString();

            var ipAddress =
                HttpContext.Connection
                    .RemoteIpAddress?
                    .ToString();


            try
            {
                var result =
                    await _authService.LoginAsync(
                        request,
                        deviceName,
                        userAgent,
                        ipAddress);


                if (result.ResultCode != 200)
                {
                    return StatusCode(
                        ApiResponseMessageMapper
                            .GetHttpStatusCode(
                                result.ResultCode),

                        _responseFactory.Error(
                            result.ResultCode,

                            ApiResponseMessageMapper
                                .GetMessageKey(
                                    result.ResultCode)));
                }


                if (result.User == null)
                {
                    return StatusCode(
                        500,
                        _responseFactory.Error(
                            500,
                            "Auth.UserNotFoundAfterLogin"));
                }


                if (string.IsNullOrWhiteSpace(
                    result.RefreshToken) ||
                    result.RefreshTokenExpiresAt == null)
                {
                    return StatusCode(
                        500,
                        _responseFactory.Error(
                            500,
                            "Auth.LoginFailed"));
                }


                SetRefreshTokenCookie(
                    result.RefreshToken,
                    result.RefreshTokenExpiresAt.Value);


                return Ok(new
                {
                    success = true,

                    code = 200,

                    messageKey =
                        "Auth.LoginSuccessfully",

                    message =
                        _localization.Get(
                            "Auth.LoginSuccessfully"),

                    accessToken =
                        result.AccessToken,

                    expiresIn =
                        result.ExpiresIn,

                    user = new
                    {
                        userId =
                            result.User.UserId,

                        username =
                            result.User.Username,

                        fullName =
                            result.User.FullName,

                        roles =
                            result.Roles,

                        activeRoleId =
                            result.ActiveRoleId,

                        sessionId =
                            result.SessionId
                    }
                });
            }
            catch
            {
                return StatusCode(
                    500,
                    _responseFactory.Error(
                        500,
                        "Auth.LoginFailed"));
            }
        }


        /* =====================================================
           REFRESH
           ===================================================== */

        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken =
                Request.Cookies["refreshToken"];


            if (string.IsNullOrWhiteSpace(
                refreshToken))
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
                    await _authService.RefreshAsync(
                        refreshToken);


                if (result.ResultCode != 200 ||
                    string.IsNullOrWhiteSpace(
                        result.AccessToken) ||
                    string.IsNullOrWhiteSpace(
                        result.RefreshToken) ||
                    result.RefreshTokenExpiresAt == null)
                {
                    ClearRefreshTokenCookie();

                    return Unauthorized(
                        _responseFactory.Error(
                            401,
                            "Auth.RefreshTokenInvalid"));
                }


                SetRefreshTokenCookie(
                    result.RefreshToken,
                    result.RefreshTokenExpiresAt.Value);


                return Ok(new
                {
                    success = true,

                    code = 200,

                    accessToken =
                        result.AccessToken,

                    expiresIn =
                        result.ExpiresIn,

                    activeRoleId =
                        result.ActiveRoleId
                });
            }
            catch
            {
                return StatusCode(
                    500,
                    _responseFactory.Error(
                        500,
                        "Auth.RefreshFailed"));
            }
        }


        /* =====================================================
           SELECT ROLE
           ===================================================== */

        [HttpPost("SelectRole")]
        [Authorize]
        public async Task<IActionResult> SelectRole(
            [FromBody] SelectRoleRequest request)
        {
            if (request == null ||
                request.RoleId <= 0)
            {
                return BadRequest(
                    _responseFactory.Error(
                        400,
                        "Auth.InvalidRole"));
            }


            var userIdValue =
                User.FindFirst(
                    ClaimTypes.NameIdentifier)
                ?.Value;


            var sessionIdValue =
                User.FindFirst(
                    ClaimTypes.Sid)
                ?.Value;


            if (!long.TryParse(
                    userIdValue,
                    out var userId) ||
                !Guid.TryParse(
                    sessionIdValue,
                    out var sessionId))
            {
                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Auth.InvalidAccessToken"));
            }


            try
            {
                var result =
                    await _authService.SelectRoleAsync(
                        userId,
                        sessionId,
                        request.RoleId);


                if (result.ResultCode != 200)
                {
                    return StatusCode(
                        result.ResultCode == 403
                            ? 403
                            : 401,

                        _responseFactory.Error(
                            result.ResultCode,
                            "Auth.RoleSelectionFailed"));
                }


                return Ok(new
                {
                    success = true,

                    code = 200,

                    accessToken =
                        result.AccessToken,

                    expiresIn =
                        result.ExpiresIn,

                    activeRoleId =
                        result.ActiveRoleId
                });
            }
            catch
            {
                return StatusCode(
                    500,
                    _responseFactory.Error(
                        500,
                        "Auth.RoleSelectionFailed"));
            }
        }


        /* =====================================================
           ME
           ===================================================== */

        [HttpGet("GetUserInfo")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo()
        {
            var userIdValue =
                User.FindFirst(
                    ClaimTypes.NameIdentifier)
                ?.Value;


            var sessionIdValue =
                User.FindFirst(
                    ClaimTypes.Sid)
                ?.Value;


            if (!long.TryParse(
                    userIdValue,
                    out var userId) ||
                !Guid.TryParse(
                    sessionIdValue,
                    out var sessionId))
            {
                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Auth.InvalidAccessToken"));
            }


            try
            {
                var result =
                    await _authService
                        .GetCurrentUserAsync(
                            userId,
                            sessionId);


                if (result == null ||
                    result.User == null)
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
                        userId =
                            result.User.UserId,

                        username =
                            result.User.Username,

                        firstName =
                            result.User.FirstName,

                        lastName =
                            result.User.LastName,

                        fullName =
                            result.User.FullName,

                        email =
                            result.User.Email,

                        mobile =
                            result.User.Mobile,

                        roles =
                            result.Roles,

                        activeRoleId =
                            result.ActiveRoleId,

                        sessionId =
                            result.SessionId
                    }
                });
            }
            catch
            {
                return StatusCode(
                    500,
                    _responseFactory.Error(
                        500,
                        "Auth.GetCurrentUserFailed"));
            }
        }


        /* =====================================================
           LOGOUT CURRENT DEVICE
           ===================================================== */

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var sessionIdValue =
                User.FindFirst(
                    ClaimTypes.Sid)
                ?.Value;


            if (!Guid.TryParse(
                sessionIdValue,
                out var sessionId))
            {
                return Unauthorized();
            }


            await _authService
                .RevokeSessionAsync(
                    sessionId);


            ClearRefreshTokenCookie();


            return Ok(new
            {
                success = true,
                code = 200,
                message = "نشست‌های فعال همه دستگاه‌ها باطل شدند."
            });
        }


        /* =====================================================
           LOGOUT ALL
           ===================================================== */

        [HttpPost("logout-all")]
        [Authorize]
        public async Task<IActionResult> LogoutAll()
        {
            var userIdValue =
                User.FindFirst(
                    ClaimTypes.NameIdentifier)
                ?.Value;


            if (!long.TryParse(
                userIdValue,
                out var userId))
            {
                return Unauthorized();
            }


            await _authService
                .RevokeAllSessionsAsync(
                    userId);


            ClearRefreshTokenCookie();


            return Ok(new
            {
                success = true,
                code = 200,
                message = "نشست‌های فعال همه دستگاه‌ها باطل شدند."
            });
        }


        /* =====================================================
           COOKIE
           ===================================================== */

        private void SetRefreshTokenCookie(
            string token,
            DateTime expiresAt)
        {
            var isDevelopment =
                HttpContext.RequestServices
                    .GetRequiredService<
                        IWebHostEnvironment>()
                    .IsDevelopment();


            Response.Cookies.Append(
                "refreshToken",
                token,
                new CookieOptions
                {
                    HttpOnly = true,

                    Secure = !isDevelopment,

                    SameSite =
                        isDevelopment
                            ? SameSiteMode.Lax
                            : SameSiteMode.None,

                    Expires =
                        new DateTimeOffset(
                            DateTime.SpecifyKind(
                                expiresAt,
                                DateTimeKind.Utc)),

                    Path = "/api/Auth"
                });
        }


        private void ClearRefreshTokenCookie()
        {
            var isDevelopment =
                HttpContext.RequestServices
                    .GetRequiredService<
                        IWebHostEnvironment>()
                    .IsDevelopment();


            Response.Cookies.Delete(
                "refreshToken",
                new CookieOptions
                {
                    HttpOnly = true,

                    Secure = !isDevelopment,

                    SameSite =
                        isDevelopment
                            ? SameSiteMode.Lax
                            : SameSiteMode.None,

                    Path = "/api/Auth"
                });
        }
    }
}

