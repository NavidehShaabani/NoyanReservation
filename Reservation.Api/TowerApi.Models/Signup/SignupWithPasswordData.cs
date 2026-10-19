namespace TowerApi.Models.Signup
{
    public class SignupWithPasswordData
    {
        public long UserId { get; set; }
        public string? Username { get; set; }
        public long OrgId { get; set; }
        public string? OrgName { get; set; }
        public int OrgType { get; set; }
        public string? GeoId { get; set; }
        public long RoleId { get; set; }
    }
}
