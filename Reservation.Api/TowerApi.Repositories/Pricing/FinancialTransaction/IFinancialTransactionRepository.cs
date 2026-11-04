using TowerApi.Models.Pricing.FinancialTransaction;

namespace TowerApi.Repositories.Pricing.FinancialTransaction
{
    public interface IFinancialTransactionRepository
    {
        Task<FinancialTransactionModel?> GetById(long financialTransactionId);

        Task<IReadOnlyList<FinancialTransactionModel>> GetList(
            FinancialTransactionListRequest request);

        Task<FinancialTransactionModel?> Save(
            FinancialTransactionSaveRequest request,
            int userId);

        Task<FinancialTransactionModel?> SetStatus(
            long financialTransactionId,
            byte transactionStatus,
            DateTime? transactionAt,
            int userId);
    }
}
