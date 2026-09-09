namespace TowerApi.Models.Organization
{
    public class OrganizationResult
    {
        public int ResultCode { get; set; }

        public string ResultMessage { get; set; } = string.Empty;

        public Organization? Organization { get; set; }

        public List<Organization> Organizations { get; set; } = new();
    }
}
