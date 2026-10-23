using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Spaces;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Helper;
using TowerApi.Services.Spaces;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SpacesController : ControllerBase
    {
        private readonly ISpaceService _service;
        private readonly ICurrentUser _currentUser;
        private readonly IApiResponseFactory _responseFactory;

        public SpacesController(
            ISpaceService service,
            ICurrentUser currentUser,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _currentUser = currentUser;
            _responseFactory = responseFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] SpaceQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _service.GetAsync(
                request,
                cancellationToken);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
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

        [HttpGet("{spaceId:long}")]
        public async Task<IActionResult> GetById(
            long spaceId,
            CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(
                spaceId,
                cancellationToken);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
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
            [FromBody] SpaceSave request,
            CancellationToken cancellationToken)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Common.Unauthorized"));
            }

            var result = await _service.InsertAsync(
                request,
                userId,
                cancellationToken);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
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

        [HttpPut("{spaceId:long}")]
        public async Task<IActionResult> Update(
            long spaceId,
            [FromBody] SpaceSave request,
            CancellationToken cancellationToken)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Common.Unauthorized"));
            }

            var result = await _service.UpdateAsync(
                spaceId,
                request,
                userId,
                cancellationToken);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
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

        [HttpPost("bulk-save")]
        public async Task<IActionResult> BulkSave(
            [FromBody] SpaceBulkSave request,
            CancellationToken cancellationToken)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Common.Unauthorized"));
            }

            var result = await _service.BulkSaveAsync(
                request,
                userId,
                cancellationToken);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success(
                    200,
                    "Common.SavedSuccessfully",
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

        [HttpDelete("{spaceId:long}")]
        public async Task<IActionResult> Delete(
            long spaceId,
            CancellationToken cancellationToken)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Common.Unauthorized"));
            }

            var result = await _service.DeleteAsync(
                spaceId,
                userId,
                cancellationToken);

            if (result.ResultCode == 200)
            {
                return Ok(_responseFactory.Success<object>(
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

        [HttpPatch("{spaceId:long}/active")]
        public async Task<IActionResult> SetActive(
            long spaceId,
            [FromBody] SetSpaceActiveDto request,
            CancellationToken cancellationToken)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Common.Unauthorized"));
            }

            var result = await _service.SetActiveAsync(
                spaceId,
                request.IsActive,
                userId,
                cancellationToken);

            if (result.ResultCode == 200)
            {
                var messageKey = request.IsActive
                    ? "Spaces.ActivatedSuccessfully"
                    : "Spaces.DeactivatedSuccessfully";

                return Ok(_responseFactory.Success(
                    200,
                    messageKey,
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
    }

    public sealed class SetSpaceActiveDto
    {
        public bool IsActive { get; set; }
    }

}