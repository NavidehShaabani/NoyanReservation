using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Profile;
using TowerApi.Services;
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

        public ProfileController(
            IProfileService profileService,
            ICurrentUser currentUser)
        {
            _profileService = profileService;
            _currentUser = currentUser;
        }


        [HttpPut("complete")]
        public async Task<IActionResult> CompleteProfile(
            [FromBody] CompleteProfileRequest request)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue || userId.Value <= 0)
            {
                return Unauthorized(new
                {
                    success = false,
                    code = 401,
                    message = "کاربر احراز هویت نشده است."
                });
            }


            var result =
                await _profileService.CompleteProfileAsync(
                    userId.Value,
                    request);


            return StatusCode(
                MapStatusCode(result.ResultCode),
                new
                {
                    success = result.ResultCode == 200,
                    code = result.ResultCode,
                    message = result.ResultMessage,
                    data = result.Data
                });
        }


        private static int MapStatusCode(
            int resultCode)
        {
            return resultCode switch
            {
                200 => StatusCodes.Status200OK,

                400 => StatusCodes.Status400BadRequest,

                401 => StatusCodes.Status401Unauthorized,

                403 => StatusCodes.Status403Forbidden,

                404 => StatusCodes.Status404NotFound,

                409 => StatusCodes.Status409Conflict,

                410 => StatusCodes.Status410Gone,

                429 => StatusCodes.Status429TooManyRequests,

                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}
