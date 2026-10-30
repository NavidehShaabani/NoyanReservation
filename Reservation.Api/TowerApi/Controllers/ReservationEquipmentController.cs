using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Booking.ReservationEquipment;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Booking.ReservationEquipment;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/booking/reservation-equipment")]
    [Authorize]
    public class ReservationEquipmentController : ControllerBase
    {
        private readonly IReservationEquipmentService _service;
        private readonly IApiResponseFactory _responseFactory;

        public ReservationEquipmentController(
            IReservationEquipmentService service,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _responseFactory = responseFactory;
        }

        [HttpGet("{reservationEquipmentId:long}")]
        public async Task<IActionResult> GetById(long reservationEquipmentId)
        {
            var result = await _service.GetByIdAsync(reservationEquipmentId);

            if (result.ResultCode != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(
                        result.ResultCode,
                        result.ResultMessage));
            }

            return Ok(_responseFactory.Success(
                200,
                result.ResultMessage,
                result.Data));
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] ReservationEquipmentQueryRequest request)
        {
            var result = await _service.GetListAsync(request);

            if (result.ResultCode != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(
                        result.ResultCode,
                        result.ResultMessage));
            }

            return Ok(_responseFactory.Success(
                200,
                result.ResultMessage,
                result.Data));
        }

        [HttpPost]
        public async Task<IActionResult> Save(
            [FromBody] ReservationEquipmentSaveRequest request)
        {
            var result = await _service.SaveAsync(request);

            if (result.ResultCode != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(
                        result.ResultCode,
                        result.ResultMessage));
            }

            return Ok(_responseFactory.Success(
                200,
                result.ResultMessage,
                result.Data));
        }

        [HttpDelete("{reservationEquipmentId:long}")]
        public async Task<IActionResult> Delete(long reservationEquipmentId)
        {
            var result = await _service.DeleteAsync(reservationEquipmentId);

            if (result.ResultCode != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                    _responseFactory.Error(
                        result.ResultCode,
                        result.ResultMessage));
            }

            return Ok(_responseFactory.Success(
                200,
                result.ResultMessage,
                result.Data));
        }
    }
}
