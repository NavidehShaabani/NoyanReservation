
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Unit
{
    public class UnitQueryRequest
    {
        [Range(1, long.MaxValue)]
        public long? BuildingId { get; set; }

        [Range(1, long.MaxValue)]
        public long? BuildingFloorId { get; set; }

        public string? Search { get; set; }

        public int? FloorNumber { get; set; }

        public bool? IsActive { get; set; }

        public bool IncludeDeleted { get; set; } = false;

        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [Range(1, 500)]
        public int PageSize { get; set; } = 50;
    }
}
