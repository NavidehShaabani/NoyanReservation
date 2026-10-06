using System.Security.Cryptography;
using System.Text;

namespace TowerApi.Services.Auth
{
    public static class RefreshTokenGenerator
    {
        public static string Generate()
        {
            var bytes = RandomNumberGenerator.GetBytes(64);

            return Convert.ToBase64String(bytes);
        }


        public static string Hash(
            string token)
        {
            var bytes =
                Encoding.UTF8.GetBytes(token);

            var hash =
                SHA256.HashData(bytes);

            return Convert.ToHexString(hash);
        }
    }
}