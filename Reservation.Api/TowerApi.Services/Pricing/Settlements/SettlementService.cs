using System.Data.SqlClient;
using TowerApi.Models.Pricing.Settlements;
using TowerApi.Repositories.Pricing.Settlements;


namespace TowerApi.Services.Pricing.Settlements
{
    public class SettlementService : ISettlementService
    {
        private readonly ISettlementRepository _repository;
        private readonly ICurrentUser _currentUser;

        public SettlementService(
            ISettlementRepository repository,
            ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        public async Task<SettlementModel?> GetById(long settlementId)
        {
            if (settlementId <= 0)
                return null;

            return await _repository.GetById(settlementId);
        }

        public async Task<IReadOnlyList<SettlementModel>> GetList(
            SettlementListRequest request)
        {
            if (request.From.HasValue &&
                request.To.HasValue &&
                request.From.Value > request.To.Value)
            {
                return Array.Empty<SettlementModel>();
            }

            if (!AreOptionalIdsValid(
                    request.OrgId,
                    request.ClassSeriesId,
                    request.ClassSessionId,
                    request.EmployeeId))
            {
                return Array.Empty<SettlementModel>();
            }

            return await _repository.GetList(request);
        }

        public async Task<(
            int Code,
            string MessageKey,
            SettlementModel? Data)> Save(
            SettlementSaveRequest request)
        {
            if (request.SettlementId.HasValue &&
                request.SettlementId.Value <= 0)
            {
                return (400, "Settlement.InvalidId", null);
            }

            if (request.OrgId <= 0)
                return (400, "Settlement.InvalidOrgId", null);

            if (!AreOptionalIdsValid(
                    request.ClassSeriesId,
                    request.ClassSessionId,
                    request.CommissionPlanId,
                    request.EmployeeId))
            {
                return (400, "Settlement.InvalidRelatedId", null);
            }

            if (request.GrossAmount < 0 ||
                request.CommissionAmount < 0 ||
                request.NetAmount < 0)
            {
                return (400, "Settlement.NegativeAmount", null);
            }

            if (request.NetAmount !=
                request.GrossAmount - request.CommissionAmount)
            {
                return (400, "Settlement.InvalidNetAmount", null);
            }

            if (!request.EmployeeId.HasValue &&
                string.IsNullOrWhiteSpace(request.ExternalRecipientName))
            {
                return (400, "Settlement.RecipientRequired", null);
            }

            if (request.ExternalRecipientName?.Length > 200)
                return (400, "Settlement.RecipientNameTooLong", null);

            if (request.Notes?.Length > 1000 ||
                request.NotesEn?.Length > 1000)
            {
                return (400, "Settlement.NotesTooLong", null);
            }

            var userId = GetCurrentUserId();

            if (!userId.HasValue)
                return (401, "Common.Unauthorized", null);

            try
            {
                var data = await _repository.Save(request, userId.Value);

                if (data == null)
                    return (500, "Settlement.SaveFailed", null);

                return (
                    200,
                    request.SettlementId.HasValue
                        ? "Settlement.Updated"
                        : "Settlement.Created",
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
            SettlementModel? Data)> SetStatus(
            SettlementSetStatusRequest request)
        {
            if (request.SettlementId <= 0)
                return (400, "Settlement.InvalidId", null);

            var userId = GetCurrentUserId();

            if (!userId.HasValue)
                return (401, "Common.Unauthorized", null);

            try
            {
                var data = await _repository.SetStatus(
                    request.SettlementId,
                    request.SettlementStatus,
                    request.SettledAt,
                    userId.Value);

                if (data == null)
                    return (404, "Settlement.NotFound", null);

                return (200, "Settlement.StatusUpdated", data);
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

        private static bool AreOptionalIdsValid(params long?[] ids)
        {
            return ids.All(id => !id.HasValue || id.Value > 0);
        }

        private static (
            int Code,
            string MessageKey,
            SettlementModel? Data) MapSqlError(SqlException ex)
        {
            return ex.Number switch
            {
                51510 => (400, "Settlement.NegativeAmount", null),
                51511 => (400, "Settlement.InvalidNetAmount", null),
                51512 => (400, "Settlement.RecipientRequired", null),
                51513 => (404, "Settlement.NotFound", null),
                51514 => (404, "Settlement.NotFound", null),
                _ => (500, "Common.InternalServerError", null)
            };
        }
    }
}
