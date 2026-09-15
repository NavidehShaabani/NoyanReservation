

namespace TowerApi.Models.Registration
{
    public class MobileSignupResponse
    {
        public long UserId { get; set; }
        public long OtpRequestId { get; set; }
        public DateTime? OtpExpiresAt { get; set; }
    }
}
