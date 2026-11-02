using System.Data;
using Dapper;
using TowerApi.Models.Enrollment;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Enrollment
{
    public class EnrollmentClassRepository : IEnrollmentClassRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public EnrollmentClassRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // دریافت ثبت‌نام با شناسه
        public async Task<EnrollmentClassItem?> GetById(
            long enrollmentId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<EnrollmentClassItem>(
                "dbo.Enrollment_Class_GetById",
                new
                {
                    EnrollmentId = enrollmentId
                },
                commandType: CommandType.StoredProcedure);
        }

        // دریافت فهرست ثبت‌نام‌ها
        public async Task<IReadOnlyList<EnrollmentClassItem>> GetList(
            EnrollmentClassQuery query)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var result = await connection.QueryAsync<EnrollmentClassItem>(
                "dbo.Enrollment_Class_GetList",
                new
                {
                    query.ClassSessionId,
                    query.ParticipantId,
                    query.EnrollmentStatus,
                    query.PaymentStatus
                },
                commandType: CommandType.StoredProcedure);

            return result.AsList();
        }

        // ثبت‌نام در کلاس
        public async Task<EnrollmentClassItem?> Register(
            EnrollmentClassRegisterRequest request,
            int? userId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "ClassSessionId",
                request.ClassSessionId);

            parameters.Add(
                "ParticipantId",
                request.ParticipantId);

            parameters.Add(
                "PricingRuleId",
                request.PricingRuleId);

            parameters.Add(
                "CurrencyCode",
                request.CurrencyCode,
                DbType.AnsiStringFixedLength,
                size: 3);

            parameters.Add(
                "BaseAmount",
                request.BaseAmount);

            parameters.Add(
                "DiscountAmount",
                request.DiscountAmount);

            parameters.Add(
                "FinalAmount",
                request.FinalAmount);

            parameters.Add(
                "PaymentStatus",
                request.PaymentStatus);

            parameters.Add(
                "UserId",
                userId);

            parameters.Add(
                "EnrollmentId",
                dbType: DbType.Int64,
                direction: ParameterDirection.Output);

            return await connection.QueryFirstOrDefaultAsync<EnrollmentClassItem>(
                "dbo.Enrollment_Class_Register",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        // بررسی ظرفیت جلسه
        public async Task<EnrollmentClassCapacity?> CheckCapacity(
            long classSessionId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<EnrollmentClassCapacity>(
                "dbo.Enrollment_Class_CheckCapacity",
                new
                {
                    ClassSessionId = classSessionId
                },
                commandType: CommandType.StoredProcedure);
        }

        // لغو ثبت‌نام
        public async Task<EnrollmentClassItem?> Cancel(
            long enrollmentId,
            string? cancellationReason,
            string? cancellationReasonEn,
            int? userId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<EnrollmentClassItem>(
                "dbo.Enrollment_Class_Cancel",
                new
                {
                    EnrollmentId = enrollmentId,
                    CancellationReason = cancellationReason,
                    CancellationReasonEn = cancellationReasonEn,
                    UserId = userId
                },
                commandType: CommandType.StoredProcedure);
        }

        // تغییر وضعیت پرداخت
        public async Task<EnrollmentClassItem?> SetPaymentStatus(
            long enrollmentId,
            byte paymentStatus,
            int? userId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<EnrollmentClassItem>(
                "dbo.Enrollment_Class_SetPaymentStatus",
                new
                {
                    EnrollmentId = enrollmentId,
                    PaymentStatus = paymentStatus,
                    UserId = userId
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
