namespace TowerApi.Models.User
{
    public class UserMenu
    {
        public long MenuId { get; set; }

        public long? ParentId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? MenuUrl { get; set; }

        public string? Icon { get; set; }

        public int SortOrder { get; set; }

        public string? MenuDescription { get; set; }

        public int PermissionLevel { get; set; }

        public bool CanRead { get; set; }

        public bool CanWrite { get; set; }

        public bool CanFullAccess { get; set; }

        public List<UserMenu> Children { get; set; } = new();
    }
}
