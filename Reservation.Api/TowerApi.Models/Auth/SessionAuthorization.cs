namespace TowerApi.Models.Auth
{
    public class SessionAuthorization
    {
        public Guid SessionId { get; set; }

        public long UserId { get; set; }

        public long? ActiveRoleId { get; set; }

        public string? RoleCode { get; set; }
    }
}
