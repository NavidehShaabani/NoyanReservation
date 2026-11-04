using System.Data.SqlClient;
using TowerApi.Models.Pricing.FinancialTransaction;
using TowerApi.Repositories.Pricing.FinancialTransaction;

namespace TowerApi.Services.Pricing.FinancialTransaction
{
    public class FinancialTransactionService : IFinancialTransactionService
    {
        private readonly IFinancialTransactionRepository _repository;
        private readonly ICurrentUser _currentUser;

        public FinancialTransactionService(
            IFinancialTransactionRepository repository,
            ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        public async Task<FinancialTransactionModel?> GetById(
            long financialTransactionId)
        {
            if (financialTransactionId <= 0)
                return null;

            return await _repository.GetById(financialTransactionId);
        }

        public async Task<IReadOnlyList<FinancialTransactionModel>> GetList(
            FinancialTransactionListRequest request)
        {
            if (request.From.HasValue &&
                request.To.HasValue &&
                request.From.Value > request.To.Value)
            {
                return Array.Empty<FinancialTransactionModel>();
            }

            return await _repository.GetList(request);
        }

        public async Task<(
            int Code,
            string MessageKey,
            FinancialTransactionModel? Data)> Save(
            FinancialTransactionSaveRequest request)
        {
            if (request.FinancialTransactionId.HasValue &&
                request.FinancialTransactionId.Value <= 0)
            {
                return (400, "FinancialTransaction.InvalidId", null);
            }

            if (request.Amount <= 0)
                return (400, "FinancialTransaction.InvalidAmount", null);

            // باید دقیقاً یکی از BookingId یا EnrollmentId مقدار داشته باشد.
            if ((request.BookingId.HasValue && request.BookingId.Value <= 0) ||
                (request.EnrollmentId.HasValue && request.EnrollmentId.Value <= 0))
            {
                return (400, "FinancialTransaction.InvalidReference", null);
            }

            if (request.BookingId.HasValue == request.EnrollmentId.HasValue)
                return (400, "FinancialTransaction.ExactlyOneReferenceRequired", null);

            if (request.ParticipantId.HasValue && request.ParticipantId.Value <= 0)
                return (400, "FinancialTransaction.InvalidParticipantId", null);

            if (string.IsNullOrWhiteSpace(request.CurrencyCode) ||
                request.CurrencyCode.Trim().Length != 3)
            {
                return (400, "FinancialTransaction.InvalidCurrencyCode", null);
            }

            if (request.ExternalReference?.Length > 200)
                return (400, "FinancialTransaction.ExternalReferenceTooLong", null);

            if (request.Notes?.Length > 1000 ||
                request.NotesEn?.Length > 1000)
            {
                return (400, "FinancialTransaction.NotesTooLong", null);
            }

            var userId = GetCurrentUserId();

            if (!userId.HasValue)
                return (401, "Common.Unauthorized", null);

            try
            {
                var data = await _repository.Save(request, userId.Value);

                if (data == null)
                    return (500, "FinancialTransaction.SaveFailed", null);

                return (
                    200,
                    request.FinancialTransactionId.HasValue
                        ? "FinancialTransaction.Updated"
                        : "FinancialTransaction.Created",
                    data);
            }
            catch (SqlException ex)
            {
                return MapSqlError(ex);
            }
        }

        public async Task<(
            int Code,
            string MessageKey,
            FinancialTransactionModel? Data)> SetStatus(
            FinancialTransactionSetStatusRequest request)
        {
            if (request.FinancialTransactionId <= 0)
                return (400, "FinancialTransaction.InvalidId", null);

            var userId = GetCurrentUserId();

            if (!userId.HasValue)
                return (401, "Common.Unauthorized", null);

            try
            {
                var data = await _repository.SetStatus(
                    request.FinancialTransactionId,
                    request.TransactionStatus,
                    request.TransactionAt,
                    userId.Value);

                if (data == null)
                    return (404, "FinancialTransaction.NotFound", null);

                return (200, "FinancialTransaction.StatusUpdated", data);
            }
            catch (SqlException ex)
            {
                return MapSqlError(ex);
            }
        }

        private int? GetCurrentUserId()
        {
            var userId = _currentUser.UserId;

            if (!userId.HasValue ||
                userId.Value <= 0 ||
                userId.Value > int.MaxValue)
            {
                return null;
            }

            return (int)userId.Value;
        }

        private static (
            int Code,
            string MessageKey,
            FinancialTransactionModel? Data) MapSqlError(SqlException ex)
        {
            return ex.Number switch
            {
                51501 => (400, "FinancialTransaction.InvalidAmount", null),
                51502 => (400, "FinancialTransaction.ExactlyOneReferenceRequired", null),
                51503 => (404, "FinancialTransaction.NotFound", null),
                51504 => (404, "FinancialTransaction.NotFound", null),
                _ => (500, "Common.InternalServerError", null)
            };
        }
    }
}
