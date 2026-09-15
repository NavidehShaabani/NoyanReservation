
namespace TowerApi.Models.Profile
{
    public class CompleteProfileResponse
    {
        public CompleteProfileUser? User { get; set; }

        public CompleteProfileDetails? Profile { get; set; }

        public List<CompleteProfileResidency> Residencies { get; set; }
            = new();
    }
}
