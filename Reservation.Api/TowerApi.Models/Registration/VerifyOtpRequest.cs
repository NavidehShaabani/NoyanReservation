
namespace TowerApi.Models.Registration
{
    public class VerifyOtpRequest
    {
        public long UserId { get; set; }

        public long OtpRequestId { get; set; }

        public string OtpCode { get; set; } = string.Empty;

        public long? RoleId { get; set; }

        public long? UnitId { get; set; }

        public byte? RelationshipType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
