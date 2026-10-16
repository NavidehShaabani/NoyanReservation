

namespace TowerApi.Models.Registration
{
    public class RegistrationResult
    {
        public int ResultCode { get; set; }

        public string ResultMessage { get; set; } =
            string.Empty;

        public long? UserId { get; set; }

        public long? OtpRequestId { get; set; }

        public string? OtpCode { get; set; }

        public DateTime? OtpExpiresAt { get; set; }
    }
}
