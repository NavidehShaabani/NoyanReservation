using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Organization;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Helper;
using TowerApi.Services.Organization;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _service;
        private readonly ICurrentUser _currentUser;
        private readonly IApiResponseFactory _responseFactory;

        public OrganizationsController(
            IOrganizationService service,
            ICurrentUser currentUser,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _currentUser = currentUser;
            _responseFactory = responseFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] OrganizationQueryRequest request)
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

        [HttpGet("{orgId:long}")]
        public async Task<IActionResult> GetById(
            long orgId,
            [FromQuery] bool includeDeleted = false)
        {
            var result =
                await _service.GetByIdAsync(
                    orgId,
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
            [FromBody] OrganizationCreateRequest request)
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

        [HttpPut("{orgId:long}")]
        public async Task<IActionResult> Update(
            long orgId,
            [FromBody] OrganizationUpdateRequest request)
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
                    orgId,
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

        [HttpDelete("{orgId:long}")]
        public async Task<IActionResult> Delete(
            long orgId)
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
                    orgId,
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