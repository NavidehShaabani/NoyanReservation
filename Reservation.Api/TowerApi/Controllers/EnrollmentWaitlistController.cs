using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Enrollment.EnrollmentWaitlist;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Enrollment.EnrollmentWaitlist;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/enrollment-waitlist")]
    [Authorize]
    public class EnrollmentWaitlistController : ControllerBase
    {
        private readonly IEnrollmentWaitlistService _service;
        private readonly IApiResponseFactory _responseFactory;
        private readonly ICurrentUser _currentUser;

        public EnrollmentWaitlistController(
            IEnrollmentWaitlistService service,
            IApiResponseFactory responseFactory,
            ICurrentUser currentUser)
        {
            _service = service;
            _responseFactory = responseFactory;
            _currentUser = currentUser;
        }

        // دریافت یک مورد از لیست انتظار
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetById(id);

            if (result == null)
            {
                return StatusCode(
                    404,
                    _responseFactory.Error(
                        404,
                        "EnrollmentWaitlist.NotFound"));
            }

            return Ok(
                _responseFactory.Success(
                    200,
                    "EnrollmentWaitlist.GetSuccessfully",
                    result));
        }

        // دریافت فهرست انتظار
        [HttpPost("list")]
        public async Task<IActionResult> GetList(
            [FromBody] EnrollmentWaitlistQuery query)
        {
            var result = await _service.GetList(query);

            return Ok(
                _responseFactory.Success(
                    200,
                    "EnrollmentWaitlist.GetSuccessfully",
                    result));
        }

        // عضویت در لیست انتظار
        [HttpPost("join")]
        public async Task<IActionResult> Join(
            [FromBody] EnrollmentWaitlistJoinRequest request)
        {
            var result = await _service.Join(
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

        // تغییر وضعیت عضو لیست انتظار
        [HttpPut("{id:long}/status")]
        public async Task<IActionResult> UpdateStatus(
            long id,
            [FromBody] EnrollmentWaitlistUpdateStatusRequest request)
        {
            var result = await _service.UpdateStatus(
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
    }
}
