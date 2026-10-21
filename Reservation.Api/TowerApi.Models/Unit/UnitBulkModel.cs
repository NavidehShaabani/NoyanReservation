

using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Unit
{
    public class UnitBulkSaveRequest
    {
        [Required]
        [MinLength(1)]
        public List<UnitBulkItem> Units { get; set; }
            = new List<UnitBulkItem>();
    }

    public class UnitBulkItem
    {
        public long? UnitId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long? BuildingId { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitNumber { get; set; } = string.Empty;

        public int? FloorNumber { get; set; }

        public decimal? Area { get; set; }

        public byte? Bedrooms { get; set; }

        [StringLength(1000)]
        public string? UnitDescription { get; set; }

        public bool? IsActive { get; set; }
    }
}
