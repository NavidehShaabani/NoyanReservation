using System.Data;
using Dapper;
using TowerApi.Models.Pricing.CommissionTier;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Pricing.CommissionTier
{
    public class CommissionTierRepository : ICommissionTierRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public CommissionTierRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<CommissionTierModel?> GetById(
            long commissionTierId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<CommissionTierModel>(
                "dbo.Pricing_CommissionTiers_GetById",
                new
                {
                    CommissionTierId = commissionTierId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IReadOnlyList<CommissionTierModel>> GetList(
            long commissionPlanId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var result = await connection.QueryAsync<CommissionTierModel>(
                "dbo.Pricing_CommissionTiers_GetList",
                new
                {
                    CommissionPlanId = commissionPlanId
                },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<CommissionTierModel?> Save(
            CommissionTierSaveRequest request,
            int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<CommissionTierModel>(
                "dbo.Pricing_CommissionTiers_Save",
                new
                {
                    request.CommissionTierId,
                    request.CommissionPlanId,
                    request.MinParticipantCount,
                    request.MaxParticipantCount,
                    request.TierPercent,
                    request.TierAmount,
                    request.TierOrder,
                    UserId = userId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(long commissionTierId)
        {
            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                "dbo.Pricing_CommissionTiers_Delete",
                new
                {
                    CommissionTierId = commissionTierId
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
