using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Building;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Building;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingService _service;
        private readonly ICurrentUser _currentUser;
        private readonly IApiResponseFactory _responseFactory;

        public BuildingsController(
            IBuildingService service,
            ICurrentUser currentUser,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _currentUser = currentUser;
            _responseFactory = responseFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] BuildingQueryRequest request)
        {
            var result =
                await _service.GetListAsync(request);

            if (result.ResultCode == 200)
            {
                return Ok(
                    _responseFactory.Success(
                        200,
                        "Common.GetSuccessfully",
                        result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(
                    result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    ApiResponseMessageMapper.GetMessageKey(
                        result.ResultCode)));
        }

        [HttpGet("{buildingId:long}")]
        public async Task<IActionResult> GetById(
            long buildingId,
            [FromQuery] bool includeDeleted = false)
        {
            var result =
                await _service.GetByIdAsync(
                    buildingId,
                    includeDeleted);

            if (result.ResultCode == 200)
            {
                return Ok(
                    _responseFactory.Success(
                        200,
                        "Common.GetSuccessfully",
                        result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(
                    result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    ApiResponseMessageMapper.GetMessageKey(
                        result.ResultCode)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] BuildingCreateRequest request)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Common.Unauthorized"));
            }

            if (userId.Value > int.MaxValue)
            {
                return BadRequest(
                    _responseFactory.Error(
                        400,
                        "Common.InvalidUserId"));
            }

            var result =
                await _service.AddAsync(
                    request,
                    (int)userId.Value);

            if (result.ResultCode == 200)
            {
                return Ok(
                    _responseFactory.Success(
                        200,
                        "Common.CreatedSuccessfully",
                        result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(
                    result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    ApiResponseMessageMapper.GetMessageKey(
                        result.ResultCode)));
        }

        [HttpPut("{buildingId:long}")]
        public async Task<IActionResult> Update(
            long buildingId,
            [FromBody] BuildingUpdateRequest request)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Common.Unauthorized"));
            }

            if (userId.Value > int.MaxValue)
            {
                return BadRequest(
                    _responseFactory.Error(
                        400,
                        "Common.InvalidUserId"));
            }

            var result =
                await _service.EditAsync(
                    buildingId,
                    request,
                    (int)userId.Value);

            if (result.ResultCode == 200)
            {
                return Ok(
                    _responseFactory.Success(
                        200,
                        "Common.UpdatedSuccessfully",
                        result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(
                    result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    ApiResponseMessageMapper.GetMessageKey(
                        result.ResultCode)));
        }

        [HttpDelete("{buildingId:long}")]
        public async Task<IActionResult> Delete(
            long buildingId)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Common.Unauthorized"));
            }

            if (userId.Value > int.MaxValue)
            {
                return BadRequest(
                    _responseFactory.Error(
                        400,
                        "Common.InvalidUserId"));
            }

            var result =
                await _service.DeleteAsync(
                    buildingId,
                    (int)userId.Value);

            if (result.ResultCode == 200)
            {
                return Ok(
                    _responseFactory.Success<object>(
                        200,
                        "Common.DeletedSuccessfully"));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(
                    result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    ApiResponseMessageMapper.GetMessageKey(
                        result.ResultCode)));
        }
    }
}