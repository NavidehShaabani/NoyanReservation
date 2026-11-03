
namespace TowerApi.Models.BuildingConfiguration
{
    public class BuildingConfigurationQueryRequest
    {
        public long? BuildingId { get; set; }

        public bool? IsActive { get; set; }

        public bool IncludeDeleted { get; set; } = false;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 50;
    }
}
