

namespace TowerApi.Models.Booking.RentalParticipants
{
    public class RentalParticipantSaveRequest
    {
        public long? RentalParticipantId { get; set; }
        public long BookingId { get; set; }
        public long ParticipantId { get; set; }
        public byte ParticipantRole { get; set; } = 1;
        public string? Notes { get; set; }
        public string? NotesEn { get; set; }
    }

    public class RentalParticipantQueryRequest
    {
        public long? BookingId { get; set; }
        public long? ParticipantId { get; set; }
    }

    public class RentalParticipantViewModel
    {
        public long RentalParticipantId { get; set; }
        public long BookingId { get; set; }
        public long ParticipantId { get; set; }
        public byte ParticipantRole { get; set; }

        public string? Notes { get; set; }
        public string? NotesEn { get; set; }

        public DateTime CreatedAt { get; set; }
        public int? UserCreater { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }

        // اطلاعاتی که Stored Procedure از Booking_Participants برمی‌گرداند
        public string? FullName { get; set; }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
        public byte? ParticipantType { get; set; }
    }
}
