

namespace TowerApi.Models.User
{
    public class LoginRoleMenuRow
    {
        public long RoleId { get; set; }

        public string? RoleCode { get; set; }

        public string? RoleNameFa { get; set; }

        public string? RoleNameEn { get; set; }

        public string? RoleDescriptionFa { get; set; }

        public string? RoleDescriptionEn { get; set; }

        public long MenuId { get; set; }

        public long? ParentId { get; set; }

        public string? TitleFa { get; set; }

        public string? TitleEn { get; set; }

        public string? MenuUrl { get; set; }

        public string? Icon { get; set; }

        public int SortOrder { get; set; }

        public byte PermissionLevel { get; set; }
    }
}
