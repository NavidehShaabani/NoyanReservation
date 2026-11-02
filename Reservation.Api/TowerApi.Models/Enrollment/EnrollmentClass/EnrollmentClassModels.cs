namespace TowerApi.Models.Enrollment.EnrollmentClass
{
    public class EnrollmentClassItem
    {
        public long EnrollmentId { get; set; }
        public long ClassSessionId { get; set; }
        public long ParticipantId { get; set; }

        public byte EnrollmentStatus { get; set; }
        public DateTime RegisteredAt { get; set; }

        public long? PricingRuleId { get; set; }

        public string CurrencyCode { get; set; } = "IRR";

        public decimal BaseAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }

        public byte PaymentStatus { get; set; }

        public DateTime? CancelledAt { get; set; }
        public string? CancellationReason { get; set; }
        public string? CancellationReasonEn { get; set; }

        public byte? AttendanceStatus { get; set; }

        public DateTime CreatedAt { get; set; }
        public int? UserCreater { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }

        // اطلاعات شرکت‌کننده
        public string? FullName { get; set; }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }

        // اطلاعات جلسه
        public long? ClassSeriesId { get; set; }
        public string? SessionTitle { get; set; }
        public string? SessionTitleEn { get; set; }
        public long? BookingId { get; set; }
    }

    public class EnrollmentClassRegisterRequest
    {
        public long ClassSessionId { get; set; }
        public long ParticipantId { get; set; }

        public long? PricingRuleId { get; set; }

        public string CurrencyCode { get; set; } = "IRR";

        public decimal BaseAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }

        public byte PaymentStatus { get; set; } = 1;
    }

    public class EnrollmentClassQuery
    {
        public long? ClassSessionId { get; set; }
        public long? ParticipantId { get; set; }

        public byte? EnrollmentStatus { get; set; }
        public byte? PaymentStatus { get; set; }
    }

    public class EnrollmentClassCancelRequest
    {
        public string? CancellationReason { get; set; }
        public string? CancellationReasonEn { get; set; }
    }

    public class EnrollmentClassPaymentStatusRequest
    {
        public byte PaymentStatus { get; set; }
    }

    public class EnrollmentClassCapacity
    {
        public long ClassSessionId { get; set; }
        public int Capacity { get; set; }
        public long TotalEnrollments { get; set; }
        public bool HasCapacity { get; set; }
    }
}
