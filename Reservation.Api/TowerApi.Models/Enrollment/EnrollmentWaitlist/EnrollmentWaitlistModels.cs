
namespace TowerApi.Models.Enrollment.EnrollmentWaitlist
{
    public class EnrollmentWaitlistItem
    {
        public long WaitlistId { get; set; }

        public long ClassSessionId { get; set; }

        public long ParticipantId { get; set; }

        public int QueueNumber { get; set; }

        public byte WaitlistStatus { get; set; }

        public DateTime JoinedAt { get; set; }

        public DateTime? OfferedAt { get; set; }

        public DateTime? ExpiresAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UserCreater { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UserUpdater { get; set; }

        // اطلاعات شرکت‌کننده
        public string? FullName { get; set; }

        public string? MobileNumber { get; set; }

        // اطلاعات جلسه
        public long? ClassSeriesId { get; set; }

        public string? SessionTitle { get; set; }

        public string? SessionTitleEn { get; set; }
    }

    public class EnrollmentWaitlistQuery
    {
        public long? ClassSessionId { get; set; }

        public long? ParticipantId { get; set; }

        public byte? WaitlistStatus { get; set; }
    }

    public class EnrollmentWaitlistJoinRequest
    {
        public long ClassSessionId { get; set; }

        public long ParticipantId { get; set; }
    }

    public class EnrollmentWaitlistUpdateStatusRequest
    {
        public byte WaitlistStatus { get; set; }

        public DateTime? OfferedAt { get; set; }

        public DateTime? ExpiresAt { get; set; }
    }
}
