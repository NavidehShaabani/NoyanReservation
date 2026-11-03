
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Unit
{
    public class UnitBulkItem
    {
        public long? UnitId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long BuildingId { get; set; }

        public long? BuildingFloorId { get; set; }

        [Required]
        [StringLength(100)]
        public string UnitNumber { get; set; } = string.Empty;

        public int? FloorNumber { get; set; }

        [Range(typeof(decimal), "0", "99999999.99")]
        public decimal? Area { get; set; }

        public byte? Bedrooms { get; set; }

        [StringLength(2000)]
        public string? UnitDescription { get; set; }

        public bool? IsActive { get; set; } = true;
    }
}
