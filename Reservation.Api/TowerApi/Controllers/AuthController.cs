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

                if (string.IsNullOrWhiteSpace(request.Username))
                {
                    return BadRequest(new
                    {
                        message = "نام کاربری الزامی است."
                    });
                }

                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return BadRequest(new
                    {
                        message = "رمز عبور الزامی است."
                    });
                }


                var result = await _authService.LoginAsync(request);


                if (result.ResultCode != 200)
                {
                    return StatusCode(
                        result.ResultCode,
                        new
                        {
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
                            message =
                                "اطلاعات کاربر پس از ورود دریافت نشد."
                        });
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

                    // فعلاً SP مقدار Avatar ندارد
                    Avatar = null,

                    Roles = result.Roles,

                    Menus = result.Menus
                };


                HttpContext.Session.SetUserSession(userSession);


                //return Ok(new
                //{
                //    success = true,

                //    message = result.ResultMessage
                //});
                return Ok(new
                {
                    success = true,
                    message = result.ResultMessage,
                    accessToken = result.AccessToken,
                    expiresIn = result.ExpiresIn,
                    user = new
                    {
                        userId = userSession.UserId,
                        username = userSession.Username,
                        fullName = userSession.FullName,
                        roles = userSession.Roles
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "خطایی در ورود رخ داده است.",
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
