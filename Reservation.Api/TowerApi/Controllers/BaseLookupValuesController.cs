using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.BaseLookupValues;
using TowerApi.Services.Helper;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseLookupValuesController : ControllerBase
    {
        private readonly IBaseLookupValueService _service;
        private readonly IApiResponseFactory _responseFactory;

        public BaseLookupValuesController(
            IBaseLookupValueService service,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _responseFactory = responseFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            CancellationToken cancellationToken)
        {
            var result = await _service.GetAsync(cancellationToken);

            if (result.ResultCode == 200)
            {
                return Ok(
                    _responseFactory.Success(
                        200,
                        "Common.GetSuccessfully",
                        result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(
                    result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    ApiResponseMessageMapper.GetMessageKey(
                        result.ResultCode)));
        }

        [HttpGet("{lookupValueId:int}")]
        public async Task<IActionResult> GetById(
            int lookupValueId,
            CancellationToken cancellationToken)
        {
            if (lookupValueId <= 0)
            {
                return BadRequest(
                    _responseFactory.Error(
                        400,
                        "Common.InvalidRequest"));
            }

            var result = await _service.GetByIdAsync(
                lookupValueId,
                cancellationToken);

            if (result.ResultCode == 200)
            {
                return Ok(
                    _responseFactory.Success(
                        200,
                        "Common.GetSuccessfully",
                        result.Data));
            }

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(
                    result.ResultCode),
                _responseFactory.Error(
                    result.ResultCode,
                    ApiResponseMessageMapper.GetMessageKey(
                        result.ResultCode)));
        }
    }
}
