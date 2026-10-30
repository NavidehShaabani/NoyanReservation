using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Booking.SpaceAmenities;
using TowerApi.Services.Booking.SpaceAmenities;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SpaceAmenitiesController : ControllerBase
    {
        private readonly ISpaceAmenityService _service;
        private readonly IApiResponseFactory _responseFactory;

        public SpaceAmenitiesController(
            ISpaceAmenityService service,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _responseFactory = responseFactory;
        }

        [HttpGet("{spaceAmenityId:long}")]
        public async Task<IActionResult> GetById(long spaceAmenityId)
        {
            var result = await _service.GetByIdAsync(spaceAmenityId);

            if (result.ResultCode == 200)
                return Ok(_responseFactory.Success(
                    200, result.ResultMessage, result.Data));

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(result.ResultCode, result.ResultMessage));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] SpaceAmenityListRequest request)
        {
            var result = await _service.GetListAsync(request);

            if (result.ResultCode == 200)
                return Ok(_responseFactory.Success(
                    200, result.ResultMessage, result.Data));

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(result.ResultCode, result.ResultMessage));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SpaceAmenityModel model)
        {
            var result = await _service.SaveAsync(model);

            if (result.ResultCode == 200)
                return Ok(_responseFactory.Success(
                    200, result.ResultMessage, result.Data));

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(result.ResultCode, result.ResultMessage));
        }

        [HttpDelete("{spaceAmenityId:long}")]
        public async Task<IActionResult> Delete(long spaceAmenityId)
        {
            var result = await _service.DeleteAsync(spaceAmenityId);

            if (result.ResultCode == 200)
                return Ok(_responseFactory.Success(
                    200, result.ResultMessage, result.Data));

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(result.ResultCode, result.ResultMessage));
        }
    }
}
