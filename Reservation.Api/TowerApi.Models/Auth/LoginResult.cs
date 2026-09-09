using TowerApi.Models.User;

namespace TowerApi.Models.Auth
{
    public class LoginResult
    {
        public int ResultCode { get; set; }

        public string ResultMessage { get; set; } = string.Empty;

        public UserInfo? User { get; set; }

        public List<UserRole> Roles { get; set; } = new();

        public List<UserMenu> Menus { get; set; } = new();

        // JWT
        public string? AccessToken { get; set; }

        public int ExpiresIn { get; set; }
    }
}
