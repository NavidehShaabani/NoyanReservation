namespace TowerApi.Models.Unit
{
    public class UnitViewModel
    {
        public long UnitId { get; set; }

        public long BuildingId { get; set; }

        public string UnitNumber { get; set; } = string.Empty;

        public int? FloorNumber { get; set; }

        public decimal? Area { get; set; }

        public byte? Bedrooms { get; set; }

        public string? UnitDescription { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UserCreater { get; set; }

        public int? UserUpdater { get; set; }
    }
}