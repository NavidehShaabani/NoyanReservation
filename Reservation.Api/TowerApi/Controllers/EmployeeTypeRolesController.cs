using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.EmployeeTypeRoles;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.EmployeeTypeRoles;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeTypeRolesController : ControllerBase
    {
        private readonly IEmployeeTypeRoleService _service;
        private readonly IApiResponseFactory _responseFactory;
        private readonly ICurrentUser _currentUser;

        public EmployeeTypeRolesController(
            IEmployeeTypeRoleService service,
            IApiResponseFactory responseFactory,
            ICurrentUser currentUser)
        {
            _service = service;
            _responseFactory = responseFactory;
            _currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] EmployeeTypeRoleQuery request)
        {
            var data = await _service.GetAsync(request);

            return Ok(_responseFactory.Success(
                200, "EmployeeTypeRoles.GetSuccessfully", data));
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            EmployeeTypeRoleCreateRequest request)
        {
            var result = await _service.AddAsync(
                request, _currentUser.UserId);

            if (result.Code != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                    _responseFactory.Error(result.Code, result.MessageKey));

            return StatusCode(201, _responseFactory.Success(
                result.Code, result.MessageKey, (object?)null));
        }
    }
}
