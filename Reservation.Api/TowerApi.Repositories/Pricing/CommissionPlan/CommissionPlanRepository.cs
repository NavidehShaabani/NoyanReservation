using System.Data;
using Dapper;
using TowerApi.Models.Pricing.CommissionPlan;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Pricing.CommissionPlan
{
    public class CommissionPlanRepository : ICommissionPlanRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public CommissionPlanRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<CommissionPlanModel?> GetById(long commissionPlanId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<CommissionPlanModel>(
                "dbo.Pricing_CommissionPlans_GetById",
                new { CommissionPlanId = commissionPlanId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IReadOnlyList<CommissionPlanModel>> GetList(
            long? orgId,
            long? classSeriesId,
            bool onlyActive)
        {
            using var connection = _connectionFactory.CreateConnection();

            var result = await connection.QueryAsync<CommissionPlanModel>(
                "dbo.Pricing_CommissionPlans_GetList",
                new
                {
                    OrgId = orgId,
                    ClassSeriesId = classSeriesId,
                    OnlyActive = onlyActive
                },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<CommissionPlanModel?> Save(
            CommissionPlanSaveRequest request,
            int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<CommissionPlanModel>(
                "dbo.Pricing_CommissionPlans_Save",
                new
                {
                    request.CommissionPlanId,
                    request.OrgId,
                    request.ClassSeriesId,
                    request.PlanName,
                    request.PlanNameEn,
                    request.CommissionMethod,
                    request.CommissionBasis,
                    request.FixedAmount,
                    request.CommissionPercent,
                    request.ValidFrom,
                    request.ValidTo,
                    request.IsActive,
                    UserId = userId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(long commissionPlanId, int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                "dbo.Pricing_CommissionPlans_Delete",
                new
                {
                    CommissionPlanId = commissionPlanId,
                    UserId = userId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<CommissionPlanCalculationResult?> Calculate(
            long commissionPlanId,
            int participantCount,
            decimal commissionBaseAmount)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<CommissionPlanCalculationResult>(
                "dbo.Pricing_CommissionPlans_Calculate",
                new
                {
                    CommissionPlanId = commissionPlanId,
                    ParticipantCount = participantCount,
                    CommissionBaseAmount = commissionBaseAmount
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
