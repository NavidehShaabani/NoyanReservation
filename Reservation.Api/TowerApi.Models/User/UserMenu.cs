using TowerApi.Models.General;

namespace TowerApi.Models.User
{
     public class UserMenu
    {
        public long MenuId { get; set; }

        public long RoleId { get; set; }

        public long? ParentId { get; set; }

        public LocalizedText Name { get; set; } = new();

        public string? MenuUrl { get; set; }

        public string? Icon { get; set; }

        public int SortOrder { get; set; }

        public bool IsPermission { get; set; }

        public PermissionInfo Permission { get; set; } = new();
        public List<UserMenu> Children { get; set; } = new();
    }
}
