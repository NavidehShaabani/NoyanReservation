using System.Data;
using Dapper;
using TowerApi.Models.Pricing.PricingRule;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Pricing.PricingRule
{
    public class PricingRuleRepository : IPricingRuleRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PricingRuleRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // دریافت قانون قیمت‌گذاری
        public async Task<PricingRuleItem?> GetById(
            long pricingRuleId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<PricingRuleItem>(
                "dbo.Pricing_Rules_GetById",
                new
                {
                    PricingRuleId = pricingRuleId
                },
                commandType: CommandType.StoredProcedure);
        }

        // دریافت فهرست قوانین قیمت‌گذاری
        public async Task<IReadOnlyList<PricingRuleItem>> GetList(
            PricingRuleQuery query)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var result = await connection.QueryAsync<PricingRuleItem>(
                "dbo.Pricing_Rules_GetList",
                new
                {
                    query.OrgId,
                    query.BookingType,
                    query.ParticipantCategory,
                    query.SpaceId,
                    query.OnlyActive,
                    query.At
                },
                commandType: CommandType.StoredProcedure);

            return result.AsList();
        }

        // ایجاد یا ویرایش قانون قیمت‌گذاری
        public async Task<PricingRuleItem?> Save(
            PricingRuleSaveRequest request,
            int? currentUserId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<PricingRuleItem>(
                "dbo.Pricing_Rules_Save",
                new
                {
                    request.PricingRuleId,
                    request.OrgId,
                    request.BuildingId,
                    request.SpaceId,
                    request.RuleName,
                    request.RuleNameEn,
                    request.BookingType,
                    request.ParticipantCategory,
                    request.PriceMethod,
                    request.Amount,
                    request.CurrencyCode,
                    request.MinParticipants,
                    request.MaxParticipants,
                    request.RequiresAmenities,
                    request.ValidFrom,
                    request.ValidTo,
                    request.Priority,
                    request.IsActive,
                    UserId = currentUserId
                },
                commandType: CommandType.StoredProcedure);
        }

        // حذف نرم قانون قیمت‌گذاری
        public async Task Delete(
            long pricingRuleId,
            int? currentUserId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                "dbo.Pricing_Rules_Delete",
                new
                {
                    PricingRuleId = pricingRuleId,
                    UserId = currentUserId
                },
                commandType: CommandType.StoredProcedure);
        }

        // محاسبه مبلغ بر اساس قانون قیمت‌گذاری
        public async Task<PricingRuleCalculation?> CalculateAmount(
            PricingRuleCalculateRequest request)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<PricingRuleCalculation>(
                "dbo.Pricing_Rules_CalculateAmount",
                new
                {
                    request.OrgId,
                    request.BookingType,
                    request.ParticipantCategory,
                    request.SpaceId,
                    request.ParticipantCount,
                    request.StartAt,
                    request.EndAt
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
