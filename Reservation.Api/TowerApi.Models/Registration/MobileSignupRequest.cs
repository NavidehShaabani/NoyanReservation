using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Registration
{
    public sealed class MobileSignupRequest
    {
        [Required]
        [StringLength(30)]
        public string Mobile { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 3)]
        public string? Username { get; set; }

        // رمز خام فقط برای دریافت درخواست است؛
        // قبل از ارسال به دیتابیس باید Hash شود.
        public string? Password { get; set; }

        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        public int Gender { get; set; }

        [EmailAddress]
        [StringLength(150)]
        public string? Email { get; set; }

        [StringLength(10)]
        public string? NationalId { get; set; }

        public DateTime? BirthDate { get; set; }

        [Required]
        [StringLength(200)]
        public string OrgName { get; set; } = string.Empty;

        [Required]
        public int? OrgType { get; set; }

        [Required]
        [StringLength(10)]
        public string GeoId { get; set; } = string.Empty;
    }
}

