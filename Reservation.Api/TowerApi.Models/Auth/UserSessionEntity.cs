namespace TowerApi.Models.Auth
{
    public class UserSessionEntity
    {
        public Guid SessionId { get; set; }

        public long UserId { get; set; }

        public long? ActiveRoleId { get; set; }

        public string? DeviceName { get; set; }

        public string? UserAgent { get; set; }

        public string? CreatedIp { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? LastSeenAt { get; set; }

        public DateTime? RevokedAt { get; set; }
    }
}
