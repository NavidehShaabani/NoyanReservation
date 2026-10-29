

namespace TowerApi.Models.Booking.SpaceBooking
{
    public class SpaceBookingUpdateRequest
    {
        public long OrgId { get; set; }
        public long BuildingId { get; set; }
        public long SpaceId { get; set; }

        public byte BookingType { get; set; }

        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        public byte BookingStatus { get; set; } = 1;

        public long? RequestedByParticipantId { get; set; }

        public string? BookingTitle { get; set; }
        public string? BookingDescription { get; set; }
        public string? BookingDescriptionEn { get; set; }
    }
}
