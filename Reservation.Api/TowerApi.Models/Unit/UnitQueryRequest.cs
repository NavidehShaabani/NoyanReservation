namespace TowerApi.Models.Unit
{
    public class UnitQueryRequest
    {
        public long? BuildingId { get; set; }

        public string? Search { get; set; }

        public int? FloorNumber { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 50;

        public bool IncludeDeleted { get; set; } = false;
    }
}