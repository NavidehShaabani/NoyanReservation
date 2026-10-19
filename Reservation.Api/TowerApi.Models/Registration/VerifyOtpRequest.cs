using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Registration
{
    public sealed class VerifyOtpRequest
    {
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

        [Range(1, long.MaxValue)]
        public long OtpRequestId { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{6}$",
            ErrorMessage = "کد تأیید باید دقیقاً ۶ رقم باشد.")]
        public string OtpCode { get; set; } = string.Empty;
    }
}
