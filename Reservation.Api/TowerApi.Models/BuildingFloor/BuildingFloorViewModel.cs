
namespace TowerApi.Models.BuildingFloor
{
    public class BuildingFloorViewModel
    {
        public long BuildingFloorId { get; set; }

        public long BuildingId { get; set; }

        public int FloorNumber { get; set; }

        public string FloorCode { get; set; } = string.Empty;

        public string FloorName { get; set; } = string.Empty;

        public string? FloorNameEn { get; set; }

        public int MaxUnits { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UserCreater { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UserUpdater { get; set; }
    }
}
