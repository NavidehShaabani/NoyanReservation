using TowerApi.Models.Pricing.CommissionPlan;

namespace TowerApi.Services.Pricing.CommissionPlan
{
    public interface ICommissionPlanService
    {
        Task<CommissionPlanModel?> GetById(long commissionPlanId);

        Task<IReadOnlyList<CommissionPlanModel>> GetList(
            long? orgId,
            long? classSeriesId,
            bool onlyActive);

        Task<(int Code, string MessageKey, CommissionPlanModel? Data)> Save(
            CommissionPlanSaveRequest request);

        Task<(int Code, string MessageKey, CommissionPlanModel? Data)> Delete(
            long commissionPlanId);

        Task<(int Code, string MessageKey, CommissionPlanCalculationResult? Data)> Calculate(
            CommissionPlanCalculateRequest request);
    }
}
