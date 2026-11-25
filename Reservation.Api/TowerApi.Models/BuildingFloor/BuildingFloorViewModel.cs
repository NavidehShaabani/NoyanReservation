
namespace TowerApi.Models.BuildingFloor
{

    public class BuildingFloorModel
    {
        public long BuildingFloorId { get; set; }
        public long BuildingId { get; set; }

        public int FloorNumber { get; set; }
        public int FloorType { get; set; }

        public string FloorCode { get; set; } = string.Empty;
        public string FloorName { get; set; } = string.Empty;
        public string? FloorNameEn { get; set; }

        public int MaxUnits { get; set; }
        public bool IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }
        public int? UserCreater { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }

        public long UnitCount { get; set; }
    }

    public class BuildingFloorBulkSaveItem
    {
        public long BuildingFloorId { get; set; }
        public long BuildingId { get; set; }

        public int FloorNumber { get; set; }
        public int FloorType { get; set; }

        public string FloorCode { get; set; } = string.Empty;
        public string FloorName { get; set; } = string.Empty;
        public string? FloorNameEn { get; set; }

        public int MaxUnits { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class BuildingFloorBulkSaveRequest
    {
        public List<BuildingFloorBulkSaveItem> Items { get; set; } = new();
    }

    public class BuildingFloorInsertRequest
    {
        public long BuildingId { get; set; }

        public int FloorNumber { get; set; }
        public int FloorType { get; set; }

        public string FloorCode { get; set; } = string.Empty;
        public string FloorName { get; set; } = string.Empty;
        public string? FloorNameEn { get; set; }

        public int MaxUnits { get; set; } = 1;
    }

    public class BuildingFloorUpdateRequest
    {
        public int FloorNumber { get; set; }
        public int FloorType { get; set; }

        public string FloorCode { get; set; } = string.Empty;
        public string FloorName { get; set; } = string.Empty;
        public string? FloorNameEn { get; set; }

        public int MaxUnits { get; set; }
    }

    public class BuildingFloorSetActiveRequest
    {
        public bool IsActive { get; set; }
    }
}
