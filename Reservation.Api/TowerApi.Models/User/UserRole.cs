using TowerApi.Models.General;

namespace TowerApi.Models.User
{
    public class UserRole
    {
        public long RoleId { get; set; }

        public string RoleCode { get; set; } = string.Empty;

        public LocalizedText RoleName { get; set; } = new();

        public LocalizedText RoleDescription { get; set; } = new();

        public List<UserMenu> Menus { get; set; } = new();
    }
}
