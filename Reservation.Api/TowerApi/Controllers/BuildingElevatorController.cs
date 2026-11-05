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
    public class BuildingElevatorsController : ControllerBase
    {
        private readonly IBuildingElevatorService _service;
        private readonly ICurrentUser _currentUser;
        private readonly IApiResponseFactory _responseFactory;

        public BuildingElevatorsController(
            IBuildingElevatorService service,
            ICurrentUser currentUser,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _currentUser = currentUser;
            _responseFactory = responseFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] BuildingElevatorCreateRequest request)
        {
            var result = await _service.AddAsync(
                request,
                _currentUser.UserId ?? 0);

            return CreateResponse(
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
                id,
                request,
                _currentUser.UserId ?? 0);

            return CreateResponse(
                result.ResultCode,
                result.MessageKey,
                result.Data);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(
            long id,
            [FromQuery] long buildingId)
        {
            var result = await _service.GetByIdAsync(id, buildingId);

            return CreateResponse(
                result.ResultCode,
                result.MessageKey,
                result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] BuildingElevatorQueryRequest request)
        {
            var result = await _service.GetListAsync(request);

            return CreateResponse(
                result.ResultCode,
                result.MessageKey,
                result.Data);
        }

        [HttpPost("bulk-save")]
        public async Task<IActionResult> BulkSave(
            [FromBody] BuildingElevatorBulkSaveRequest request)
        {
            var result = await _service.BulkSaveAsync(
                request,
                _currentUser.UserId ?? 0);

            return CreateResponse(
                result.ResultCode,
                result.MessageKey);
        }

        [HttpPatch("{id:long}/active")]
        public async Task<IActionResult> SetActive(
            long id,
            [FromQuery] long buildingId,
            [FromBody] BuildingElevatorActiveRequest request)
        {
            var result = await _service.SetActiveAsync(
                id,
                buildingId,
                request.IsActive,
                _currentUser.UserId ?? 0);

            return CreateResponse(
                result.ResultCode,
                result.MessageKey);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(
            long id,
            [FromQuery] long buildingId)
        {
            var result = await _service.DeleteAsync(
                id,
                buildingId,
                _currentUser.UserId ?? 0);

            return CreateResponse(
                result.ResultCode,
                result.MessageKey);
        }

        private IActionResult CreateResponse(
            int resultCode,
            string messageKey,
            object? data = null)
        {
            if (resultCode >= 200 && resultCode < 300)
            {
                return StatusCode(
                    resultCode,
                    _responseFactory.Success(
                        resultCode,
                        messageKey,
                        data));
            }

            return StatusCode(
                GetHttpStatusCode(resultCode),
                _responseFactory.Error(
                    resultCode,
                    messageKey));
        }

        private static int GetHttpStatusCode(int resultCode)
        {
            return resultCode switch
            {
                400 => StatusCodes.Status400BadRequest,
                401 => StatusCodes.Status401Unauthorized,
                403 => StatusCodes.Status403Forbidden,
                404 => StatusCodes.Status404NotFound,
                409 => StatusCodes.Status409Conflict,
                422 => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}
