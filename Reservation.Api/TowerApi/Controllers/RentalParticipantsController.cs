using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Booking.RentalParticipants;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Booking.RentalParticipants;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/booking/rental-participants")]
    [Authorize]
    public class RentalParticipantsController : ControllerBase
    {
        private readonly IRentalParticipantsService _service;
        private readonly IApiResponseFactory _responseFactory;

        public RentalParticipantsController(
            IRentalParticipantsService service,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _responseFactory = responseFactory;
        }

        [HttpGet("{rentalParticipantId:long}")]
        public async Task<IActionResult> GetById(long rentalParticipantId)
        {
            var result = await _service.GetByIdAsync(rentalParticipantId);

            if (result.ResultCode != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(result.ResultCode, result.ResultMessage));

            return Ok(_responseFactory.Success(
                200, result.ResultMessage, result.Data));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] RentalParticipantQueryRequest request)
        {
            var result = await _service.GetListAsync(request);

            if (result.ResultCode != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(result.ResultCode, result.ResultMessage));

            return Ok(_responseFactory.Success(
                200, result.ResultMessage, result.Data));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] RentalParticipantSaveRequest request)
        {
            var result = await _service.SaveAsync(request);

            if (result.ResultCode != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(result.ResultCode, result.ResultMessage));

            return Ok(_responseFactory.Success(
                200, result.ResultMessage, result.Data));
        }

        [HttpDelete("{rentalParticipantId:long}")]
        public async Task<IActionResult> Delete(long rentalParticipantId)
        {
            var result = await _service.DeleteAsync(rentalParticipantId);

            if (result.ResultCode != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(result.ResultCode, result.ResultMessage));

            return Ok(_responseFactory.Success(
                200, result.ResultMessage, result.Data));
        }
    }
}
