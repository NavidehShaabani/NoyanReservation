
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.BuildingFloor
{
    public class BuildingFloorQueryRequest
    {
        [Range(1, long.MaxValue)]
        public long? BuildingId { get; set; }

        public int? FloorNumber { get; set; }

        public string? Search { get; set; }

        public bool? IsActive { get; set; }

        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [Range(1, 500)]
        public int PageSize { get; set; } = 50;
    }
}
