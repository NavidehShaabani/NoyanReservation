using TowerApi.Models.Pricing.FinancialTransaction;

namespace TowerApi.Services.Pricing.FinancialTransaction
{
    public interface IFinancialTransactionService
    {
        Task<FinancialTransactionModel?> GetById(long financialTransactionId);

        Task<IReadOnlyList<FinancialTransactionModel>> GetList(
            FinancialTransactionListRequest request);

        Task<(int Code, string MessageKey, FinancialTransactionModel? Data)> Save(
            FinancialTransactionSaveRequest request);

        Task<(int Code, string MessageKey, FinancialTransactionModel? Data)> SetStatus(
            FinancialTransactionSetStatusRequest request);
    }
}
