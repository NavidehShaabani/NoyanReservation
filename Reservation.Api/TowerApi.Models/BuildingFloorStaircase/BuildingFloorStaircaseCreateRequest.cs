
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.BuildingFloorStaircase
{
    public class BuildingFloorStaircaseCreateRequest
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long BuildingId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long BuildingFloorId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long BuildingStaircaseId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
