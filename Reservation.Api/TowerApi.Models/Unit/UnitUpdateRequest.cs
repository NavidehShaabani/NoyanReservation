namespace TowerApi.Models.Unit
{
    public class UnitUpdateRequest
    {
        public long BuildingId { get; set; }

        public string UnitNumber { get; set; } = string.Empty;

        public int? FloorNumber { get; set; }

        public decimal? Area { get; set; }

        public byte? Bedrooms { get; set; }

        public string? UnitDescription { get; set; }

        public bool IsActive { get; set; } = true;
    }
}