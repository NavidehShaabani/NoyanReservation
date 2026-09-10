
namespace TowerApi.Models.Building
{
    public class BuildingViewModel
    {
        public long BuildingId { get; set; }

        public string BuildingName { get; set; } = string.Empty;

        public string? BuildingAddress { get; set; }

        public string? BuildingDescription { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UserCreater { get; set; }

        public int? UserUpdater { get; set; }

        public long? OrgId { get; set; }
    }
}
