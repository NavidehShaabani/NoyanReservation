using System.Security.Cryptography;
using System.Text;

namespace TowerApi.Services.Auth
{
    public class RefreshTokenService
    {
        public string GenerateToken()
        {
            var bytes = RandomNumberGenerator.GetBytes(64);

            return Convert.ToBase64String(bytes)
                .Replace("+", "-")
                .Replace("/", "_")
                .TrimEnd('=');
        }
        public string HashToken(string token)
        {
            var bytes = Encoding.UTF8.GetBytes(token);
            var hash = SHA256.HashData(bytes);

            return Convert.ToHexString(hash);
        }
    }
}