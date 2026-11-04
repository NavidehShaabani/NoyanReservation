using TowerApi.Models.Pricing.CommissionTier;

namespace TowerApi.Repositories.Pricing.CommissionTier
{
    public interface ICommissionTierRepository
    {
        Task<CommissionTierModel?> GetById(long commissionTierId);

        Task<IReadOnlyList<CommissionTierModel>> GetList(
            long commissionPlanId);

        Task<CommissionTierModel?> Save(
            CommissionTierSaveRequest request,
            int? userId);

        Task Delete(long commissionTierId);
    }
}
