
namespace TowerApi.Models.Booking.SpaceBooking
{
    public class SpaceBookingConflictRequest
    {
        public long SpaceId { get; set; }

        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        public long? ExcludeBookingId { get; set; }
    }
}
