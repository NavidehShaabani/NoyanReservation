using System.Data.SqlClient;
using TowerApi.Models.Pricing.CommissionTier;
using TowerApi.Repositories.Pricing.CommissionTier;

namespace TowerApi.Services.Pricing.CommissionTier
{
    public class CommissionTierService : ICommissionTierService
    {
        private readonly ICommissionTierRepository _repository;
        private readonly ICurrentUser _currentUser;

        public CommissionTierService(
            ICommissionTierRepository repository,
            ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        public Task<CommissionTierModel?> GetById(long commissionTierId)
        {
            return _repository.GetById(commissionTierId);
        }

        public Task<IReadOnlyList<CommissionTierModel>> GetList(
            long commissionPlanId)
        {
            return _repository.GetList(commissionPlanId);
        }

        public async Task<(
            int Code,
            string MessageKey,
            CommissionTierModel? Data)> Save(
            CommissionTierSaveRequest request)
        {
            if (request.CommissionPlanId <= 0 ||
                request.MinParticipantCount < 0 ||
                (request.MaxParticipantCount.HasValue &&
                 request.MaxParticipantCount.Value < request.MinParticipantCount))
            {
                return (400, "CommissionTier.InvalidRange", null);
            }

            if ((request.TierPercent.HasValue &&
                 (request.TierPercent.Value < 0 ||
                  request.TierPercent.Value > 100)) ||
                (request.TierAmount.HasValue &&
                 request.TierAmount.Value < 0))
            {
                return (400, "CommissionTier.InvalidAmount", null);
            }

            if (!TryGetUserId(out var userId))
            {
                return (401, "Common.Unauthorized", null);
            }

            try
            {
                var result = await _repository.Save(request, userId);

                if (result == null)
                    return (500, "Common.OperationFailed", null);

                return (200, "CommissionTier.Saved", result);
            }
            catch (SqlException ex)
            {
                return MapSqlError(ex);
            }
        }

        public async Task<(
            int Code,
            string MessageKey,
            CommissionTierModel? Data)> Delete(
            long commissionTierId)
        {
            if (commissionTierId <= 0)
            {
                return (400, "CommissionTier.InvalidId", null);
            }

            try
            {
                await _repository.Delete(commissionTierId);

                return (200, "CommissionTier.Deleted", null);
            }
            catch (SqlException ex)
            {
                return MapSqlError(ex);
            }
        }

        private bool TryGetUserId(out int? userId)
        {
            userId = null;

            var currentUserId = _currentUser.UserId;

            if (!currentUserId.HasValue ||
                currentUserId.Value <= 0 ||
                currentUserId.Value > int.MaxValue)
            {
                return false;
            }

            userId = (int)currentUserId.Value;
            return true;
        }

        private static (
            int Code,
            string MessageKey,
            CommissionTierModel? Data) MapSqlError(SqlException ex)
        {
            return ex.Number switch
            {
                51220 => (400, "CommissionTier.InvalidRange", null),
                51221 => (400, "CommissionTier.InvalidAmount", null),
                51222 => (404, "CommissionTier.NotFound", null),

                // قید یکتای CommissionPlanId و TierOrder
                2601 or 2627 =>
                    (409, "CommissionTier.DuplicateOrder", null),

                _ => (500, "Common.OperationFailed", null)
            };
        }
    }
}
