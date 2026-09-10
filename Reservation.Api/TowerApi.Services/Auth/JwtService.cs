using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TowerApi.Models.Auth;
using System.Text.Json;

namespace TowerApi.Services.Auth
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserSession user)
        {
            var key = _configuration["Jwt:Key"];

            if (string.IsNullOrWhiteSpace(key))
                throw new InvalidOperationException(
                    "Jwt:Key در تنظیمات پیدا نشد.");

            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var expireMinutes =
                _configuration.GetValue<int>("Jwt:ExpireMinutes");

            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.UserId.ToString()),

                new Claim(
                    ClaimTypes.Name,
                    user.Username)
            };

            if (user.Roles != null &&
    user.Roles.Any())
            {
                claims.Add(
                    new Claim(
                        "Roles",
                        JsonSerializer.Serialize(user.Roles)));
            }

            if (user.Menus != null &&
                user.Menus.Any())
            {
                claims.Add(
                    new Claim(
                        "Menus",
                        JsonSerializer.Serialize(user.Menus)));
            }

            if (!string.IsNullOrWhiteSpace(user.FirstName))
            {
                claims.Add(new Claim(
                    "FirstName",
                    user.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(user.LastName))
            {
                claims.Add(new Claim(
                    "LastName",
                    user.LastName));
            }

            // Roles
            if (user.Roles != null)
            {
                foreach (var role in user.Roles)
                {
                    if (!string.IsNullOrWhiteSpace(role.RoleName))
                    {
                        claims.Add(new Claim(
                            ClaimTypes.Role,
                            role.RoleName));
                    }
                }
            }

            var securityKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(key));

            var credentials =
                new SigningCredentials(
                    securityKey,
                    SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}