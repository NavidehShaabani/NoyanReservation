using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Organization;
using TowerApi.Repositories.Organization;
using TowerApi.Services;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationRepository _repository;
        private readonly ICurrentUser _currentUser;

        public OrganizationsController(
            IOrganizationRepository repository,
            ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        // GET: api/organizations
        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] OrganizationQueryRequest request)
        {
            var result =
                await _repository.GetListAsync(request);

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

        // GET: api/organizations/10
        [HttpGet("{orgId:long}")]
        public async Task<IActionResult> GetById(
            long orgId,
            [FromQuery] bool includeDeleted = false)
        {
            var result =
                await _repository.GetByIdAsync(
                    orgId,
                    includeDeleted);

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

        // POST: api/organizations
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] OrganizationCreateRequest request)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(new
                {
                    success = false,
                    code = 401,
                    message = "کاربر احراز هویت نشده است."
                });
            }

            if (userId.Value > int.MaxValue)
            {
                return BadRequest(new
                {
                    success = false,
                    code = 400,
                    message = "شناسه کاربر برای ثبت اطلاعات معتبر نیست."
                });
            }

            var result =
                await _repository.AddAsync(
                    request,
                    (int)userId.Value);

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

        // PUT: api/organizations/10
        [HttpPut("{orgId:long}")]
        public async Task<IActionResult> Update(
            long orgId,
            [FromBody] OrganizationUpdateRequest request)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(new
                {
                    success = false,
                    code = 401,
                    message = "کاربر احراز هویت نشده است."
                });
            }

            if (userId.Value > int.MaxValue)
            {
                return BadRequest(new
                {
                    success = false,
                    code = 400,
                    message = "شناسه کاربر برای ویرایش اطلاعات معتبر نیست."
                });
            }

            var result =
                await _repository.EditAsync(
                    orgId,
                    request,
                    (int)userId.Value);

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

        // DELETE: api/organizations/10
        [HttpDelete("{orgId:long}")]
        public async Task<IActionResult> Delete(
            long orgId)
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue)
            {
                return Unauthorized(new
                {
                    success = false,
                    code = 401,
                    message = "کاربر احراز هویت نشده است."
                });
            }

            if (userId.Value > int.MaxValue)
            {
                return BadRequest(new
                {
                    success = false,
                    code = 400,
                    message = "شناسه کاربر برای حذف اطلاعات معتبر نیست."
                });
            }

            var result =
                await _repository.DeleteAsync(
                    orgId,
                    (int)userId.Value);

            return StatusCode(
                MapStatusCode(result.ResultCode),
                new
                {
                    success = result.ResultCode == 200,
                    code = result.ResultCode,
                    message = result.ResultMessage
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
                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}