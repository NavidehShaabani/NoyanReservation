using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Signup
{
    public class SignupVerifyOtpRequest
    {
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

        [Range(1, long.MaxValue)]
        public long OtpRequestId { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string OtpCode { get; set; } = string.Empty;
    }
}
