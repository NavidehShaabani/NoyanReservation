using Microsoft.AspNetCore.Mvc;
using TowerApi.Models.Pricing.FinancialTransaction;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Helper;
using TowerApi.Services.Pricing.FinancialTransaction;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialTransactionController : ControllerBase
    {
        private readonly IFinancialTransactionService _service;
        private readonly IApiResponseFactory _responseFactory;

        public FinancialTransactionController(
            IFinancialTransactionService service,
            IApiResponseFactory responseFactory)
        {
            _service = service;
            _responseFactory = responseFactory;
        }

        [HttpGet("{financialTransactionId:long}")]
        public async Task<IActionResult> GetById(long financialTransactionId)
        {
            var result = await _service.GetById(financialTransactionId);

            if (result == null)
            {
                return StatusCode(
                    404,
                    _responseFactory.Error(
                        404,
                        "FinancialTransaction.NotFound"));
            }

            return StatusCode(
                200,
                _responseFactory.Success(
                    200,
                    "FinancialTransaction.Retrieved",
                    result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] FinancialTransactionListRequest request)
        {
            var result = await _service.GetList(request);

            return StatusCode(
                200,
                _responseFactory.Success(
                    200,
                    "FinancialTransaction.ListRetrieved",
                    result));
        }

        [HttpPost]
        public async Task<IActionResult> Save(
            [FromBody] FinancialTransactionSaveRequest request)
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

        [HttpPatch("{financialTransactionId:long}/status")]
        public async Task<IActionResult> SetStatus(
            long financialTransactionId,
            [FromBody] FinancialTransactionSetStatusRequest request)
        {
            request.FinancialTransactionId = financialTransactionId;

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
