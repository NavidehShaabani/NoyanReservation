using Microsoft.AspNetCore.Mvc;
using Reservation.Api.Data;

namespace Reservation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly DatabaseConnection _database;

        public TestController(DatabaseConnection database)
        {
            _database = database;
        }

        [HttpGet("database")]
        public IActionResult TestDatabase()
        {
            try
            {
                using var connection = _database.CreateConnection();

                connection.Open();

                return Ok("Database connection successful!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("hash")]
        public IActionResult TestHash()
        {
            var password = "Noyan@123";

            var hash = BCrypt.Net.BCrypt.HashPassword(password);

            return Ok(hash);
        }
    }
}

