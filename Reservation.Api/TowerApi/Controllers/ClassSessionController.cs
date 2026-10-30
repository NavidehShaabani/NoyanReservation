using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Booking.ClassSession;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Booking.ClassSession;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/booking-class-sessions")]
    [Authorize]
    public sealed class ClassSessionController : ControllerBase
    {
        private readonly IClassSessionService _service;
        private readonly IApiResponseFactory _responseFactory;
        private readonly ICurrentUser _currentUser;

        public ClassSessionController(
            IClassSessionService service,
            IApiResponseFactory responseFactory,
            ICurrentUser currentUser)
        {
            _service = service;
            _responseFactory = responseFactory;
            _currentUser = currentUser;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetWithClassInfoAsync(id);

            return result is null
                ? NotFound(_responseFactory.Error(404, "ClassSession.NotFound"))
                : Ok(_responseFactory.Success(
                    200, "ClassSession.GetSuccessfully", result));
        }

        [HttpGet("active-list")]
        public async Task<IActionResult> GetActiveList(
            [FromQuery] long? classSeriesId)
        {
            var result = await _service.GetActiveListAsync(classSeriesId);

            return Ok(_responseFactory.Success(
                200, "ClassSession.GetSuccessfully", result));
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save(
            [FromBody] ClassSessionSaveRequest request)
        {
            var result = await _service.SaveAsync(
                request, _currentUser.UserId);

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                result.Code == 200
                    ? _responseFactory.Success(
                        result.Code, result.MessageKey, result.Data)
                    : _responseFactory.Error(
                        result.Code, result.MessageKey));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.DeleteAsync(
                id, _currentUser.UserId);

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                result.Code == 200
                    ? _responseFactory.Success(
                        result.Code, result.MessageKey,(object?)null)
                    : _responseFactory.Error(
                        result.Code, result.MessageKey));
        }
    }
}
