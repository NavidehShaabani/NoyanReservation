using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Geo;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Geo;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GeoController : ControllerBase
    {
        private readonly IGeoService _service;
        private readonly IApiResponseFactory _responseFactory;

        public GeoController(
            IGeoService service,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _responseFactory = responseFactory;
        }

        [HttpGet("children")]
        public async Task<IActionResult> GetChildren(
            [FromQuery] GeoChildrenQueryRequest request)
        {
            var result =
                await _service.GetChildrenAsync(request);

            if (result.ResultCode != 200)
            {
                return StatusCode(
                    ApiResponseMessageMapper.GetHttpStatusCode(
                        result.ResultCode),
                    _responseFactory.Error(
                        result.ResultCode,
                        result.MessageKey));
            }

            return Ok(
                _responseFactory.Success(
                    200,
                    result.MessageKey,
                    result.Data));
        }
    }
}
