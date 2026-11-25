using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.BuildingFloor;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.BuildingFloor;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingFloorsController : ControllerBase
    {
        private readonly IBuildingFloorsService _service;
        private readonly IApiResponseFactory _responseFactory;

        public BuildingFloorsController(
            IBuildingFloorsService service,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _responseFactory = responseFactory;
        }

        private IActionResult CreateResponse<T>(
            (int Code, string MessageKey, T? Data) result)
        {
            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                result.Code is 200 or 201
                    ? _responseFactory.Success(
                        result.Code,
                        result.MessageKey,
                        result.Data)
                    : _responseFactory.Error(
                        result.Code,
                        result.MessageKey));
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] long? buildingId,
            [FromQuery] bool? isActive)
        {
            var result = await _service.Get(buildingId, isActive);
            return CreateResponse(result);
        }

        [HttpGet("{buildingFloorId:long}")]
        public async Task<IActionResult> GetById(long buildingFloorId)
        {
            var result = await _service.GetById(buildingFloorId);
            return CreateResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(
            [FromBody] BuildingFloorInsertRequest request)
        {
            var result = await _service.Insert(request);
            return CreateResponse(result);
        }

        [HttpPut("{buildingFloorId:long}")]
        public async Task<IActionResult> Update(
            long buildingFloorId,
            [FromBody] BuildingFloorUpdateRequest request)
        {
            var result = await _service.Update(
                buildingFloorId,
                request);

            return CreateResponse(result);
        }

        [HttpPost("bulk-save")]
        public async Task<IActionResult> BulkSave(
            [FromBody] BuildingFloorBulkSaveRequest request)
        {
            var result = await _service.BulkSave(request);
            return CreateResponse(result);
        }

        [HttpDelete("{buildingFloorId:long}")]
        public async Task<IActionResult> Delete(long buildingFloorId)
        {
            var result = await _service.Delete(buildingFloorId);
            return CreateResponse(result);
        }

        [HttpPatch("{buildingFloorId:long}/active")]
        public async Task<IActionResult> SetActive(
            long buildingFloorId,
            [FromBody] BuildingFloorSetActiveRequest request)
        {
            var result = await _service.SetActive(
                buildingFloorId,
                request.IsActive);

            return CreateResponse(result);
        }
    }
}
