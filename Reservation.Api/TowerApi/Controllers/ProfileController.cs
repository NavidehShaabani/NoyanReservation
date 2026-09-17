using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Profile;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Helper;
using TowerApi.Services.Profile;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/profile")]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly ICurrentUser _currentUser;
        private readonly IApiResponseFactory _responseFactory;

        public ProfileController(
            IProfileService profileService,
            ICurrentUser currentUser,
            IApiResponseFactory responseFactory)
        {
            _profileService = profileService;
            _currentUser = currentUser;
            _responseFactory = responseFactory;
        }

        [HttpPut("complete")]
        public async Task<IActionResult> CompleteProfile(
            [FromBody] CompleteProfileRequest request)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue || userId.Value <= 0)
            {
                return Unauthorized(
                    _responseFactory.Error(
                        401,
                        "Common.Unauthorized"));
            }

            var result =
                await _profileService.CompleteProfileAsync(
                    userId.Value,
                    request);

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

        [HttpGet]
        public async Task<IActionResult> Get()
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
                await _profileService.GetAsync(
                    userId.Value);

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
    }
}
