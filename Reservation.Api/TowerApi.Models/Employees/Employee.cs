namespace TowerApi.Models.Employees
{
    public class EmployeeQuery
    {
        public string? Search { get; set; }
        public long? OrgId { get; set; }
        public int? EmployeeTypeId { get; set; }
        public bool? IsActive { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class EmployeeCreateRequest
    {
        public string? Username { get; set; }

        // رمز خام؛ Hash در Service تولید می‌شود.
        public string? Password { get; set; }

        public string? Email { get; set; }
        public string Mobile { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? NationalId { get; set; }
        public int Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? AvatarUrl { get; set; }
        public bool PhoneVerified { get; set; }
        public bool UserIsActive { get; set; } = true;

        public long OrgId { get; set; }
        public int EmployeeTypeId { get; set; }
        public byte EmploymentType { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? BaseSalary { get; set; }
        public decimal? HourlyRate { get; set; }
        public string? BankName { get; set; }
        public string? BankCardNumber { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? ShebaNumber { get; set; }
        public bool EmployeeIsActive { get; set; } = true;
        public string? EmployeesDesc { get; set; }
    }

    public class EmployeeUpdateRequest
    {
        public long OrgId { get; set; }
        public int EmployeeTypeId { get; set; }
        public byte EmploymentType { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? BaseSalary { get; set; }
        public decimal? HourlyRate { get; set; }
        public string? BankName { get; set; }
        public string? BankCardNumber { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? ShebaNumber { get; set; }
        public string? EmployeesDesc { get; set; }
    }

    public class EmployeeActiveRequest
    {
        public bool IsActive { get; set; }
    }

    public class EmployeeItem
    {
        public long EmployeeId { get; set; }
        public long UserId { get; set; }
        public long OrgId { get; set; }
        public string? OrgName { get; set; }
        public int EmployeeTypeId { get; set; }
        public string? EmployeeTypeNameFr { get; set; }
        public string? EmployeeTypeNameEn { get; set; }
        public byte EmploymentType { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? BaseSalary { get; set; }
        public decimal? HourlyRate { get; set; }
        public string? BankName { get; set; }
        public string? BankCardNumber { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? ShebaNumber { get; set; }
        public bool IsActive { get; set; }
        public string? EmployeesDesc { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
    }

    public class EmployeeAssignmentSummary
    {
        public long EmployeeAssignmentId { get; set; }
        public long EmployeeId { get; set; }
        public long OrgId { get; set; }
        public long? BuildingId { get; set; }
        public string? BuildingName { get; set; }
        public long? SpaceId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ShiftName { get; set; }
        public bool IsActive { get; set; }
        public string? EmployeeAssignmentDesc { get; set; }
    }

    public class EmployeeDetails : EmployeeItem
    {
        //public string? EmployeeTypeDesc { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<EmployeeAssignmentSummary> Assignments { get; set; } = new();
    }

    public class EmployeeCreateResult
    {
        public long? UserId { get; set; }
        public long? EmployeeId { get; set; }
    }
}
