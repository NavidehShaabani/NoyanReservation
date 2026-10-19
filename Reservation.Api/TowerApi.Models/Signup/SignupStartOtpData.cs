namespace TowerApi.Models.Signup
{
    public class SignupStartOtpData
    {
        public long UserId { get; set; }
        public long OtpRequestId { get; set; }
        public DateTime OtpExpiresAt { get; set; }
    }
}
