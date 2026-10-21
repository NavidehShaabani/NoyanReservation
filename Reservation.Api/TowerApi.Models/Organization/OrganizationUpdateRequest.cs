namespace TowerApi.Models.Organization
{
    public class OrganizationUpdateRequest
    {
        public string OrgName { get; set; } = string.Empty;

        public int OrgType { get; set; }

        public string GeoId { get; set; }

        public string? OrgDesc { get; set; }

        public bool IsActive { get; set; } = true;
    }
}