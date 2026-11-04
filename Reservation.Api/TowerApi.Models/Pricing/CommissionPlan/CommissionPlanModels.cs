namespace TowerApi.Models.Pricing.CommissionPlan
{

    public class CommissionPlanModel
    {
        public long CommissionPlanId { get; set; }
        public long OrgId { get; set; }
        public long? ClassSeriesId { get; set; }

        public string PlanName { get; set; } = string.Empty;
        public string? PlanNameEn { get; set; }

        public byte CommissionMethod { get; set; }
        public byte CommissionBasis { get; set; }

        public decimal? FixedAmount { get; set; }
        public decimal? CommissionPercent { get; set; }

        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public int? UserCreater { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }
    }

    public class CommissionPlanSaveRequest
    {
        public long? CommissionPlanId { get; set; }
        public long OrgId { get; set; }
        public long? ClassSeriesId { get; set; }

        public string PlanName { get; set; } = string.Empty;
        public string? PlanNameEn { get; set; }

        public byte CommissionMethod { get; set; }
        public byte CommissionBasis { get; set; }

        public decimal? FixedAmount { get; set; }
        public decimal? CommissionPercent { get; set; }

        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public class CommissionPlanCalculateRequest
    {
        public long CommissionPlanId { get; set; }
        public int ParticipantCount { get; set; }
        public decimal CommissionBaseAmount { get; set; }
    }

    public class CommissionPlanCalculationResult
    {
        public long CommissionPlanId { get; set; }
        public long? CommissionTierId { get; set; }
        public decimal CommissionBaseAmount { get; set; }
        public decimal CommissionAmount { get; set; }
        public decimal NetAmount { get; set; }
    }
}
