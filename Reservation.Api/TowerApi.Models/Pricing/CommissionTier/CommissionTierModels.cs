namespace TowerApi.Models.Pricing.CommissionTier
{
    public class CommissionTierModel
    {
        public long CommissionTierId { get; set; }
        public long CommissionPlanId { get; set; }

        public int MinParticipantCount { get; set; }
        public int? MaxParticipantCount { get; set; }

        public decimal? TierPercent { get; set; }
        public decimal? TierAmount { get; set; }

        public int TierOrder { get; set; }

        public DateTime CreatedAt { get; set; }
        public int? UserCreater { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }
    }

    public class CommissionTierSaveRequest
    {
        public long? CommissionTierId { get; set; }
        public long CommissionPlanId { get; set; }

        public int MinParticipantCount { get; set; }
        public int? MaxParticipantCount { get; set; }

        public decimal? TierPercent { get; set; }
        public decimal? TierAmount { get; set; }

        public int TierOrder { get; set; }
    }
}
