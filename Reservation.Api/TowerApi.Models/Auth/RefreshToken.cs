namespace TowerApi.Models.Auth
{
    public class RefreshToken
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string TokenHash { get; set; } = string.Empty;

        public DateTime ExpiresAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? RevokedAt { get; set; }

        public string? ReplacedByTokenHash { get; set; }

        public Guid SessionId { get; set; }

        public string? DeviceName { get; set; }

        public string? UserAgent { get; set; }

        public string? CreatedIp { get; set; }

        public long? ActiveRoleId { get; set; }

        public DateTime? SessionRevokedAt { get; set; }
    }
    public class DeviceInfo
    {
        public string? DeviceName { get; set; }
    }
}
