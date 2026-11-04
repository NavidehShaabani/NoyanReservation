using System.Data;
using Dapper;
using TowerApi.Models.Pricing.Settlements;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Pricing.Settlements
{
    public class SettlementRepository : ISettlementRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public SettlementRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<SettlementModel?> GetById(long settlementId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<SettlementModel>(
                "dbo.Pricing_Settlements_GetById",
                new
                {
                    SettlementId = settlementId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IReadOnlyList<SettlementModel>> GetList(
            SettlementListRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var result = await connection.QueryAsync<SettlementModel>(
                "dbo.Pricing_Settlements_GetList",
                new
                {
                    request.OrgId,
                    request.ClassSeriesId,
                    request.ClassSessionId,
                    request.EmployeeId,
                    request.SettlementStatus,
                    request.From,
                    request.To
                },
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<SettlementModel?> Save(
            SettlementSaveRequest request,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<SettlementModel>(
                "dbo.Pricing_Settlements_Save",
                new
                {
                    request.SettlementId,
                    request.OrgId,
                    request.ClassSeriesId,
                    request.ClassSessionId,
                    request.CommissionPlanId,
                    request.EmployeeId,
                    request.ExternalRecipientName,
                    request.SettlementRole,
                    request.GrossAmount,
                    request.CommissionAmount,
                    request.NetAmount,
                    request.SettlementStatus,
                    request.SettledAt,
                    request.Notes,
                    request.NotesEn,
                    UserId = userId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<SettlementModel?> SetStatus(
            long settlementId,
            byte settlementStatus,
            DateTime? settledAt,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<SettlementModel>(
                "dbo.Pricing_Settlements_SetStatus",
                new
                {
                    SettlementId = settlementId,
                    SettlementStatus = settlementStatus,
                    SettledAt = settledAt,
                    UserId = userId
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
