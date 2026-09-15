
namespace TowerApi.Models.Profile
{
    public class CompleteProfileUser
    {
        public long UserId { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? NationalId { get; set; }

        public int? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? AvatarUrl { get; set; }

        public bool PhoneVerified { get; set; }

        public bool IsActive { get; set; }
    }
}
