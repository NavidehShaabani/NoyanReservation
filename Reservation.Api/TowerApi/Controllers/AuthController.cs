using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Extensions;
using TowerApi.Models.Auth;
using TowerApi.Services.Auth;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest(new
                    {
                        success = false,
                        code = 400,
                        message = "اطلاعات ورود الزامی است."
                    });
                }


                if (string.IsNullOrWhiteSpace(request.Username))
                {
                    return BadRequest(new
                    {
                        success = false,
                        code = 400,
                        message = "نام کاربری الزامی است."
                    });
                }


                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return BadRequest(new
                    {
                        success = false,
                        code = 400,
                        message = "رمز عبور الزامی است."
                    });
                }


                var result =
                    await _authService.LoginAsync(request);


                if (result.ResultCode != 200)
                {
                    return StatusCode(
                        result.ResultCode,
                        new
                        {
                            success = false,
                            code = result.ResultCode,
                            message = result.ResultMessage
                        });
                }


                if (result.User == null)
                {
                    return StatusCode(
                        500,
                        new
                        {
                            success = false,
                            code = 500,
                            message =
                                "اطلاعات کاربر پس از ورود دریافت نشد."
                        });
                }


                return Ok(new
                {
                    success = true,

                    message = result.ResultMessage,

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
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        success = false,
                        code = 500,
                        message =
                            "خطایی در ورود رخ داده است.",
                        error = ex.Message
                    });
            }
        }


        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.ClearUserSession();

            return Ok(new
            {
                success = true,
                message = "با موفقیت خارج شدید."
            });
        }
    }
}
