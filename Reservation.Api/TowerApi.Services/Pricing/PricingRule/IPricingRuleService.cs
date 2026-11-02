using TowerApi.Models.Pricing.PricingRule;

namespace TowerApi.Services.Pricing.PricingRule
{
    public interface IPricingRuleService
    {
        Task<PricingRuleItem?> GetById(
            long pricingRuleId);

        Task<IReadOnlyList<PricingRuleItem>> GetList(
            PricingRuleQuery query);

        Task<(
            int Code,
            string MessageKey,
            PricingRuleItem? Data)> Save(
                PricingRuleSaveRequest request,
                long? currentUserId);

        Task<(
            int Code,
            string MessageKey,
            PricingRuleItem? Data)> Delete(
                long pricingRuleId,
                long? currentUserId);

        Task<(
            int Code,
            string MessageKey,
            PricingRuleCalculation? Data)> CalculateAmount(
                PricingRuleCalculateRequest request);
    }
}
