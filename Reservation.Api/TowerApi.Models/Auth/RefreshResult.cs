
namespace TowerApi.Models.Auth
{
    public class RefreshResult
    {
        public int ResultCode { get; set; }

        public string ResultMessage { get; set; } = string.Empty;

        public string? AccessToken { get; set; }

        public int ExpiresIn { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiresAt { get; set; }

        public Guid SessionId { get; set; }

        public long? ActiveRoleId { get; set; }
    }
}
