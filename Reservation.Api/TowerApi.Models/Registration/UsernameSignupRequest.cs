using System.ComponentModel.DataAnnotations;
using TowerApi.Models.Registration.TowerApi.Models.Registration;

namespace TowerApi.Models.Registration
{
    public class UsernameSignupRequest : MobileSignupRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(200, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
    }
}
