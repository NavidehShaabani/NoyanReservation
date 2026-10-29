

namespace TowerApi.Models.Booking.SpaceBooking
{
    public class SpaceBookingQueryRequest
    {
        public long? SpaceId { get; set; }
        public long? OrgId { get; set; }

        public DateTime? StartFrom { get; set; }
        public DateTime? StartTo { get; set; }

        public byte? BookingStatus { get; set; }
        public byte? BookingType { get; set; }

        public bool OnlyActive { get; set; } = false;
    }
}
