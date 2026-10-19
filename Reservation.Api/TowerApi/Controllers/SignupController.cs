using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Signup;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Helper;
using TowerApi.Services.Signup;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class SignupController : ControllerBase
    {
        private readonly ISignupService _service;
        private readonly IApiResponseFactory _responseFactory;

        public SignupController(
            ISignupService service,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _responseFactory = responseFactory;
        }

        /// <summary>
        /// ثبت‌نام با نام کاربری و رمز عبور
        /// </summary>
        [HttpPost("password")]
        public async Task<IActionResult> SignupWithPassword(
            [FromBody] SignupWithPasswordRequest request)
        {
            var requestIp = HttpContext.Connection.RemoteIpAddress?.ToString();

            var result = await _service.SignupWithPasswordAsync(
                request, requestIp);

            if (result.Code != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                    _responseFactory.Error(
                        result.Code, result.MessageKey));
            }

            return Ok(_responseFactory.Success(
                result.Code, result.MessageKey, result.Data));
        }

        /// <summary>
        /// شروع ثبت‌نام و درخواست کد تأیید پیامکی
        /// </summary>
        [HttpPost("otp/start")]
        public async Task<IActionResult> StartOtp(
            [FromBody] SignupStartOtpRequest request)
        {
            var requestIp = HttpContext.Connection.RemoteIpAddress?.ToString();
            var userAgent = Request.Headers.UserAgent.ToString();

            var result = await _service.StartOtpAsync(
                request, requestIp, userAgent);

            if (result.Code != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                    _responseFactory.Error(
                        result.Code, result.MessageKey));
            }

            return Ok(_responseFactory.Success(
                result.Code, result.MessageKey, result.Data));
        }

        /// <summary>
        /// تأیید کد و تکمیل ثبت‌نام
        /// </summary>
        [HttpPost("otp/verify")]
        public async Task<IActionResult> VerifyOtp(
            [FromBody] SignupVerifyOtpRequest request)
        {
            var result = await _service.VerifyOtpAsync(request);

            if (result.Code != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                    _responseFactory.Error(
                        result.Code, result.MessageKey));
            }

            return Ok(_responseFactory.Success(
                result.Code, result.MessageKey, result.Data));
        }
    }
}
