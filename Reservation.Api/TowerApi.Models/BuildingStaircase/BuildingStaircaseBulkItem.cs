
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.BuildingStaircase
{
    public class BuildingStaircaseBulkItem
    {
        public long? BuildingStaircaseId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long BuildingId { get; set; }

        [Required]
        [StringLength(60)]
        public string StaircaseCode { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string StaircaseName { get; set; } = string.Empty;

        [StringLength(200)]
        public string? StaircaseNameEn { get; set; }

        public int StaircaseType { get; set; }

        public bool IsEmergency { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Range(1, int.MaxValue)]
        public int DisplayOrder { get; set; } = 1;

        public bool? IsActive { get; set; }
    }
}
