
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.BuildingFloorStaircase;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.BuildingFloorStaircase;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BuildingFloorStaircaseController : ControllerBase
    {
        private readonly IBuildingFloorStaircaseService _service;
        private readonly ICurrentUser _currentUser;
        private readonly IApiResponseFactory _responseFactory;

        public BuildingFloorStaircaseController(
            IBuildingFloorStaircaseService service,
            ICurrentUser currentUser,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _currentUser = currentUser;
            _responseFactory = responseFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] BuildingFloorStaircaseQueryRequest request)
        {
            var result = await _service.GetListAsync(request);

            return CreateResponse(
                result.ResultCode, result.MessageKey, result.Data);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);

            return CreateResponse(
                result.ResultCode, result.MessageKey, result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] BuildingFloorStaircaseCreateRequest request)
        {
            if (!TryGetCurrentUserId(out var userId, out var error))
                return error!;

            var result = await _service.AddAsync(request, userId);

            return CreateResponse(
                result.ResultCode, result.MessageKey, result.Data);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Edit(
            long id,
            [FromBody] BuildingFloorStaircaseUpdateRequest request)
        {
            if (!TryGetCurrentUserId(out var userId, out var error))
                return error!;

            var result = await _service.EditAsync(id, request, userId);

            return CreateResponse(
                result.ResultCode, result.MessageKey, result.Data);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (!TryGetCurrentUserId(out var userId, out var error))
                return error!;

            var result = await _service.DeleteAsync(id, userId);

            return CreateResponse(
                result.ResultCode, result.MessageKey, null);
        }

        [HttpPost("bulk-save")]
        public async Task<IActionResult> BulkSave(
            [FromBody] BuildingFloorStaircaseBulkSaveRequest request)
        {
            var currentUserId = _currentUser.UserId;

            if (!currentUserId.HasValue ||
                currentUserId.Value <= 0 ||
                currentUserId.Value > int.MaxValue)
            {
                return CreateResponse(
                    400, "Common.InvalidUserId", null);
            }

            var result = await _service.BulkSaveAsync(
                request, currentUserId.Value);

            return CreateResponse(
                result.Code, result.MessageKey, null);
        }

        private bool TryGetCurrentUserId(
            out int userId, out IActionResult? error)
        {
            userId = 0;
            error = null;

            var currentUserId = _currentUser.UserId;

            if (!currentUserId.HasValue ||
                currentUserId.Value <= 0 ||
                currentUserId.Value > int.MaxValue)
            {
                error = CreateResponse(
                    400, "Common.InvalidUserId", null);

                return false;
            }

            userId = (int)currentUserId.Value;
            return true;
        }

        private IActionResult CreateResponse(
            int resultCode, string? messageKey, object? data)
        {
            var key = string.IsNullOrWhiteSpace(messageKey)
                ? ApiResponseMessageMapper.GetMessageKey(resultCode)
                : messageKey;

            var statusCode =
                ApiResponseMessageMapper.GetHttpStatusCode(resultCode);

            if (resultCode >= 200 && resultCode < 300)
            {
                var response = _responseFactory.Success(
                    resultCode, key, data);

                return StatusCode(statusCode, response);
            }

            var errorResponse = _responseFactory.Error(resultCode, key);

            return StatusCode(statusCode, errorResponse);
        }
    }
}
