using TowerApi.Models.Pricing.CommissionTier;
namespace TowerApi.Services.Pricing.CommissionTier
{
    public interface ICommissionTierService
    {
        Task<CommissionTierModel?> GetById(long commissionTierId);

        Task<IReadOnlyList<CommissionTierModel>> GetList(
            long commissionPlanId);

        Task<(int Code, string MessageKey, CommissionTierModel? Data)> Save(
            CommissionTierSaveRequest request);

        Task<(int Code, string MessageKey, CommissionTierModel? Data)> Delete(
            long commissionTierId);
    }
}
