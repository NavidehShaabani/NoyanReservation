using Microsoft.AspNetCore.Mvc;
using TowerApi.DataBase;

namespace TowerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DatabaseTestController : ControllerBase
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DatabaseTestController(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        try
        {
            Console.WriteLine("STEP 1");

            var connection = _connectionFactory.CreateConnection();

            Console.WriteLine("STEP 2");

            if (connection == null)
            {
                return StatusCode(500, "connection is NULL");
            }

            Console.WriteLine("STEP 3");

            connection.Open();

            Console.WriteLine("STEP 4");

            return Ok(new
            {
                success = true,
                message = "SQL Connection OK"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                success = false,
                type = ex.GetType().FullName,
                message = ex.Message,
                stackTrace = ex.StackTrace,
                inner = ex.InnerException?.Message
            });
        }
    }
}