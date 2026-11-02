using System.Data.SqlClient;
using TowerApi.Models.Enrollment;
using TowerApi.Repositories.Enrollment;

namespace TowerApi.Services.Enrollment
{
    public class EnrollmentClassService : IEnrollmentClassService
    {
        private readonly IEnrollmentClassRepository _repository;

        public EnrollmentClassService(
            IEnrollmentClassRepository repository)
        {
            _repository = repository;
        }

        // دریافت ثبت‌نام
        public Task<EnrollmentClassItem?> GetById(
            long enrollmentId)
        {
            return _repository.GetById(enrollmentId);
        }

        // دریافت فهرست
        public Task<IReadOnlyList<EnrollmentClassItem>> GetList(
            EnrollmentClassQuery query)
        {
            return _repository.GetList(query);
        }

        // ثبت‌نام در کلاس
        public async Task<(
            int Code,
            string MessageKey,
            EnrollmentClassItem? Data)> Register(
                EnrollmentClassRegisterRequest request,
                long? currentUserId)
        {
            if (request == null ||
                request.ClassSessionId <= 0 ||
                request.ParticipantId <= 0 ||
                (request.PricingRuleId.HasValue &&
                 request.PricingRuleId.Value <= 0) ||
                string.IsNullOrWhiteSpace(request.CurrencyCode) ||
                request.CurrencyCode.Length != 3 ||
                request.BaseAmount < 0 ||
                request.DiscountAmount < 0 ||
                request.FinalAmount < 0 ||
                request.DiscountAmount > request.BaseAmount)
            {
                return (
                    400,
                    "EnrollmentClass.InvalidData",
                    null);
            }

            try
            {
                int? userId = ToAuditUserId(currentUserId);

                var result = await _repository.Register(
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
                    "EnrollmentClass.RegisteredSuccessfully",
                    result);
            }
            catch (SqlException ex)
            {
                return MapSqlError<EnrollmentClassItem>(ex);
            }
            catch (InvalidOperationException)
            {
                return (
                    400,
                    "EnrollmentClass.InvalidUser",
                    null);
            }
        }

        // بررسی ظرفیت کلاس
        public async Task<(
            int Code,
            string MessageKey,
            EnrollmentClassCapacity? Data)> CheckCapacity(
                long classSessionId)
        {
            if (classSessionId <= 0)
            {
                return (
                    400,
                    "EnrollmentClass.InvalidData",
                    null);
            }

            try
            {
                var result = await _repository.CheckCapacity(
                    classSessionId);

                if (result == null)
                {
                    return (
                        404,
                        "EnrollmentClass.SessionNotFound",
                        null);
                }

                return (
                    200,
                    "EnrollmentClass.CapacityCheckedSuccessfully",
                    result);
            }
            catch (SqlException)
            {
                return (
                    500,
                    "Common.SystemError",
                    null);
            }
        }

        // لغو ثبت‌نام
        public async Task<(
            int Code,
            string MessageKey,
            EnrollmentClassItem? Data)> Cancel(
                long enrollmentId,
                EnrollmentClassCancelRequest request,
                long? currentUserId)
        {
            if (enrollmentId <= 0 ||
                request == null ||
                request.CancellationReason?.Length > 500 ||
                request.CancellationReasonEn?.Length > 500)
            {
                return (
                    400,
                    "EnrollmentClass.InvalidData",
                    null);
            }

            try
            {
                int? userId = ToAuditUserId(currentUserId);

                var result = await _repository.Cancel(
                    enrollmentId,
                    request.CancellationReason,
                    request.CancellationReasonEn,
                    userId);

                if (result == null)
                {
                    return (
                        404,
                        "EnrollmentClass.NotFoundOrInactive",
                        null);
                }

                return (
                    200,
                    "EnrollmentClass.CancelledSuccessfully",
                    result);
            }
            catch (SqlException ex)
            {
                return MapSqlError<EnrollmentClassItem>(ex);
            }
            catch (InvalidOperationException)
            {
                return (
                    400,
                    "EnrollmentClass.InvalidUser",
                    null);
            }
        }

        // تغییر وضعیت پرداخت
        public async Task<(
            int Code,
            string MessageKey,
            EnrollmentClassItem? Data)> SetPaymentStatus(
                long enrollmentId,
                byte paymentStatus,
                long? currentUserId)
        {
            if (enrollmentId <= 0)
            {
                return (
                    400,
                    "EnrollmentClass.InvalidData",
                    null);
            }

            try
            {
                int? userId = ToAuditUserId(currentUserId);

                var result = await _repository.SetPaymentStatus(
                    enrollmentId,
                    paymentStatus,
                    userId);

                if (result == null)
                {
                    return (
                        404,
                        "EnrollmentClass.NotFound",
                        null);
                }

                return (
                    200,
                    "EnrollmentClass.PaymentStatusUpdatedSuccessfully",
                    result);
            }
            catch (SqlException ex)
            {
                return MapSqlError<EnrollmentClassItem>(ex);
            }
            catch (InvalidOperationException)
            {
                return (
                    400,
                    "EnrollmentClass.InvalidUser",
                    null);
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

        // مدیریت خطاهای THROW شده از Stored Procedure
        private static (
            int Code,
            string MessageKey,
            T? Data) MapSqlError<T>(
                SqlException ex)
        {
            var (code, messageKey) = ex.Number switch
            {
                51101 => (400, "EnrollmentClass.InvalidAmount"),
                51102 => (400, "EnrollmentClass.InvalidDiscount"),
                51103 => (400, "EnrollmentClass.RegistrationClosed"),
                51104 => (409, "EnrollmentClass.AlreadyRegistered"),
                51105 => (409, "EnrollmentClass.CapacityFull"),
                51106 => (404, "EnrollmentClass.NotFoundOrInactive"),
                51107 => (404, "EnrollmentClass.NotFound"),

                _ => (500, "Common.SystemError")
            };

            return (
                code,
                messageKey,
                default);
        }
    }
}
