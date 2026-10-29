using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Booking.SpaceBooking;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Booking.SpaceBooking;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SpaceBookingsController : ControllerBase
    {
        private readonly ISpaceBookingService _service;
        private readonly ICurrentUser _currentUser;
        private readonly IApiResponseFactory _responseFactory;

        public SpaceBookingsController(
            ISpaceBookingService service,
            ICurrentUser currentUser,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _currentUser = currentUser;
            _responseFactory = responseFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] SpaceBookingQueryRequest request)
        {
            var result = await _service.GetListAsync(request);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
                    200,
                    "Common.GetSuccessfully",
                    result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    GetMessageKey(result.ResultCode)));
        }

        [HttpGet("{bookingId:long}")]
        public async Task<IActionResult> GetById(long bookingId)
        {
            var result = await _service.GetByIdAsync(bookingId);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
                    200,
                    "Common.GetSuccessfully",
                    result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    GetMessageKey(result.ResultCode)));
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] SpaceBookingCreateRequest request)
        {
            if (!TryGetAuditUserId(out var userId, out var errorResult))
                return errorResult!;

            var result = await _service.AddAsync(request, userId);

            if (result.ResultCode == 200)
            {
                return StatusCode(
                    StatusCodes.Status200OK,
                    _responseFactory.Success(
                        200,
                        "Common.CreatedSuccessfully",
                        result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    GetMessageKey(result.ResultCode)));
        }

        [HttpPut("{bookingId:long}")]
        public async Task<IActionResult> Edit(
            long bookingId,
            [FromBody] SpaceBookingUpdateRequest request)
        {
            if (!TryGetAuditUserId(out var userId, out var errorResult))
                return errorResult!;

            var result = await _service.EditAsync(
                bookingId,
                request,
                userId);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
                    200,
                    "Common.UpdatedSuccessfully",
                    result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    GetMessageKey(result.ResultCode)));
        }

        [HttpPost("check-conflict")]
        public async Task<IActionResult> CheckConflict(
            [FromBody] SpaceBookingConflictRequest request)
        {
            var result = await _service.CheckConflictAsync(request);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
                    200,
                    "Booking.Space.NoConflict",
                    result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    GetMessageKey(result.ResultCode)));
        }

        [HttpPost("{bookingId:long}/approve")]
        public async Task<IActionResult> Approve(long bookingId)
        {
            if (!TryGetAuditUserId(out var userId, out var errorResult))
                return errorResult!;

            var result = await _service.ApproveAsync(bookingId, userId);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
                    200,
                    "Booking.Space.ApprovedSuccessfully",
                    result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    GetMessageKey(result.ResultCode)));
        }

        [HttpPost("{bookingId:long}/cancel")]
        public async Task<IActionResult> Cancel(long bookingId)
        {
            if (!TryGetAuditUserId(out var userId, out var errorResult))
                return errorResult!;

            var result = await _service.CancelAsync(bookingId, userId);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
                    200,
                    "Booking.Space.CancelledSuccessfully",
                    result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    GetMessageKey(result.ResultCode)));
        }

        [HttpDelete("{bookingId:long}")]
        public async Task<IActionResult> Delete(long bookingId)
        {
            if (!TryGetAuditUserId(out var userId, out var errorResult))
                return errorResult!;

            var result = await _service.DeleteAsync(bookingId, userId);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success<object>(
                    200,
                    "Common.DeletedSuccessfully"));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    GetMessageKey(result.ResultCode)));
        }

        private bool TryGetAuditUserId(
            out int userId,
            out IActionResult? errorResult)
        {
            userId = 0;
            errorResult = null;

            var currentUserId = _currentUser.UserId;

            if (!currentUserId.HasValue || currentUserId.Value <= 0)
            {
                errorResult = StatusCode(
                    StatusCodes.Status401Unauthorized,
                    _responseFactory.Error(401, "Common.Unauthorized"));

                return false;
            }

            if (currentUserId.Value > int.MaxValue)
            {
                errorResult = BadRequest(
                    _responseFactory.Error(400, "Common.InvalidUserId"));

                return false;
            }

            userId = (int)currentUserId.Value;
            return true;
        }

        private static string GetMessageKey(int resultCode)
        {
            return resultCode switch
            {
                409 => "Booking.Space.ConflictFound",
                400 => "Booking.Space.InvalidRequest",
                404 => "Common.NotFound",
                401 => "Common.Unauthorized",
                403 => "Common.Forbidden",
                _ => ApiResponseMessageMapper.GetMessageKey(resultCode)
            };
        }
    }
}
