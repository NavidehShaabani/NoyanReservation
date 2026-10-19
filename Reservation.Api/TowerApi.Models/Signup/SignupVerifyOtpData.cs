namespace TowerApi.Models.Signup
{
    public class SignupVerifyOtpData
    {
        public long UserId { get; set; }
        public string? Username { get; set; }
        public string? Mobile { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long OrgId { get; set; }
        public string? OrgName { get; set; }
        public int OrgType { get; set; }
        public string? GeoId { get; set; }
        public long RoleId { get; set; }
    }
}
