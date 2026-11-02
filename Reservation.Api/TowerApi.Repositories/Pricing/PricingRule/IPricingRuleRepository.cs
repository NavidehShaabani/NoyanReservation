using TowerApi.Models.Pricing.PricingRule;

namespace TowerApi.Repositories.Pricing.PricingRule
{
    public interface IPricingRuleRepository
    {
        Task<PricingRuleItem?> GetById(
            long pricingRuleId);

        Task<IReadOnlyList<PricingRuleItem>> GetList(
            PricingRuleQuery query);

        Task<PricingRuleItem?> Save(
            PricingRuleSaveRequest request,
            int? currentUserId);

        Task Delete(
            long pricingRuleId,
            int? currentUserId);

        Task<PricingRuleCalculation?> CalculateAmount(
            PricingRuleCalculateRequest request);
    }
}
