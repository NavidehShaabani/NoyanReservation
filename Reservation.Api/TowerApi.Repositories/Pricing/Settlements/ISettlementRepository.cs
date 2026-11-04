using TowerApi.Models.Pricing.Settlements;
namespace TowerApi.Repositories.Pricing.Settlements
{
    public interface ISettlementRepository
    {
        Task<SettlementModel?> GetById(long settlementId);

        Task<IReadOnlyList<SettlementModel>> GetList(
            SettlementListRequest request);

        Task<SettlementModel?> Save(
            SettlementSaveRequest request,
            int userId);

        Task<SettlementModel?> SetStatus(
            long settlementId,
            byte settlementStatus,
            DateTime? settledAt,
            int userId);
    }
}
