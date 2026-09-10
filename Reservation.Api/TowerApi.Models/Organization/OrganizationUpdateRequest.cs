namespace TowerApi.Models.Organization
{
    public class OrganizationUpdateRequest
    {
        public string OrgName { get; set; } = string.Empty;

        public byte OrgType { get; set; }

        public long GeoId { get; set; }

        public string? OrgDesc { get; set; }

        public bool IsActive { get; set; } = true;
    }
}