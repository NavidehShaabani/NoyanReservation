using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.BuildingFloor;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.BuildingFloor;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BuildingFloorsController : ControllerBase
    {
        private readonly IBuildingFloorService _service;
        private readonly ICurrentUser _currentUser;
        private readonly IApiResponseFactory _responseFactory;

        public BuildingFloorsController(
            IBuildingFloorService service,
            ICurrentUser currentUser,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _currentUser = currentUser;
            _responseFactory = responseFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] BuildingFloorQueryRequest request)
        {
            var result = await _service.GetListAsync(request);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
                    result.ResultCode,
                    "Common.GetSuccessfully",
                    result.Data));
            }

            return CreateErrorResponse(
                result.ResultCode,
                result.MessageKey);
        }

        [HttpGet("{buildingFloorId:long}")]
        public async Task<IActionResult> GetById(long buildingFloorId)
        {
            var result = await _service.GetByIdAsync(buildingFloorId);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
                    result.ResultCode,
                    "Common.GetSuccessfully",
                    result.Data));
            }

            return CreateErrorResponse(
                result.ResultCode,
                result.MessageKey);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] BuildingFloorCreateRequest request)
        {
            if (!TryGetCurrentUserId(out var userId, out var error))
                return error!;

            var result = await _service.AddAsync(request, userId);

            if (result.ResultCode == 200 ||
                result.ResultCode == 201)
            {
                return StatusCode(
                    result.ResultCode,
                    _responseFactory.Success(
                        result.ResultCode,
                        "Common.CreatedSuccessfully",
                        result.Data));
            }

            return CreateErrorResponse(
                result.ResultCode,
                result.MessageKey);
        }

        [HttpPut("{buildingFloorId:long}")]
        public async Task<IActionResult> Update(
            long buildingFloorId,
            [FromBody] BuildingFloorUpdateRequest request)
        {
            if (!TryGetCurrentUserId(out var userId, out var error))
                return error!;

            var result = await _service.EditAsync(
                buildingFloorId,
                request,
                userId);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
                    result.ResultCode,
                    "Common.UpdatedSuccessfully",
                    result.Data));
            }

            return CreateErrorResponse(
                result.ResultCode,
                result.MessageKey);
        }

        [HttpDelete("{buildingFloorId:long}")]
        public async Task<IActionResult> Delete(long buildingFloorId)
        {
            if (!TryGetCurrentUserId(out var userId, out var error))
                return error!;

            var result = await _service.DeleteAsync(
                buildingFloorId,
                userId);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
                    result.ResultCode,
                    "Common.DeletedSuccessfully",
                    (object?)null));
            }

            return CreateErrorResponse(
                result.ResultCode,
                result.MessageKey);
        }

        [HttpPost("BulkSave")]
        public async Task<IActionResult> BulkSave(
            [FromBody] BuildingFloorBulkSaveRequest request)
        {
            if (!_currentUser.UserId.HasValue)
            {
                return CreateErrorResponse(
                    401,
                    "Common.Unauthorized");
            }

            if (_currentUser.UserId.Value <= 0 ||
                _currentUser.UserId.Value > int.MaxValue)
            {
                return CreateErrorResponse(
                    400,
                    "Common.InvalidUserId");
            }

            var result = await _service.BulkSaveAsync(
                request,
                _currentUser.UserId.Value);

            if (result.Code == 200 || result.Code == 201)
            {
                return StatusCode(
                    result.Code,
                    _responseFactory.Success(
                        result.Code,
                        result.MessageKey,
                        (object?)null));
            }

            return CreateErrorResponse(
                result.Code,
                result.MessageKey);
        }

        private bool TryGetCurrentUserId(
            out int userId,
            out IActionResult? error)
        {
            userId = 0;
            error = null;

            if (!_currentUser.UserId.HasValue)
            {
                error = CreateErrorResponse(
                    401,
                    "Common.Unauthorized");

                return false;
            }

            var currentUserId = _currentUser.UserId.Value;

            if (currentUserId <= 0 || currentUserId > int.MaxValue)
            {
                error = CreateErrorResponse(
                    400,
                    "Common.InvalidUserId");

                return false;
            }

            userId = (int)currentUserId;
            return true;
        }

        private IActionResult CreateErrorResponse(
            int resultCode,
            string? messageKey)
        {
            var key = !string.IsNullOrWhiteSpace(messageKey)
                ? messageKey
                : ApiResponseMessageMapper.GetMessageKey(resultCode);

            var statusCode =
                ApiResponseMessageMapper.GetHttpStatusCode(resultCode);

            return StatusCode(
                statusCode,
                _responseFactory.Error(resultCode, key));
        }
    }
}
