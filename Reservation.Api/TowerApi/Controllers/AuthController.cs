using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IApiResponseFactory _responseFactory;
        private readonly ILocalizationService _localization;

        public AuthController(
            IAuthService authService,
            IApiResponseFactory responseFactory,
            ILocalizationService localization)
        {
            _authService = authService;
            _responseFactory = responseFactory;
            _localization = localization;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginRequest request)
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
                var result =
                    await _authService.LoginAsync(request);

                if (result.ResultCode != 200)
                {
                    return StatusCode(
                        ApiResponseMessageMapper.GetHttpStatusCode(
                            result.ResultCode),
                        _responseFactory.Error(
                            result.ResultCode,
                            ApiResponseMessageMapper.GetMessageKey(
                                result.ResultCode)));
                }

                if (result.User == null)
                {
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        _responseFactory.Error(
                            500,
                            "Auth.UserNotFoundAfterLogin"));
                }

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
            catch
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    _responseFactory.Error(
                        500,
                        "Auth.LoginFailed"));
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.ClearUserSession();

            return Ok(new
            {
                success = true,
                code = 200,
                messageKey = "Auth.LogoutSuccessfully",
                message = _localization.Get(
                    "Auth.LogoutSuccessfully")
            });
        }
    }
}
