
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.BuildingFloorStaircase
{
    public class BuildingFloorStaircaseQueryRequest
    {
        [Range(1, long.MaxValue)]
        public long? BuildingId { get; set; }

        [Range(1, long.MaxValue)]
        public long? BuildingFloorId { get; set; }

        [Range(1, long.MaxValue)]
        public long? BuildingStaircaseId { get; set; }

        public bool? IsActive { get; set; }

        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [Range(1, 500)]
        public int PageSize { get; set; } = 50;
    }
}
