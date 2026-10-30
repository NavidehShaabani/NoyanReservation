using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Booking.HallRentalDetails;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Booking.HallRentalDetails;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public sealed class HallRentalDetailsController : ControllerBase
    {
        private readonly IHallRentalDetailsService _service;
        private readonly ICurrentUser _currentUser;
        private readonly IApiResponseFactory _responseFactory;

        public HallRentalDetailsController(
            IHallRentalDetailsService service,
            ICurrentUser currentUser,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _currentUser = currentUser;
            _responseFactory = responseFactory;
        }

        [HttpGet("{bookingId:long}")]
        public async Task<IActionResult> GetById(long bookingId)
        {
            var result = await _service.GetByIdAsync(bookingId);

            if (result.ResultCode != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(
                        result.ResultCode,
                        result.ResultMessage));
            }

            return Ok(_responseFactory.Success(
                200,
                result.ResultMessage,
                result.Data));
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] HallRentalDetailsQueryRequest request)
        {
            var result = await _service.GetListAsync(request);

            if (result.ResultCode != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(
                        result.ResultCode,
                        result.ResultMessage));
            }

            return Ok(_responseFactory.Success(
                200,
                result.ResultMessage,
                result.Data));
        }

        [HttpPost]
        public async Task<IActionResult> Save(
            [FromBody] HallRentalDetailsSaveRequest request)
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

            var result = await _service.SaveAsync(request, userId);

            if (result.ResultCode != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(
                        result.ResultCode,
                        result.ResultMessage));
            }

            return Ok(_responseFactory.Success(
                200,
                result.ResultMessage,
                result.Data));
        }

        [HttpDelete("{bookingId:long}")]
        public async Task<IActionResult> Delete(long bookingId)
        {
            var result = await _service.DeleteAsync(bookingId);

            if (result.ResultCode != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(
                        result.ResultCode,
                        result.ResultMessage));
            }

            return Ok(_responseFactory.Success(
                200,
                result.ResultMessage,
                (object?)null));
        }
    }
}
