using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Pricing.Settlements;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Helper;
using TowerApi.Services.Pricing.Settlements;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettlementController : ControllerBase
    {
        private readonly ISettlementService _service;
        private readonly IApiResponseFactory _responseFactory;

        public SettlementController(
            ISettlementService service,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _responseFactory = responseFactory;
        }

        [HttpGet("{settlementId:long}")]
        public async Task<IActionResult> GetById(long settlementId)
        {
            var result = await _service.GetById(settlementId);

            if (result == null)
            {
                return StatusCode(
                    404,
                    _responseFactory.Error(
                        404,
                        "Settlement.NotFound"));
            }

            return StatusCode(
                200,
                _responseFactory.Success(
                    200,
                    "Settlement.Retrieved",
                    result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] SettlementListRequest request)
        {
            var result = await _service.GetList(request);

            return StatusCode(
                200,
                _responseFactory.Success(
                    200,
                    "Settlement.ListRetrieved",
                    result));
        }

        [HttpPost]
        public async Task<IActionResult> Save(
            [FromBody] SettlementSaveRequest request)
        {
            var result = await _service.Save(request);

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                result.Code == 200
                    ? _responseFactory.Success(
                        result.Code,
                        result.MessageKey,
                        result.Data)
                    : _responseFactory.Error(
                        result.Code,
                        result.MessageKey));
        }

        [HttpPatch("{settlementId:long}/status")]
        public async Task<IActionResult> SetStatus(
            long settlementId,
            [FromBody] SettlementSetStatusRequest request)
        {
            request.SettlementId = settlementId;

            var result = await _service.SetStatus(request);

            return StatusCode(
                ApiResponseMessageMapper.GetHttpStatusCode(result.Code),
                result.Code == 200
                    ? _responseFactory.Success(
                        result.Code,
                        result.MessageKey,
                        result.Data)
                    : _responseFactory.Error(
                        result.Code,
                        result.MessageKey));
        }
    }
}
