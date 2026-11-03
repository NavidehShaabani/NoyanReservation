
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.BuildingFloor
{
    public class BuildingFloorCreateRequest
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long BuildingId { get; set; }

        public int FloorNumber { get; set; }

        [Required]
        [StringLength(40)]
        public string FloorCode { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string FloorName { get; set; } = string.Empty;

        [StringLength(200)]
        public string? FloorNameEn { get; set; }

        [Range(1, int.MaxValue)]
        public int MaxUnits { get; set; } = 1;

        public bool IsActive { get; set; } = true;
    }
}
