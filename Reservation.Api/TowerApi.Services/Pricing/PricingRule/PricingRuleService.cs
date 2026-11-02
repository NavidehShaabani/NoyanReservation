using System.Data.SqlClient;
using TowerApi.Models.Pricing.PricingRule;
using TowerApi.Repositories.Pricing.PricingRule;

namespace TowerApi.Services.Pricing.PricingRule
{
    public class PricingRuleService : IPricingRuleService
    {
        private readonly IPricingRuleRepository _repository;

        public PricingRuleService(
            IPricingRuleRepository repository)
        {
            _repository = repository;
        }

        // دریافت قانون قیمت‌گذاری
        public Task<PricingRuleItem?> GetById(
            long pricingRuleId)
        {
            return _repository.GetById(pricingRuleId);
        }

        // دریافت فهرست قوانین
        public Task<IReadOnlyList<PricingRuleItem>> GetList(
            PricingRuleQuery query)
        {
            return _repository.GetList(query);
        }

        // ایجاد یا ویرایش قانون قیمت‌گذاری
        public async Task<(
            int Code,
            string MessageKey,
            PricingRuleItem? Data)> Save(
                PricingRuleSaveRequest request,
                long? currentUserId)
        {
            if (request == null ||
                request.OrgId <= 0 ||
                (request.PricingRuleId.HasValue &&
                 request.PricingRuleId.Value <= 0) ||
                (request.BuildingId.HasValue &&
                 request.BuildingId.Value <= 0) ||
                (request.SpaceId.HasValue &&
                 request.SpaceId.Value <= 0) ||
                string.IsNullOrWhiteSpace(request.RuleName) ||
                request.RuleName.Length > 200 ||
                (request.RuleNameEn?.Length > 200) ||
                string.IsNullOrWhiteSpace(request.CurrencyCode) ||
                request.CurrencyCode.Length != 3)
            {
                return (
                    400,
                    "PricingRule.InvalidData",
                    null);
            }

            if (request.Amount < 0)
            {
                return (
                    400,
                    "PricingRule.InvalidAmount",
                    null);
            }

            if (request.MinParticipants < 0 ||
                request.MaxParticipants < 0 ||
                (request.MinParticipants.HasValue &&
                 request.MaxParticipants.HasValue &&
                 request.MaxParticipants < request.MinParticipants))
            {
                return (
                    400,
                    "PricingRule.InvalidParticipantRange",
                    null);
            }

            if (request.ValidTo.HasValue &&
                request.ValidTo.Value < request.ValidFrom)
            {
                return (
                    400,
                    "PricingRule.InvalidValidityPeriod",
                    null);
            }

            try
            {
                int? userId = ToAuditUserId(currentUserId);

                var result = await _repository.Save(
                    request,
                    userId);

                if (result == null)
                {
                    return (
                        500,
                        "Common.SystemError",
                        null);
                }

                return (
                    200,
                    request.PricingRuleId.HasValue
                        ? "PricingRule.UpdatedSuccessfully"
                        : "PricingRule.CreatedSuccessfully",
                    result);
            }
            catch (SqlException ex)
            {
                return MapSqlError<PricingRuleItem>(ex);
            }
            catch (InvalidOperationException)
            {
                return (
                    400,
                    "PricingRule.InvalidUser",
                    null);
            }
        }

        // حذف نرم قانون قیمت‌گذاری
        public async Task<(
            int Code,
            string MessageKey,
            PricingRuleItem? Data)> Delete(
                long pricingRuleId,
                long? currentUserId)
        {
            if (pricingRuleId <= 0)
            {
                return (
                    400,
                    "PricingRule.InvalidId",
                    null);
            }

            try
            {
                int? userId = ToAuditUserId(currentUserId);

                await _repository.Delete(
                    pricingRuleId,
                    userId);

                return (
                    200,
                    "PricingRule.DeletedSuccessfully",
                    null);
            }
            catch (SqlException ex)
            {
                return MapSqlError<PricingRuleItem>(ex);
            }
            catch (InvalidOperationException)
            {
                return (
                    400,
                    "PricingRule.InvalidUser",
                    null);
            }
        }

        // محاسبه مبلغ
        public async Task<(
            int Code,
            string MessageKey,
            PricingRuleCalculation? Data)> CalculateAmount(
                PricingRuleCalculateRequest request)
        {
            if (request == null ||
                request.OrgId <= 0 ||
                (request.SpaceId.HasValue &&
                 request.SpaceId.Value <= 0) ||
                request.ParticipantCount < 0)
            {
                return (
                    400,
                    "PricingRule.InvalidCalculationData",
                    null);
            }

            try
            {
                var result = await _repository.CalculateAmount(
                    request);

                if (result == null)
                {
                    return (
                        500,
                        "Common.SystemError",
                        null);
                }

                return (
                    200,
                    "PricingRule.CalculatedSuccessfully",
                    result);
            }
            catch (SqlException ex)
            {
                return MapCalculationSqlError(ex);
            }
        }

        // تبدیل شناسه کاربر به INT مطابق نوع UserId در SQL
        private static int? ToAuditUserId(long? userId)
        {
            if (!userId.HasValue)
                return null;

            if (userId.Value <= 0 ||
                userId.Value > int.MaxValue)
            {
                throw new InvalidOperationException();
            }

            return (int)userId.Value;
        }

        // مدیریت خطاهای ذخیره و حذف
        private static (
            int Code,
            string MessageKey,
            T? Data) MapSqlError<T>(
                SqlException ex)
        {
            var (code, messageKey) = ex.Number switch
            {
                51201 => (
                    400,
                    "PricingRule.InvalidAmount"),

                51202 => (
                    400,
                    "PricingRule.InvalidParticipantRange"),

                51203 => (
                    400,
                    "PricingRule.InvalidValidityPeriod"),

                51204 => (
                    404,
                    "PricingRule.NotFound"),

                51205 => (
                    404,
                    "PricingRule.NotFound"),

                _ => (
                    500,
                    "Common.SystemError")
            };

            return (
                code,
                messageKey,
                default);
        }

        // مدیریت خطاهای محاسبه مبلغ
        private static (
            int Code,
            string MessageKey,
            PricingRuleCalculation? Data) MapCalculationSqlError(
                SqlException ex)
        {
            var (code, messageKey) = ex.Number switch
            {
                51602 => (
                    404,
                    "PricingRule.ValidRuleNotFound"),

                51603 => (
                    400,
                    "PricingRule.CalculationParametersIncomplete"),

                _ => (
                    500,
                    "Common.SystemError")
            };

            return (
                code,
                messageKey,
                null);
        }
    }
}
