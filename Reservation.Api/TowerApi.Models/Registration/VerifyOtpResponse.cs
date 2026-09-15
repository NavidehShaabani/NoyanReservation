namespace TowerApi.Models.Registration
{
    public class VerifyOtpResponse
    {
        public long UserId { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Gender { get; set; }

        public bool PhoneVerified { get; set; }

        public bool IsActive { get; set; }
    }
}
