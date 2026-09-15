namespace TowerApi.Models.Profile
{
    public class CompleteProfileRequest
    {
        // =========================
        // Users
        // =========================

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? NationalId { get; set; }

        public int? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? AvatarUrl { get; set; }


        // =========================
        // UserProfiles
        // =========================

        public string? FatherName { get; set; }

        public string? BirthPlace { get; set; }

        public string? LandlinePhone { get; set; }

        public string? UserPostalCode { get; set; }

        public string? UserAddress { get; set; }

        public string? EmergencyContactName { get; set; }

        public string? EmergencyContactMobile { get; set; }

        public string? EmergencyContactRelation { get; set; }

        public string? ProfileNotes { get; set; }


        // =========================
        // UserResidencies
        // =========================

        public long? UnitId { get; set; }

        public byte? RelationshipType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? ResidencyNotes { get; set; }
    }
}
