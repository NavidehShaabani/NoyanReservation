using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Booking.BookingParticipant;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Booking.BookingParticipant;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public sealed class BookingParticipantsController : ControllerBase
    {
        private readonly IBookingParticipantService _service;
        private readonly ICurrentUser _currentUser;
        private readonly IApiResponseFactory _responseFactory;

        public BookingParticipantsController(
            IBookingParticipantService service,
            ICurrentUser currentUser,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _currentUser = currentUser;
            _responseFactory = responseFactory;
        }

        [HttpGet("{participantId:long}")]
        public async Task<IActionResult> GetById(long participantId)
        {
            var result = await _service.GetByIdAsync(participantId);

            if (result.ResultCode != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(
                        result.ResultCode,
                        result.ResultMessage));

            return Ok(_responseFactory.Success(
                200,
                result.ResultMessage,
                result.Data));
        }

        [HttpGet("active-list")]
        public async Task<IActionResult> GetActiveList(
            [FromQuery] byte? participantType)
        {
            var result = await _service.GetActiveListAsync(
                participantType,
                _currentUser.UserId);

            if (result.ResultCode != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(
                        result.ResultCode,
                        result.ResultMessage));

            return Ok(_responseFactory.Success(
                200,
                result.ResultMessage,
                result.Data));
        }

        [HttpPost]
        public async Task<IActionResult> Save(
            [FromBody] BookingParticipantSaveRequest request)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return StatusCode(
                    401,
                    _responseFactory.Error(401, "Common.Unauthorized"));
            }

            if (userId.Value <= 0 || userId.Value > int.MaxValue)
            {
                return BadRequest(
                    _responseFactory.Error(400, "Common.InvalidUserId"));
            }

            var result = await _service.SaveAsync(
                request,
                request.UserId,
                userId);

            if (result.ResultCode != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(
                        result.ResultCode,
                        result.ResultMessage));

            return StatusCode(
                request.ParticipantId.HasValue ? 200 : 201,
                _responseFactory.Success(
                    result.ResultCode,
                    result.ResultMessage,
                    result.Data));
        }

        [HttpDelete("{participantId:long}")]
        public async Task<IActionResult> Delete(long participantId)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return StatusCode(
                    401,
                    _responseFactory.Error(401, "Common.Unauthorized"));
            }

            if (userId.Value <= 0 || userId.Value > int.MaxValue)
            {
                return BadRequest(
                    _responseFactory.Error(400, "Common.InvalidUserId"));
            }

            var result = await _service.DeleteAsync(
                participantId,
                userId);

            if (result.ResultCode != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(
                        result.ResultCode,
                        result.ResultMessage));

            return Ok(_responseFactory.Success(
                result.ResultCode,
                result.ResultMessage,
                (object?)null));
        }
    }
}
