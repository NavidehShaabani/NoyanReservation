namespace TowerApi.Model.User
{
    public class UserRole
    {
        public long RoleId { get; set; }

        public string RoleName { get; set; } = string.Empty;

        public string? RoleDescription { get; set; }

        public long UserRoleId { get; set; }

        public DateTime? AssignedAt { get; set; }
    }
}
