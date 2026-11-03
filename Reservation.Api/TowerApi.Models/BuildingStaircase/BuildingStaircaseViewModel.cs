
namespace TowerApi.Models.BuildingStaircase
{
    public class BuildingStaircaseViewModel
    {
        public long BuildingStaircaseId { get; set; }

        public long BuildingId { get; set; }

        public string StaircaseCode { get; set; } = string.Empty;

        public string StaircaseName { get; set; } = string.Empty;

        public string? StaircaseNameEn { get; set; }

        public int StaircaseType { get; set; }

        public bool IsEmergency { get; set; }

        public string? Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UserCreater { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UserUpdater { get; set; }
    }
}
