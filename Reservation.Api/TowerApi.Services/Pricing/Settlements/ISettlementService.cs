using TowerApi.Models.Pricing.Settlements;

namespace TowerApi.Services.Pricing.Settlements
{
    public interface ISettlementService
    {
        Task<SettlementModel?> GetById(long settlementId);

        Task<IReadOnlyList<SettlementModel>> GetList(
            SettlementListRequest request);

        Task<(int Code, string MessageKey, SettlementModel? Data)> Save(
            SettlementSaveRequest request);

        Task<(int Code, string MessageKey, SettlementModel? Data)> SetStatus(
            SettlementSetStatusRequest request);
    }
}
