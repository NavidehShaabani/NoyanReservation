using System.Data;
using Dapper;
using TowerApi.Models.Pricing.FinancialTransaction;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Pricing.FinancialTransaction
{
    public class FinancialTransactionRepository : IFinancialTransactionRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public FinancialTransactionRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<FinancialTransactionModel?> GetById(
            long financialTransactionId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<FinancialTransactionModel>(
                "dbo.Pricing_FinancialTransactions_GetById",
                new { FinancialTransactionId = financialTransactionId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IReadOnlyList<FinancialTransactionModel>> GetList(
            FinancialTransactionListRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var result = await connection.QueryAsync<FinancialTransactionModel>(
                "dbo.Pricing_FinancialTransactions_GetList",
                new
                {
                    request.BookingId,
                    request.EnrollmentId,
                    request.ParticipantId,
                    request.TransactionType,
                    request.TransactionStatus,
                    request.From,
                    request.To
                },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<FinancialTransactionModel?> Save(
            FinancialTransactionSaveRequest request,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<FinancialTransactionModel>(
                "dbo.Pricing_FinancialTransactions_Save",
                new
                {
                    request.FinancialTransactionId,
                    request.BookingId,
                    request.EnrollmentId,
                    request.ParticipantId,
                    request.TransactionType,
                    request.TransactionStatus,
                    request.Amount,
                    request.CurrencyCode,
                    request.PaymentMethod,
                    request.ExternalReference,
                    request.TransactionAt,
                    request.Notes,
                    request.NotesEn,
                    UserId = userId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<FinancialTransactionModel?> SetStatus(
            long financialTransactionId,
            byte transactionStatus,
            DateTime? transactionAt,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<FinancialTransactionModel>(
                "dbo.Pricing_FinancialTransactions_SetStatus",
                new
                {
                    FinancialTransactionId = financialTransactionId,
                    TransactionStatus = transactionStatus,
                    TransactionAt = transactionAt,
                    UserId = userId
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
