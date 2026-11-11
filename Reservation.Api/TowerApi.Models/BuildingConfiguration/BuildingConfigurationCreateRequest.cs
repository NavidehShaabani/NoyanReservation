
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.BuildingConfiguration
{
    public class BuildingConfigurationCreateRequest
    {
        [Range(1, long.MaxValue)]
        public long BuildingId { get; set; }

        [Range(0, int.MaxValue)]
        public int BasementFloorCount { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int GroundFloorCount { get; set; } = 1;

        [Range(0, int.MaxValue)]
        public int AboveGroundFloorCount { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int StaircaseCount { get; set; } = 1;

        [Range(0, int.MaxValue)]
        public int ElevatorCount { get; set; } = 0;

        [Range(1, int.MaxValue)]
        public int DefaultUnitsPerFloor { get; set; } = 1;

        public int FloorNamingType { get; set; } 

        public int FloorNumberStart { get; set; } = 1;

        public int UnitNamingType { get; set; } 

        public int UnitNumberPattern { get; set; }

        [StringLength(1)]
        public string? UnitLetterStart { get; set; }

        [StringLength(1)]
        public string? UnitLetterEnd { get; set; }

        public bool IsUnitNumberUnique { get; set; } = true;

        public bool ResetUnitNumberPerFloor { get; set; } = true;

        public bool AllowExceedFloorCapacity { get; set; } = false;

        public bool IsActive { get; set; } = true;
    }
}
