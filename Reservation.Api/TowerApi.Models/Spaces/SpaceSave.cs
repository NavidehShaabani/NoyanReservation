using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Spaces
{
    public sealed class SpaceSave
    {
        [Range(1, long.MaxValue)]
        public long OrgId { get; set; }

        public long? BuildingId { get; set; }
        public long? ParentSpaceId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string SpaceName { get; set; } = string.Empty;

        [StringLength(200)]
        public string? SpaceNameEn { get; set; }

        [Range(1, int.MaxValue)]
        public int SpaceType { get; set; }

        [Range(0, int.MaxValue)]
        public int? Capacity { get; set; }

        [Range(typeof(decimal), "0", "99999999.99")]
        public decimal? Area { get; set; }

        [StringLength(1000)]
        public string? SpaceDesc { get; set; }

        [StringLength(1000)]
        public string? SpaceDescEn { get; set; }

        public bool IsReservable { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
