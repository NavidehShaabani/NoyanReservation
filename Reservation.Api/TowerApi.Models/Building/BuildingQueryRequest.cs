namespace TowerApi.Models.Building
{
    public class BuildingQueryRequest
    {
        public string? Search { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 50;

        public bool IncludeDeleted { get; set; } = false;
    }
}