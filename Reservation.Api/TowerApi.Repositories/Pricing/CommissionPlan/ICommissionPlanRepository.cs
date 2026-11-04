
using TowerApi.Models.Pricing.CommissionPlan;

namespace TowerApi.Repositories.Pricing.CommissionPlan
{
    public interface ICommissionPlanRepository
    {
        Task<CommissionPlanModel?> GetById(long commissionPlanId);

        Task<IReadOnlyList<CommissionPlanModel>> GetList(
            long? orgId,
            long? classSeriesId,
            bool onlyActive);

        Task<CommissionPlanModel?> Save(CommissionPlanSaveRequest request, int? userId);

        Task Delete(long commissionPlanId, int? userId);

        Task<CommissionPlanCalculationResult?> Calculate(
            long commissionPlanId,
            int participantCount,
            decimal commissionBaseAmount);
    }
}
