namespace TowerApi.Models.Booking.ClassSession
{

    public sealed class ClassSessionModel
    {
        public long ClassSessionId { get; set; }
        public long ClassSeriesId { get; set; }
        public long BookingId { get; set; }
        public string? SessionTitle { get; set; }
        public string? SessionTitleEn { get; set; }
        public byte SessionStatus { get; set; } = 1;
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public int? UserCreater { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }

        // در خروجی رویه Booking_ClassSessions_GetById
        public string? ClassName { get; set; }
        public string? ClassNameEn { get; set; }
    }

    public sealed class ClassSessionSaveRequest
    {
        public long? ClassSessionId { get; set; }
        public long ClassSeriesId { get; set; }
        public long BookingId { get; set; }
        public string? SessionTitle { get; set; }
        public string? SessionTitleEn { get; set; }
        public byte SessionStatus { get; set; } = 1;
        public bool IsActive { get; set; } = true;
    }
}
