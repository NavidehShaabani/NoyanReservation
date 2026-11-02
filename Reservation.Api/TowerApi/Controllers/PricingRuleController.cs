using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Pricing.PricingRule;
using TowerApi.Services;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Helper;
using TowerApi.Services.Pricing.PricingRule;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/pricing-rules")]
    [Authorize]
    public class PricingRuleController : ControllerBase
    {
        private readonly IPricingRuleService _service;
        private readonly IApiResponseFactory _responseFactory;
        private readonly ICurrentUser _currentUser;

        public PricingRuleController(
            IPricingRuleService service,
            IApiResponseFactory responseFactory,
            ICurrentUser currentUser)
        {
            _service = service;
            _responseFactory = responseFactory;
            _currentUser = currentUser;
        }

        // دریافت قانون قیمت‌گذاری
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetById(id);

            if (result == null)
            {
                return StatusCode(
                    404,
                    _responseFactory.Error(
                        404,
                        "PricingRule.NotFound"));
            }

            return Ok(
                _responseFactory.Success(
                    200,
                    "PricingRule.GetSuccessfully",
                    result));
        }

        // دریافت فهرست قوانین قیمت‌گذاری
        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] PricingRuleQuery query)
        {
            var result = await _service.GetList(query);

            return Ok(
                _responseFactory.Success(
                    200,
                    "PricingRule.GetSuccessfully",
                    result));
        }

        // ایجاد یا ویرایش قانون قیمت‌گذاری
        [HttpPost]
        public async Task<IActionResult> Save(
            [FromBody] PricingRuleSaveRequest request)
        {
            var result = await _service.Save(
                request,
                _currentUser.UserId);

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

        // حذف نرم قانون قیمت‌گذاری
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.Delete(
                id,
                _currentUser.UserId);

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

        // محاسبه مبلغ بر اساس قانون قیمت‌گذاری
        [HttpPost("calculate")]
        public async Task<IActionResult> CalculateAmount(
            [FromBody] PricingRuleCalculateRequest request)
        {
            var result = await _service.CalculateAmount(request);

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
