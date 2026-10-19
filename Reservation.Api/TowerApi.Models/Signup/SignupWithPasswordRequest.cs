
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Signup
{
    public class SignupWithPasswordRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;

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
