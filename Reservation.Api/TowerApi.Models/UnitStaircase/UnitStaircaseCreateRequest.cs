using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.UnitStaircase
{
    public class UnitStaircaseCreateRequest
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long UnitId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long BuildingFloorId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long BuildingStaircaseId { get; set; }

        public bool IsPrimary { get; set; } = false;

        public bool IsActive { get; set; } = true;
    }
}
