using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Unit;
using TowerApi.Repositories.Unit;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Helper;
using TowerApi.Services.Unit;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitService _service;
        private readonly ICurrentUser _currentUser;
        private readonly IApiResponseFactory _responseFactory;

        public UnitsController(
            IUnitService service,
            ICurrentUser currentUser,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _currentUser = currentUser;
            _responseFactory = responseFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] UnitQueryRequest request)
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

        [HttpGet("{unitId:long}")]
        public async Task<IActionResult> GetById(
            long unitId,
            [FromQuery] bool includeDeleted = false)
        {
            var result =
                await _service.GetByIdAsync(
                    unitId,
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
            [FromBody] UnitCreateRequest request)
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

        [HttpPut("{unitId:long}")]
        public async Task<IActionResult> Update(
            long unitId,
            [FromBody] UnitUpdateRequest request)
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
                    unitId,
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

        [HttpDelete("{unitId:long}")]
        public async Task<IActionResult> Delete(
            long unitId)
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
                    unitId,
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
