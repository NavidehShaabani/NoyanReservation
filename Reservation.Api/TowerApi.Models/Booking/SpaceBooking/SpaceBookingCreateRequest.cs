
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Booking.SpaceBooking
{
    public class SpaceBookingCreateRequest
    {
        [Range(1, long.MaxValue)]
        public long OrgId { get; set; }

        [Range(1, long.MaxValue)]
        public long BuildingId { get; set; }

        [Range(1, long.MaxValue)]
        public long SpaceId { get; set; }

        [Range(1, 2)]
        public byte BookingType { get; set; }

        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        [Range(1, 6)]
        public byte BookingStatus { get; set; } = 1;

        public long? RequestedByParticipantId { get; set; }

        [MaxLength(200)]
        public string? BookingTitle { get; set; }

        [MaxLength(1000)]
        public string? BookingDescription { get; set; }

        [MaxLength(1000)]
        public string? BookingDescriptionEn { get; set; }
    }
}
