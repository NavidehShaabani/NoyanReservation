
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.BuildingConfiguration;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.BuildingConfiguration;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BuildingConfigurationsController : ControllerBase
    {
        private readonly IBuildingConfigurationService _service;
        private readonly ICurrentUser _currentUser;
        private readonly IApiResponseFactory _responseFactory;

        public BuildingConfigurationsController(
            IBuildingConfigurationService service,
            ICurrentUser currentUser,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _currentUser = currentUser;
            _responseFactory = responseFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] BuildingConfigurationQueryRequest request)
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
                    ApiResponseMessageMapper.GetMessageKey(result.ResultCode)));
        }

        [HttpGet("{buildingConfigurationId:long}")]
        public async Task<IActionResult> GetById(
            long buildingConfigurationId,
            [FromQuery] bool includeDeleted = false)
        {
            var result = await _service.GetByIdAsync(
                buildingConfigurationId,
                includeDeleted);

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
                    ApiResponseMessageMapper.GetMessageKey(result.ResultCode)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] BuildingConfigurationCreateRequest request)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(
                    _responseFactory.Error(401, "Common.Unauthorized"));
            }

            if (userId.Value <= 0 || userId.Value > int.MaxValue)
            {
                return BadRequest(
                    _responseFactory.Error(400, "Common.InvalidUserId"));
            }

            var result = await _service.AddAsync(request, (int)userId.Value);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
                    200,
                    "Common.CreatedSuccessfully",
                    result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    ApiResponseMessageMapper.GetMessageKey(result.ResultCode)));
        }

        [HttpPut("{buildingConfigurationId:long}")]
        public async Task<IActionResult> Update(
            long buildingConfigurationId,
            [FromBody] BuildingConfigurationUpdateRequest request)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(
                    _responseFactory.Error(401, "Common.Unauthorized"));
            }

            if (userId.Value <= 0 || userId.Value > int.MaxValue)
            {
                return BadRequest(
                    _responseFactory.Error(400, "Common.InvalidUserId"));
            }

            var result = await _service.EditAsync(
                buildingConfigurationId,
                request,
                (int)userId.Value);

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
                    ApiResponseMessageMapper.GetMessageKey(result.ResultCode)));
        }

        [HttpDelete("{buildingConfigurationId:long}")]
        public async Task<IActionResult> Delete(long buildingConfigurationId)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(
                    _responseFactory.Error(401, "Common.Unauthorized"));
            }

            if (userId.Value <= 0 || userId.Value > int.MaxValue)
            {
                return BadRequest(
                    _responseFactory.Error(400, "Common.InvalidUserId"));
            }

            var result = await _service.DeleteAsync(
                buildingConfigurationId,
                (int)userId.Value);

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
                    ApiResponseMessageMapper.GetMessageKey(result.ResultCode)));
        }

        [HttpPost("BulkSave")]
        public async Task<IActionResult> BulkSave(
            [FromBody] BuildingConfigurationBulkSaveRequest request)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(
                    _responseFactory.Error(401, "Common.Unauthorized"));
            }

            if (userId.Value <= 0 || userId.Value > int.MaxValue)
            {
                return BadRequest(
                    _responseFactory.Error(400, "Common.InvalidUserId"));
            }

            var result = await _service.BulkSaveAsync(
                request,
                userId.Value);

            if (result.Code == 200)
            {
                return Ok(_responseFactory.Success<object>(
                    200,
                    result.MessageKey,
                    null));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                _responseFactory.Error(result.Code, result.MessageKey));
        }
    }
}
