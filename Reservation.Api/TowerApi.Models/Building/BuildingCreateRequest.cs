namespace TowerApi.Models.Building
{
    public class BuildingCreateRequest
    {
        public string BuildingName { get; set; } = string.Empty;

        public string? BuildingAddress { get; set; }

        public string? BuildingDescription { get; set; }

        public bool IsActive { get; set; } = true;

        public long? OrgId { get; set; }
    }
}