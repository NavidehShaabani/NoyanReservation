namespace TowerApi.Models.Organization
{
    public class OrganizationQueryRequest
    {
        public string? Search { get; set; }

        public byte? OrgType { get; set; }

        public long? GeoId { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 50;

        public bool IncludeDeleted { get; set; } = false;
    }
}