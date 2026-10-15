namespace TowerApi.Models.EmployeeTypes
{
    public class EmployeeTypeQuery
    {
        public string? Search { get; set; }
        public bool? IsActive { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class EmployeeTypeCreateRequest
    {
        public string EmployeeTypeName { get; set; } = string.Empty;
        public string? EmployeeTypeDesc { get; set; }
    }

    public class EmployeeTypeUpdateRequest
    {
        public string EmployeeTypeName { get; set; } = string.Empty;
        public string? EmployeeTypeDesc { get; set; }
    }

    public class EmployeeTypeActiveRequest
    {
        public bool IsActive { get; set; }
    }

    public class EmployeeTypeItem
    {
        public int EmployeeTypeId { get; set; }
        public string EmployeeTypeName { get; set; } = string.Empty;
        public string? EmployeeTypeDesc { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class EmployeeTypeRoleItem
    {
        public long EmployeeTypeRoleId { get; set; }
        public int EmployeeTypeId { get; set; }
        public long RoleId { get; set; }
        public string? RoleName { get; set; }
        public bool IsActive { get; set; }
    }

    public class EmployeeTypeDetails : EmployeeTypeItem
    {
        public int? UserCreater { get; set; }
        public int? UserUpdater { get; set; }
        public List<EmployeeTypeRoleItem> Roles { get; set; } = new();
    }
}
