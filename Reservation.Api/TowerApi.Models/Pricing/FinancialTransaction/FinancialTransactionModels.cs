namespace TowerApi.Models.Pricing.FinancialTransaction
{
    public class FinancialTransactionModel
    {
        public long FinancialTransactionId { get; set; }
        public long? BookingId { get; set; }
        public long? EnrollmentId { get; set; }
        public long? ParticipantId { get; set; }

        public byte TransactionType { get; set; }
        public byte TransactionStatus { get; set; }

        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; } = "IRR";

        public byte? PaymentMethod { get; set; }
        public string? ExternalReference { get; set; }
        public DateTime? TransactionAt { get; set; }

        public string? Notes { get; set; }
        public string? NotesEn { get; set; }

        public DateTime CreatedAt { get; set; }
        public int? UserCreater { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }
    }

    public class FinancialTransactionSaveRequest
    {
        public long? FinancialTransactionId { get; set; }
        public long? BookingId { get; set; }
        public long? EnrollmentId { get; set; }
        public long? ParticipantId { get; set; }

        public byte TransactionType { get; set; }
        public byte TransactionStatus { get; set; } = 1;

        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; } = "IRR";

        public byte? PaymentMethod { get; set; }
        public string? ExternalReference { get; set; }
        public DateTime? TransactionAt { get; set; }

        public string? Notes { get; set; }
        public string? NotesEn { get; set; }
    }

    public class FinancialTransactionSetStatusRequest
    {
        public long FinancialTransactionId { get; set; }
        public byte TransactionStatus { get; set; }
        public DateTime? TransactionAt { get; set; }
    }

    public class FinancialTransactionListRequest
    {
        public long? BookingId { get; set; }
        public long? EnrollmentId { get; set; }
        public long? ParticipantId { get; set; }

        public byte? TransactionType { get; set; }
        public byte? TransactionStatus { get; set; }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
