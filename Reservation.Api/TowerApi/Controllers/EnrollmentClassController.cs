using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Enrollment;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Enrollment;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/enrollment-class")]
    [Authorize]
    public class EnrollmentClassController : ControllerBase
    {
        private readonly IEnrollmentClassService _service;
        private readonly IApiResponseFactory _responseFactory;
        private readonly ICurrentUser _currentUser;

        public EnrollmentClassController(
            IEnrollmentClassService service,
            IApiResponseFactory responseFactory,
            ICurrentUser currentUser)
        {
            _service = service;
            _responseFactory = responseFactory;
            _currentUser = currentUser;
        }

        // دریافت ثبت‌نام با شناسه
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            if (id <= 0)
            {
                return StatusCode(
                    400,
                    _responseFactory.Error(
                        400,
                        "EnrollmentClass.InvalidData"));
            }

            var result = await _service.GetById(id);

            if (result == null)
            {
                return StatusCode(
                    404,
                    _responseFactory.Error(
                        404,
                        "EnrollmentClass.NotFound"));
            }

            return Ok(
                _responseFactory.Success(
                    200,
                    "EnrollmentClass.GetSuccessfully",
                    result));
        }

        // دریافت فهرست ثبت‌نام‌ها
        [HttpGet("list")]
        public async Task<IActionResult> GetList(
            [FromQuery] EnrollmentClassQuery query)
        {
            var result = await _service.GetList(query);

            return Ok(
                _responseFactory.Success(
                    200,
                    "EnrollmentClass.GetSuccessfully",
                    result));
        }

        // ثبت‌نام در کلاس
        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromBody] EnrollmentClassRegisterRequest request)
        {
            var result = await _service.Register(
                request,
                _currentUser.UserId);

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                result.Code == 200
                    ? _responseFactory.Success(
                        result.Code,
                        result.MessageKey,
                        result.Data)
                    : _responseFactory.Error(
                        result.Code,
                        result.MessageKey));
        }

        // بررسی ظرفیت جلسه
        [HttpGet("session/{classSessionId:long}/capacity")]
        public async Task<IActionResult> CheckCapacity(
            long classSessionId)
        {
            var result = await _service.CheckCapacity(
                classSessionId);

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                result.Code == 200
                    ? _responseFactory.Success(
                        result.Code,
                        result.MessageKey,
                        result.Data)
                    : _responseFactory.Error(
                        result.Code,
                        result.MessageKey));
        }

        // لغو ثبت‌نام
        [HttpPost("{id:long}/cancel")]
        public async Task<IActionResult> Cancel(
            long id,
            [FromBody] EnrollmentClassCancelRequest request)
        {
            var result = await _service.Cancel(
                id,
                request,
                _currentUser.UserId);

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                result.Code == 200
                    ? _responseFactory.Success(
                        result.Code,
                        result.MessageKey,
                        result.Data)
                    : _responseFactory.Error(
                        result.Code,
                        result.MessageKey));
        }

        // تغییر وضعیت پرداخت
        [HttpPatch("{id:long}/payment-status")]
        public async Task<IActionResult> SetPaymentStatus(
            long id,
            [FromBody] EnrollmentClassPaymentStatusRequest request)
        {
            var result = await _service.SetPaymentStatus(
                id,
                request.PaymentStatus,
                _currentUser.UserId);

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                result.Code == 200
                    ? _responseFactory.Success(
                        result.Code,
                        result.MessageKey,
                        result.Data)
                    : _responseFactory.Error(
                        result.Code,
                        result.MessageKey));
        }
    }
}
