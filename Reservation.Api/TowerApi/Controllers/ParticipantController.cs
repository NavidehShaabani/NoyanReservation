using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Booking.Participant;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Booking.Participant;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/booking-participants")]
    [Authorize]
    public sealed class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _service;
        private readonly IApiResponseFactory _responseFactory;
        private readonly ICurrentUser _currentUser;

        public ParticipantController(
            IParticipantService service,
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
            var result = await _service.GetByIdAsync(id);

            if (result is null)
                return NotFound(_responseFactory.Error(
                    404, "Participant.NotFound"));

            return Ok(_responseFactory.Success(
                200, "Participant.GetSuccessfully", result));
        }

        [HttpGet("active-list")]
        public async Task<IActionResult> GetActiveList(
            [FromQuery] byte? participantType,
            [FromQuery] long? userId)
        {
            var result = await _service.GetActiveListAsync(
                participantType, userId);

            return Ok(_responseFactory.Success(
                200, "Participant.GetSuccessfully", result));
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save(
            [FromBody] ParticipantSaveRequest request)
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
