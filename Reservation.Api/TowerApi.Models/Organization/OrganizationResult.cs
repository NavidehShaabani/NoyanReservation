namespace TowerApi.Models.Organization
{
    public class OrganizationResult
    {
        public int ResultCode { get; set; }

        public string ResultMessage { get; set; } = string.Empty;

        public Organizations? Organization { get; set; }

        public List<Organizations> Organizations { get; set; } = new();
    }
}
