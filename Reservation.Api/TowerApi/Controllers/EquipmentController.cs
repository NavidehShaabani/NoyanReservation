using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Booking.Equipment;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Booking.Equipment;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/booking/equipment")]
    [Authorize]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _service;
        private readonly IApiResponseFactory _responseFactory;

        public EquipmentController(
            IEquipmentService service,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _responseFactory = responseFactory;
        }

        [HttpGet("{equipmentId:long}")]
        public async Task<IActionResult> GetById(long equipmentId)
        {
            var result = await _service.GetByIdAsync(equipmentId);

            if (result.ResultCode != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(result.ResultCode, result.ResultMessage));
            }

            return Ok(_responseFactory.Success(
                200, result.ResultMessage, result.Data));
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] EquipmentQueryRequest request)
        {
            var result = await _service.GetListAsync(request);

            if (result.ResultCode != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(result.ResultCode, result.ResultMessage));
            }

            return Ok(_responseFactory.Success(
                200, result.ResultMessage, result.Data));
        }

        [HttpPost]
        public async Task<IActionResult> Save(
            [FromBody] EquipmentSaveRequest request)
        {
            var result = await _service.SaveAsync(request);

            if (result.ResultCode != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(result.ResultCode, result.ResultMessage));
            }

            return Ok(_responseFactory.Success(
                200, result.ResultMessage, result.Data));
        }

        [HttpDelete("{equipmentId:long}")]
        public async Task<IActionResult> Delete(long equipmentId)
        {
            var result = await _service.DeleteAsync(equipmentId);

            if (result.ResultCode != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(result.ResultCode, result.ResultMessage));
            }

            return Ok(_responseFactory.Success(
                200, result.ResultMessage, result.Data));
        }
    }
}
