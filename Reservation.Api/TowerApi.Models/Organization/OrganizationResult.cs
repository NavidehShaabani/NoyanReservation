namespace TowerApi.Models.Organization
{
    public class OrganizationResult
    {
        public int ResultCode { get; set; }

        public string ResultMessage { get; set; } = string.Empty;

        public OrganizationViewModel? Organization { get; set; }

        public List<OrganizationViewModel> Organizations { get; set; } = new();
    }
}
