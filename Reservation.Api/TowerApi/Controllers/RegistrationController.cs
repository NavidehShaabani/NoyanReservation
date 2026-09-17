using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Registration;
using TowerApi.Repositories.Registration;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/registration")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        private readonly IApiResponseFactory _responseFactory;

        public RegistrationController(
            IRegistrationService registrationService,
            IApiResponseFactory responseFactory)
        {
            _registrationService = registrationService;
            _responseFactory = responseFactory;
        }

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

            if (result.ResultCode == 200)
            {
                return Ok(
                    _responseFactory.Success(
                        200,
                        "Common.CreatedSuccessfully",
                        result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(
                    result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    ApiResponseMessageMapper.GetMessageKey(
                        result.ResultCode)));
        }

        [AllowAnonymous]
        [HttpPost("mobile/verify")]
        public async Task<IActionResult> VerifyMobileOtp(
            [FromBody] VerifyOtpRequest request)
        {
            var result =
                await _registrationService.VerifyOtpAsync(
                    request);

            if (result.ResultCode == 200)
            {
                return Ok(
                    _responseFactory.Success(
                        200,
                        "Common.UpdatedSuccessfully",
                        result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(
                    result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    ApiResponseMessageMapper.GetMessageKey(
                        result.ResultCode)));
        }

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

            if (result.ResultCode == 200)
            {
                return Ok(
                    _responseFactory.Success(
                        200,
                        "Common.CreatedSuccessfully",
                        result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(
                    result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    ApiResponseMessageMapper.GetMessageKey(
                        result.ResultCode)));
        }
    }

}
