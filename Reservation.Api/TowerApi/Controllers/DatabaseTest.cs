using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TowerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [Authorize]
        [HttpGet("secure")]
        public IActionResult Secure()
        {
            var userId =
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier);

            var username =
                User.Identity?.Name;

            return Ok(new
            {
                success = true,
                message = "JWT معتبر است.",
                userId = userId,
                username = username
            });
        }
    }
}