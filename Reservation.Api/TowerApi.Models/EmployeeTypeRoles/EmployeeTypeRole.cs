namespace TowerApi.Models.EmployeeTypeRoles
{
    public class EmployeeTypeRoleQuery
    {
        public int? EmployeeTypeId { get; set; }
        public long? RoleId { get; set; }
    }

    public class EmployeeTypeRoleCreateRequest
    {
        public int EmployeeTypeId { get; set; }
        public long RoleId { get; set; }
    }

    public class EmployeeTypeRoleItem
    {
        public long EmployeeTypeRoleId { get; set; }
        public int EmployeeTypeId { get; set; }
        public string? EmployeeTypeNameFr { get; set; }
        public string? EmployeeTypeNameEn { get; set; }
        public long RoleId { get; set; }
        public string? RoleName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
