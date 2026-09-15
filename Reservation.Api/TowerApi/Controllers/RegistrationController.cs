using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Registration;
using TowerApi.Repositories.Registration;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/registration")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(
            IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }


        // ============================================
        // Mobile Signup
        // ============================================

        [AllowAnonymous]
        [HttpPost("mobile")]
        public async Task<IActionResult> MobileSignup(
            [FromBody] MobileSignupRequest request)
        {
            var requestIp =
                HttpContext.Connection.RemoteIpAddress?
                    .ToString();

            var userAgent =
                Request.Headers.UserAgent.ToString();

            var result =
                await _registrationService.MobileSignupAsync(
                    request,
                    requestIp,
                    userAgent);

            return StatusCode(
                MapStatusCode(result.ResultCode),
                new
                {
                    success = result.ResultCode == 200,
                    code = result.ResultCode,
                    message = result.ResultMessage,
                    data = result.Data
                });
        }


        // ============================================
        // Mobile OTP Verify
        // ============================================

        [AllowAnonymous]
        [HttpPost("mobile/verify")]
        public async Task<IActionResult> VerifyMobileOtp(
            [FromBody] VerifyOtpRequest request)
        {
            var result =
                await _registrationService.VerifyOtpAsync(
                    request);

            return StatusCode(
                MapStatusCode(result.ResultCode),
                new
                {
                    success = result.ResultCode == 200,
                    code = result.ResultCode,
                    message = result.ResultMessage,
                    data = result.Data
                });
        }


        // ============================================
        // Username + Password Signup
        // ============================================

        [AllowAnonymous]
        [HttpPost("username")]
        public async Task<IActionResult> UsernameSignup(
            [FromBody] UsernameSignupRequest request)
        {
            var requestIp =
                HttpContext.Connection.RemoteIpAddress?
                    .ToString();

            var userAgent =
                Request.Headers.UserAgent.ToString();

            var result =
                await _registrationService.UsernameSignupAsync(
                    request,
                    requestIp,
                    userAgent);

            return StatusCode(
                MapStatusCode(result.ResultCode),
                new
                {
                    success = result.ResultCode == 200,
                    code = result.ResultCode,
                    message = result.ResultMessage,
                    data = result.Data
                });
        }


        // ============================================
        // Status Mapping
        // ============================================

        private static int MapStatusCode(
            int resultCode)
        {
            return resultCode switch
            {
                200 => StatusCodes.Status200OK,

                400 => StatusCodes.Status400BadRequest,

                401 => StatusCodes.Status401Unauthorized,

                403 => StatusCodes.Status403Forbidden,

                404 => StatusCodes.Status404NotFound,

                409 => StatusCodes.Status409Conflict,

                410 => StatusCodes.Status410Gone,

                429 => StatusCodes.Status429TooManyRequests,

                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}
