
namespace TowerApi.Models.Registration
{
    public class UsernameSignupResponse
    {
        public long UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public bool PhoneVerified { get; set; }
    }
}
