namespace TowerApi.Models.Registration
{
    public sealed class RegistrationOperationResult
    {
        public int ResultCode { get; set; }

        public string ResultMessage { get; set; } = string.Empty;

        public long? UserId { get; set; }

        public long? OtpRequestId { get; set; }

        // فقط داخلی؛ هرگز مستقیماً به پاسخ JSON نده.
        public string? OtpCode { get; set; }

        public DateTime? OtpExpiresAt { get; set; }
    }
}