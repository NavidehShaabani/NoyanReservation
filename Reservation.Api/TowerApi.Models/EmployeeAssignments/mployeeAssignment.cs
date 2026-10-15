

namespace TowerApi.Models.EmployeeAssignments
{
    public class EmployeeAssignmentQuery
    {
        public long? EmployeeId { get; set; }
        public long? OrgId { get; set; }
        public long? BuildingId { get; set; }
        public bool? IsActive { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    public class EmployeeAssignmentCreateRequest
    {
        public long EmployeeId { get; set; }
        public long OrgId { get; set; }
        public long? BuildingId { get; set; }
        public long? SpaceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ShiftName { get; set; }
        public string? EmployeeAssignmentDesc { get; set; }
    }

    public class EmployeeAssignmentUpdateRequest
    {
        public long OrgId { get; set; }
        public long? BuildingId { get; set; }
        public long? SpaceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ShiftName { get; set; }
        public string? EmployeeAssignmentDesc { get; set; }
    }

    public class EmployeeAssignmentActiveRequest
    {
        public bool IsActive { get; set; }
    }

    public class EmployeeAssignmentItem
    {
        public long EmployeeAssignmentId { get; set; }
        public long EmployeeId { get; set; }
        public long OrgId { get; set; }
        public long? BuildingId { get; set; }
        public long? SpaceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ShiftName { get; set; }
        public bool IsActive { get; set; }
        public string? EmployeeAssignmentDesc { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
