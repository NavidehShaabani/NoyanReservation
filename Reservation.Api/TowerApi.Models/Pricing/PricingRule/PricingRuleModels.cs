namespace TowerApi.Models.Pricing.PricingRule
{
    public class PricingRuleItem
    {
        public long PricingRuleId { get; set; }

        public long OrgId { get; set; }

        public long? BuildingId { get; set; }

        public long? SpaceId { get; set; }

        public string RuleName { get; set; } = string.Empty;

        public string? RuleNameEn { get; set; }

        public byte BookingType { get; set; }

        public byte ParticipantCategory { get; set; }

        public byte PriceMethod { get; set; }

        public decimal Amount { get; set; }

        public string CurrencyCode { get; set; } = "IRR";

        public int? MinParticipants { get; set; }

        public int? MaxParticipants { get; set; }

        public bool RequiresAmenities { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }

        public int Priority { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UserCreater { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UserUpdater { get; set; }
    }

    public class PricingRuleQuery
    {
        public long? OrgId { get; set; }

        public byte? BookingType { get; set; }

        public byte? ParticipantCategory { get; set; }

        public long? SpaceId { get; set; }

        public bool OnlyActive { get; set; } = true;

        public DateTime? At { get; set; }
    }

    public class PricingRuleSaveRequest
    {
        public long? PricingRuleId { get; set; }

        public long OrgId { get; set; }

        public long? BuildingId { get; set; }

        public long? SpaceId { get; set; }

        public string RuleName { get; set; } = string.Empty;

        public string? RuleNameEn { get; set; }

        public byte BookingType { get; set; }

        public byte ParticipantCategory { get; set; }

        public byte PriceMethod { get; set; }

        public decimal Amount { get; set; }

        public string CurrencyCode { get; set; } = "IRR";

        public int? MinParticipants { get; set; }

        public int? MaxParticipants { get; set; }

        public bool RequiresAmenities { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }

        public int Priority { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public class PricingRuleCalculateRequest
    {
        public long OrgId { get; set; }

        public byte BookingType { get; set; }

        public byte ParticipantCategory { get; set; }

        public long? SpaceId { get; set; }

        public int? ParticipantCount { get; set; }

        public DateTime? StartAt { get; set; }

        public DateTime? EndAt { get; set; }
    }

    public class PricingRuleCalculation
    {
        public long PricingRuleId { get; set; }

        public string RuleName { get; set; } = string.Empty;

        public string? RuleNameEn { get; set; }

        public byte PriceMethod { get; set; }

        public decimal UnitAmount { get; set; }

        public decimal CalculatedAmount { get; set; }

        public string CurrencyCode { get; set; } = "IRR";
    }
}
