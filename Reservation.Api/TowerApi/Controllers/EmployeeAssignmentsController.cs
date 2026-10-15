using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.EmployeeAssignments;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.EmployeeAssignments;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeAssignmentsController : ControllerBase
    {
        private readonly IEmployeeAssignmentService _service;
        private readonly IApiResponseFactory _responseFactory;
        private readonly ICurrentUser _currentUser;

        public EmployeeAssignmentsController(
            IEmployeeAssignmentService service,
            IApiResponseFactory responseFactory,
            ICurrentUser currentUser)
        {
            _service = service;
            _responseFactory = responseFactory;
            _currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] EmployeeAssignmentQuery request)
        {
            var data = await _service.GetAsync(request);

            return Ok(_responseFactory.Success(
                200, "EmployeeAssignments.GetSuccessfully", data));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = await _service.GetByIdAsync(id);

            if (data == null)
                return NotFound(_responseFactory.Error(
                    404, "EmployeeAssignments.NotFound"));

            return Ok(_responseFactory.Success(
                200, "EmployeeAssignments.GetSuccessfully", data));
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            EmployeeAssignmentCreateRequest request)
        {
            var result = await _service.AddAsync(
                request, _currentUser.UserId);

            if (result.Code != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                    _responseFactory.Error(result.Code, result.MessageKey));

            return StatusCode(201, _responseFactory.Success(
                result.Code, result.MessageKey, result.Data));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Edit(
            long id, EmployeeAssignmentUpdateRequest request)
        {
            var result = await _service.EditAsync(
                id, request, _currentUser.UserId);

            if (result.Code != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                    _responseFactory.Error(result.Code, result.MessageKey));

            return Ok(_responseFactory.Success(
                result.Code, result.MessageKey, (object?)null));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.DeleteAsync(
                id, _currentUser.UserId);

            if (result.Code != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                    _responseFactory.Error(result.Code, result.MessageKey));

            return Ok(_responseFactory.Success(
                result.Code, result.MessageKey, (object?)null));
        }

        [HttpPatch("{id:long}/active")]
        public async Task<IActionResult> SetActive(
            long id, EmployeeAssignmentActiveRequest request)
        {
            var result = await _service.SetActiveAsync(
                id, request.IsActive, _currentUser.UserId);

            if (result.Code != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                    _responseFactory.Error(result.Code, result.MessageKey));

            return Ok(_responseFactory.Success(
                result.Code, result.MessageKey, (object?)null));
        }
    }
}
