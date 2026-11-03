
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.BuildingStaircase
{
    public class BuildingStaircaseQueryRequest
    {
        [Range(1, long.MaxValue)]
        public long? BuildingId { get; set; }

        public string? Search { get; set; }

        [Range(1, 5)]
        public byte? StaircaseType { get; set; }

        public bool? IsEmergency { get; set; }

        public bool? IsActive { get; set; }

        public bool IncludeDeleted { get; set; } = false;

        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [Range(1, 500)]
        public int PageSize { get; set; } = 50;
    }
}
