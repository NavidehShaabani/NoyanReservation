namespace TowerApi.Models.Pricing.Settlements
{
    public class SettlementModel
    {
        public long SettlementId { get; set; }
        public long OrgId { get; set; }

        public long? ClassSeriesId { get; set; }
        public long? ClassSessionId { get; set; }
        public long? CommissionPlanId { get; set; }

        public long? EmployeeId { get; set; }
        public string? ExternalRecipientName { get; set; }

        public byte SettlementRole { get; set; }

        public decimal GrossAmount { get; set; }
        public decimal CommissionAmount { get; set; }
        public decimal NetAmount { get; set; }

        public byte SettlementStatus { get; set; }
        public DateTime? SettledAt { get; set; }

        public string? Notes { get; set; }
        public string? NotesEn { get; set; }

        public DateTime CreatedAt { get; set; }
        public int? UserCreater { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }
    }

    public class SettlementSaveRequest
    {
        public long? SettlementId { get; set; }
        public long OrgId { get; set; }

        public long? ClassSeriesId { get; set; }
        public long? ClassSessionId { get; set; }
        public long? CommissionPlanId { get; set; }

        public long? EmployeeId { get; set; }
        public string? ExternalRecipientName { get; set; }

        public byte SettlementRole { get; set; }

        public decimal GrossAmount { get; set; }
        public decimal CommissionAmount { get; set; }
        public decimal NetAmount { get; set; }

        public byte SettlementStatus { get; set; } = 1;
        public DateTime? SettledAt { get; set; }

        public string? Notes { get; set; }
        public string? NotesEn { get; set; }
    }

    public class SettlementSetStatusRequest
    {
        public long SettlementId { get; set; }
        public byte SettlementStatus { get; set; }
        public DateTime? SettledAt { get; set; }
    }

    public class SettlementListRequest
    {
        public long? OrgId { get; set; }
        public long? ClassSeriesId { get; set; }
        public long? ClassSessionId { get; set; }
        public long? EmployeeId { get; set; }

        public byte? SettlementStatus { get; set; }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
