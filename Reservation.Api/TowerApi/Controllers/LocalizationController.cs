using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TowerApi.Services.ApiResponses;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/localization")]
    [AllowAnonymous]
    public class LocalizationController : ControllerBase
    {
        private readonly IApiResponseFactory _responseFactory;

        public LocalizationController(
            IApiResponseFactory responseFactory)
        {
            _responseFactory = responseFactory;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(
                _responseFactory.Success(
                    200,
                    "Common.GetSuccessfully",
                    new
                    {
                        name = "Tower API"
                    }));
        }

        [HttpGet("error-test")]
        public IActionResult ErrorTest()
        {
            return NotFound(
                _responseFactory.Error(
                    404,
                    "Common.NotFound"));
        }
    }
}
