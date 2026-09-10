using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Building;
using TowerApi.Repositories.Building;
using TowerApi.Services;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingRepository _repository;
        private readonly ICurrentUser _currentUser;

        public BuildingsController(
            IBuildingRepository repository,
            ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] BuildingQueryRequest request)
        {
            var result =
                await _repository.GetListAsync(request);

            return StatusCode(
                GetHttpStatusCode(result.ResultCode),
                new
                {
                    success = result.ResultCode == 200,
                    code = result.ResultCode,
                    message = result.ResultMessage,
                    data = result.Data
                });
        }

        [HttpGet("{buildingId:long}")]
        public async Task<IActionResult> GetById(
            long buildingId,
            [FromQuery] bool includeDeleted = false)
        {
            var result =
                await _repository.GetByIdAsync(
                    buildingId,
                    includeDeleted);

            return StatusCode(
                GetHttpStatusCode(result.ResultCode),
                new
                {
                    success = result.ResultCode == 200,
                    code = result.ResultCode,
                    message = result.ResultMessage,
                    data = result.Data
                });
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] BuildingCreateRequest request)
        {
            if (!_currentUser.IsAuthenticated)
            {
                return Unauthorized();
            }

            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized();
            }

            if (userId.Value > int.MaxValue)
            {
                return BadRequest(new
                {
                    success = false,
                    code = 400,
                    message =
                        "شناسه کاربر برای ثبت اطلاعات معتبر نیست."
                });
            }

            var result =
                await _repository.AddAsync(
                    request,
                    (int)userId.Value);

            return StatusCode(
                GetHttpStatusCode(result.ResultCode),
                new
                {
                    success = result.ResultCode == 200,
                    code = result.ResultCode,
                    message = result.ResultMessage,
                    data = result.Data
                });
        }

        [HttpPut("{buildingId:long}")]
        public async Task<IActionResult> Update(
            long buildingId,
            [FromBody] BuildingUpdateRequest request)
        {
            if (!_currentUser.IsAuthenticated)
            {
                return Unauthorized();
            }

            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized();
            }

            if (userId.Value > int.MaxValue)
            {
                return BadRequest(new
                {
                    success = false,
                    code = 400,
                    message =
                        "شناسه کاربر برای ویرایش اطلاعات معتبر نیست."
                });
            }

            var result =
                await _repository.EditAsync(
                    buildingId,
                    request,
                    (int)userId.Value);

            return StatusCode(
                GetHttpStatusCode(result.ResultCode),
                new
                {
                    success = result.ResultCode == 200,
                    code = result.ResultCode,
                    message = result.ResultMessage,
                    data = result.Data
                });
        }

        [HttpDelete("{buildingId:long}")]
        public async Task<IActionResult> Delete(
            long buildingId)
        {
            if (!_currentUser.IsAuthenticated)
            {
                return Unauthorized();
            }

            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized();
            }

            if (userId.Value > int.MaxValue)
            {
                return BadRequest(new
                {
                    success = false,
                    code = 400,
                    message =
                        "شناسه کاربر برای حذف اطلاعات معتبر نیست."
                });
            }

            var result =
                await _repository.DeleteAsync(
                    buildingId,
                    (int)userId.Value);

            return StatusCode(
                GetHttpStatusCode(result.ResultCode),
                new
                {
                    success = result.ResultCode == 200,
                    code = result.ResultCode,
                    message = result.ResultMessage
                });
        }

        private static int GetHttpStatusCode(
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
                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}