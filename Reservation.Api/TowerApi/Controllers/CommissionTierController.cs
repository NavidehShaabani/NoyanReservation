using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Pricing.CommissionTier;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Helper;
using TowerApi.Services.Pricing.CommissionTier;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommissionTierController : ControllerBase
    {
        private readonly ICommissionTierService _service;
        private readonly IApiResponseFactory _responseFactory;

        public CommissionTierController(
            ICommissionTierService service,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _responseFactory = responseFactory;
        }

        [HttpGet("{commissionTierId:long}")]
        public async Task<IActionResult> GetById(long commissionTierId)
        {
            var result = await _service.GetById(commissionTierId);

            if (result == null)
            {
                return StatusCode(
                    404,
                    _responseFactory.Error(
                        404,
                        "CommissionTier.NotFound"));
            }

            return Ok(_responseFactory.Success(
                200,
                "Common.Success",
                result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] long commissionPlanId)
        {
            if (commissionPlanId <= 0)
            {
                return StatusCode(
                    400,
                    _responseFactory.Error(
                        400,
                        "CommissionTier.InvalidPlanId"));
            }

            var result = await _service.GetList(commissionPlanId);

            return Ok(_responseFactory.Success(
                200,
                "Common.Success",
                result));
        }

        [HttpPost]
        public async Task<IActionResult> Save(
            [FromBody] CommissionTierSaveRequest request)
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

        [HttpDelete("{commissionTierId:long}")]
        public async Task<IActionResult> Delete(long commissionTierId)
        {
            var result = await _service.Delete(commissionTierId);

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
