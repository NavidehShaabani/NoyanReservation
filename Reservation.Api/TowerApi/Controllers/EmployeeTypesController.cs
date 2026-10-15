using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.EmployeeTypes;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.EmployeeTypes;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeTypesController : ControllerBase
    {
        private readonly IEmployeeTypeService _service;
        private readonly IApiResponseFactory _responseFactory;
        private readonly ICurrentUser _currentUser;

        public EmployeeTypesController(
            IEmployeeTypeService service,
            IApiResponseFactory responseFactory,
            ICurrentUser currentUser)
        {
            _service = service;
            _responseFactory = responseFactory;
            _currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] EmployeeTypeQuery request)
        {
            var data = await _service.GetAsync(request);

            return Ok(_responseFactory.Success(
                200, "EmployeeTypes.GetSuccessfully", data));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);

            if (data == null)
                return NotFound(_responseFactory.Error(
                    404, "EmployeeTypes.NotFound"));

            return Ok(_responseFactory.Success(
                200, "EmployeeTypes.GetSuccessfully", data));
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeTypeCreateRequest request)
        {
            var result = await _service.AddAsync(request, _currentUser.UserId);

            if (result.Code != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                    _responseFactory.Error(result.Code, result.MessageKey));

            return StatusCode(201, _responseFactory.Success(
                result.Code, result.MessageKey, result.Data));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(
            int id, EmployeeTypeUpdateRequest request)
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id, _currentUser.UserId);

            if (result.Code != 200)
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                    _responseFactory.Error(result.Code, result.MessageKey));

            return Ok(_responseFactory.Success(
                result.Code, result.MessageKey, (object?)null));
        }

        [HttpPatch("{id:int}/active")]
        public async Task<IActionResult> SetActive(
            int id, EmployeeTypeActiveRequest request)
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