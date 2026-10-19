namespace TowerApi.Models.Signup
{
    public class SignupDbResult<T>
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public long? UserId { get; set; }
        public long? OrgId { get; set; }
        public long? OtpRequestId { get; set; }
        public DateTime? OtpExpiresAt { get; set; }
        public T? Data { get; set; }
    }
}
