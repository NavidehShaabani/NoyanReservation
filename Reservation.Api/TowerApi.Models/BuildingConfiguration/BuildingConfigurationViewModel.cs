
namespace TowerApi.Models.BuildingConfiguration
{
    public class BuildingConfigurationViewModel
    {
        public long BuildingConfigurationId { get; set; }

        public long BuildingId { get; set; }

        public int BasementFloorCount { get; set; }

        public int GroundFloorCount { get; set; }

        public int AboveGroundFloorCount { get; set; }

        public int StaircaseCount { get; set; }

        public int ElevatorCount { get; set; }

        public int DefaultUnitsPerFloor { get; set; }

        public byte FloorNamingType { get; set; }

        public int FloorNumberStart { get; set; }

        public byte UnitNamingType { get; set; }

        public string UnitNumberPattern { get; set; } = string.Empty;

        public string? UnitLetterStart { get; set; }

        public string? UnitLetterEnd { get; set; }

        public bool IsUnitNumberUnique { get; set; }

        public bool ResetUnitNumberPerFloor { get; set; }

        public bool AllowExceedFloorCapacity { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UserCreater { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UserUpdater { get; set; }
    }
}
