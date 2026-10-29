namespace TowerApi.Models.Booking.SpaceBooking
{
    public class SpaceBookingViewModel
    {
        public long BookingId { get; set; }
        public long OrgId { get; set; }
        public long BuildingId { get; set; }
        public long SpaceId { get; set; }

        public byte BookingType { get; set; }

        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        public byte BookingStatus { get; set; }

        public long? RequestedByParticipantId { get; set; }
        public long? ApprovedByUserId { get; set; }
        public DateTime? ApprovedAt { get; set; }

        public string? BookingTitle { get; set; }
        public string? BookingDescription { get; set; }
        public string? BookingDescriptionEn { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int? UserCreater { get; set; }
        public int? UserUpdater { get; set; }

        public string? SpaceName { get; set; }
        public string? SpaceNameEn { get; set; }
        public string? SpaceDesc { get; set; }
        public string? SpaceDescEn { get; set; }
    }
}
