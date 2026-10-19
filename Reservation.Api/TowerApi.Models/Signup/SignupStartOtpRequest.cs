using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Signup
{
    public class SignupStartOtpRequest
    {
        [Required]
        [StringLength(30)]
        public string Mobile { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string OrgName { get; set; } = string.Empty;

        [Required]
        public int OrgType { get; set; }

        [Required]
        [StringLength(10)]
        public string GeoId { get; set; } = string.Empty;
    }
}
