using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.BuildingElevators;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.BuildingElevators;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BuildingElevatorController : ControllerBase
    {
        private readonly IBuildingElevatorService _service;
        private readonly ICurrentUser _currentUser;
        private readonly IApiResponseFactory _responseFactory;

        public BuildingElevatorController(
            IBuildingElevatorService service,
            ICurrentUser currentUser,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _currentUser = currentUser;
            _responseFactory = responseFactory;
        }

        private IActionResult BuildResponse(
            int resultCode,
            string? messageKey,
            object? data = null)
        {
            var key = !string.IsNullOrWhiteSpace(messageKey)
                ? messageKey
                : ApiResponseMessageMapper.GetMessageKey(resultCode);

            var httpStatus = ApiResponseMessageMapper.GetHttpStatusCode(resultCode);

            if (resultCode >= 200 && resultCode < 300)
                return StatusCode(httpStatus,
                    _responseFactory.Success(resultCode, key!, data));

            return StatusCode(httpStatus,
                _responseFactory.Error(resultCode, key!));
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] BuildingElevatorCreateRequest request)
        {
            var result = await _service.AddAsync(request, _currentUser.UserId);

            return BuildResponse(
                result.ResultCode,
                result.MessageKey,
                result.Data);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Edit(
            long id,
            [FromBody] BuildingElevatorUpdateRequest request)
        {
            var result = await _service.EditAsync(
                id, request, _currentUser.UserId);

            return BuildResponse(
                result.ResultCode,
                result.MessageKey,
                result.Data);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.DeleteAsync(
                id, _currentUser.UserId);

            return BuildResponse(
                result.ResultCode,
                result.MessageKey);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(
            long id,
            [FromQuery] bool includeDeleted = false)
        {
            var result = await _service.GetByIdAsync(id, includeDeleted);

            return BuildResponse(
                result.ResultCode,
                result.MessageKey,
                result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] BuildingElevatorQueryRequest request)
        {
            var result = await _service.GetListAsync(request);

            return BuildResponse(
                result.ResultCode,
                result.MessageKey,
                result.Data);
        }

        [HttpPost("bulk-save")]
        public async Task<IActionResult> BulkSave(
            [FromBody] BuildingElevatorBulkSaveRequest request)
        {
            var result = await _service.BulkSaveAsync(
                request, _currentUser.UserId ?? 0);

            return BuildResponse(result.Code, result.MessageKey);
        }
    }
}
