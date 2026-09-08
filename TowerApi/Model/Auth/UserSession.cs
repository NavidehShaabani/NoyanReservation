using TowerApi.Model.User;

namespace TowerApi.Model.Auth
{
    public class UserSession
    {
        public long UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }

        public string? NationalId { get; set; }

        public string? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool PhoneVerified { get; set; }

        public DateTime? LastLoginAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? Avatar { get; set; }

        public List<UserRole> Roles { get; set; } = new();

        public List<UserMenu> Menus { get; set; } = new();
    }
}
