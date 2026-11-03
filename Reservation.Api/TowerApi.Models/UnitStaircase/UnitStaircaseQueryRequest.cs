
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.UnitStaircase
{
    public class UnitStaircaseQueryRequest
    {
        [Range(1, long.MaxValue)]
        public long? UnitId { get; set; }

        [Range(1, long.MaxValue)]
        public long? BuildingFloorId { get; set; }

        [Range(1, long.MaxValue)]
        public long? BuildingStaircaseId { get; set; }

        public bool? IsPrimary { get; set; }

        public bool? IsActive { get; set; }

        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [Range(1, 500)]
        public int PageSize { get; set; } = 50;
    }
}
