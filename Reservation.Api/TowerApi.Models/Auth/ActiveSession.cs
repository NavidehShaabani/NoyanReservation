

namespace TowerApi.Models.Auth
{
    public class ActiveSession
    {
        public Guid SessionId { get; set; }

        public string? DeviceName { get; set; }

        public string? UserAgent { get; set; }

        public string? CreatedIp { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
