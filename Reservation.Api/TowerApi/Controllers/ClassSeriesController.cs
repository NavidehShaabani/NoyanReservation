using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Booking.ClassSeries;
using TowerApi.Services.Booking.ClassSeries;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClassSeriesController : ControllerBase
    {
        private readonly IClassSeriesService _service;
        private readonly IApiResponseFactory _responseFactory;

        public ClassSeriesController(
            IClassSeriesService service,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _responseFactory = responseFactory;
        }

        [HttpGet("{classSeriesId:long}")]
        public async Task<IActionResult> GetById(long classSeriesId)
        {
            var result = await _service.GetByIdAsync(classSeriesId);

            if (result.ResultCode == 200)
                return Ok(_responseFactory.Success(
                    200, result.ResultMessage, result.Data));

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(result.ResultCode, result.ResultMessage));
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveList([FromQuery] long? orgId)
        {
            var result = await _service.GetActiveListAsync(orgId);

            if (result.ResultCode == 200)
                return Ok(_responseFactory.Success(
                    200, result.ResultMessage, result.Data));

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(result.ResultCode, result.ResultMessage));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] ClassSeriesModel model)
        {
            var result = await _service.SaveAsync(model);

            if (result.ResultCode == 200)
                return Ok(_responseFactory.Success(
                    200, result.ResultMessage, result.Data));

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(result.ResultCode, result.ResultMessage));
        }

        [HttpDelete("{classSeriesId:long}")]
        public async Task<IActionResult> Delete(long classSeriesId)
        {
            var result = await _service.DeleteAsync(classSeriesId);

            if (result.ResultCode == 200)
                return Ok(_responseFactory.Success(
                    200, result.ResultMessage, result.Data));

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.ResultCode),
                _responseFactory.Error(result.ResultCode, result.ResultMessage));
        }
    }
}
