
namespace TowerApi.Models.Profile
{
    public class CompleteProfileResidency
    {
        public long UserResidencyId { get; set; }

        public long UserId { get; set; }

        public long UnitId { get; set; }

        public byte RelationshipType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public string? Notes { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
