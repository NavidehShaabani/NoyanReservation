namespace TowerApi.Models.Organization
{
    public class OrganizationViewModel
    {
        public long OrgId { get; set; }
        public string OrgName { get; set; } = string.Empty;
        public int OrgType { get; set; }
        public string GeoId { get; set; }
        public string? OrgDesc { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserCreater { get; set; }
        public int? UserUpdater { get; set; }
        public string OrgTypeNameFr { get; set; }
        public string OrgTypeNameEn { get; set; }
    }
}
