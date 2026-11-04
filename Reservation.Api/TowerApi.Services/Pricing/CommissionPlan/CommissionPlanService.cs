using System.Data.SqlClient;
using TowerApi.Models.Pricing.CommissionPlan;
using TowerApi.Repositories.Pricing.CommissionPlan;

namespace TowerApi.Services.Pricing.CommissionPlan
{
    public class CommissionPlanService : ICommissionPlanService
    {
        private readonly ICommissionPlanRepository _repository;
        private readonly ICurrentUser _currentUser;

        public CommissionPlanService(
            ICommissionPlanRepository repository,
            ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        public Task<CommissionPlanModel?> GetById(long commissionPlanId)
        {
            return _repository.GetById(commissionPlanId);
        }

        public Task<IReadOnlyList<CommissionPlanModel>> GetList(
            long? orgId,
            long? classSeriesId,
            bool onlyActive)
        {
            return _repository.GetList(orgId, classSeriesId, onlyActive);
        }

        public async Task<(int Code, string MessageKey, CommissionPlanModel? Data)> Save(
            CommissionPlanSaveRequest request)
        {
            if (request.OrgId <= 0 ||
                string.IsNullOrWhiteSpace(request.PlanName))
            {
                return (400, "CommissionPlan.InvalidInput", null);
            }

            if (request.FixedAmount < 0 ||
                request.CommissionPercent < 0 ||
                request.CommissionPercent > 100)
            {
                return (400, "CommissionPlan.InvalidAmount", null);
            }

            if (request.ValidTo.HasValue &&
                request.ValidTo.Value < request.ValidFrom)
            {
                return (400, "CommissionPlan.InvalidDateRange", null);
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

                return (200, "CommissionPlan.Saved", result);
            }
            catch (SqlException ex)
            {
                return MapSqlError(ex);
            }
        }

        public async Task<(int Code, string MessageKey, CommissionPlanModel? Data)> Delete(
            long commissionPlanId)
        {
            if (commissionPlanId <= 0)
                return (400, "CommissionPlan.InvalidId", null);

            if (!TryGetUserId(out var userId))
                return (401, "Common.Unauthorized", null);

            try
            {
                await _repository.Delete(commissionPlanId, userId);

                return (200, "CommissionPlan.Deleted", null);
            }
            catch (SqlException ex)
            {
                return MapSqlError(ex);
            }
        }

        public async Task<(
            int Code,
            string MessageKey,
            CommissionPlanCalculationResult? Data)> Calculate(
            CommissionPlanCalculateRequest request)
        {
            if (request.CommissionPlanId <= 0 ||
                request.ParticipantCount < 0 ||
                request.CommissionBaseAmount < 0)
            {
                return (400, "CommissionPlan.InvalidCalculationInput", null);
            }

            try
            {
                var result = await _repository.Calculate(
                    request.CommissionPlanId,
                    request.ParticipantCount,
                    request.CommissionBaseAmount);

                if (result == null)
                    return (500, "Common.OperationFailed", null);

                return (200, "CommissionPlan.Calculated", result);
            }
            catch (SqlException ex)
            {
                return (
                    400,
                    "CommissionPlan.InvalidCalculationInput",
                    null);
            }
        }

        private bool TryGetUserId(out int? userId)
        {
            userId = null;

            var currentUserId = _currentUser.UserId;

            if (!currentUserId.HasValue || currentUserId.Value <= 0 ||
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
            CommissionPlanModel? Data) MapSqlError(SqlException ex)
        {
            return ex.Number switch
            {
                51210 => (400, "CommissionPlan.InvalidAmount", null),
                51211 => (400, "CommissionPlan.InvalidDateRange", null),
                51212 => (404, "CommissionPlan.NotFound", null),
                51213 => (404, "CommissionPlan.NotFound", null),

                _ => (500, "Common.OperationFailed", null)
            };
        }

        private static (
            int Code,
            string MessageKey,
            CommissionPlanCalculationResult? Data) MapCalculationSqlError(
            SqlException ex)
        {
            return ex.Number switch
            {
                51801 => (400, "CommissionPlan.InvalidCalculationInput", null),
                51802 => (404, "CommissionPlan.ActivePlanNotFound", null),
                51803 => (404, "CommissionPlan.TierNotFound", null),
                51804 => (400, "CommissionPlan.UnsupportedMethod", null),

                _ => (500, "Common.OperationFailed", null)
            };
        }
    }
}
