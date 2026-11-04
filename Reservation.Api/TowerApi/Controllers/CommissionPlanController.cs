using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Pricing.CommissionPlan;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Helper;
using TowerApi.Services.Pricing.CommissionPlan;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommissionPlanController : ControllerBase
    {
        private readonly ICommissionPlanService _service;
        private readonly IApiResponseFactory _responseFactory;

        public CommissionPlanController(
            ICommissionPlanService service,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _responseFactory = responseFactory;
        }

        [HttpGet("{commissionPlanId:long}")]
        public async Task<IActionResult> GetById(long commissionPlanId)
        {
            var result = await _service.GetById(commissionPlanId);

            if (result == null)
            {
                return StatusCode(
                    404,
                    _responseFactory.Error(404, "CommissionPlan.NotFound"));
            }

            return Ok(_responseFactory.Success(
                200,
                "Common.Success",
                result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] long? orgId,
            [FromQuery] long? classSeriesId,
            [FromQuery] bool onlyActive = true)
        {
            var result = await _service.GetList(
                orgId,
                classSeriesId,
                onlyActive);

            return Ok(_responseFactory.Success(
                200,
                "Common.Success",
                result));
        }

        [HttpPost]
        public async Task<IActionResult> Save(
            [FromBody] CommissionPlanSaveRequest request)
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

        [HttpDelete("{commissionPlanId:long}")]
        public async Task<IActionResult> Delete(long commissionPlanId)
        {
            var result = await _service.Delete(commissionPlanId);

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

        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate(
            [FromBody] CommissionPlanCalculateRequest request)
        {
            var result = await _service.Calculate(request);

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
