using Dapper;
using Microsoft.AspNetCore.Mvc;
using Reservation.Api.Data;
using Reservation.Api.Models;
using System.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Reservation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseConnection _database;
        private readonly IConfiguration _configuration;
        public AuthController(
     DatabaseConnection database,
     IConfiguration configuration)
        {
            _database = database;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            using var connection = _database.CreateConnection();

            connection.Open();

            var users = connection.Query<LoginUserRow>(
                     "USERS_LOGIN",
                     new
                     {
                         username = request.Username
                     },
                     commandType: CommandType.StoredProcedure
                 ).ToList();

            var user = users.FirstOrDefault();

            if (user == null)
            {
                return Unauthorized("Username or password is incorrect.");
            }



            var passwordHash = user.Password;

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(
                request.Password,
                passwordHash
            );

            if (!isPasswordValid)
            {
                return Unauthorized("Username or password is incorrect.");
            }



            var loginUser = new LoginUser
            {
                Id = user.Id,
                FirstName = user.First_Name,
                LastName = user.Last_Name,
                Username = user.Username,
                Roles = users
                    .Where(x => x.Role_Code != null)
                    .Select(x => x.Role_Code!)
                    .ToList()
            };







            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            foreach (var role in loginUser.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }



            var key = new SymmetricSecurityKey(
                 Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"]!
                )
          );




            var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
            );



            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

     
                      var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            var response = new LoginResponse
            {
                Token = jwt,
                User = loginUser
            };

            return Ok(response);



    
        }


        [HttpGet("test-password")]
        public IActionResult TestPassword()
        {
            var password = "Noyan@123";

            var hash = BCrypt.Net.BCrypt.HashPassword(password);

            return Ok(hash);
        }



    }
}