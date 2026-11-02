using System.Data.SqlClient;
using TowerApi.Models.Enrollment.EnrollmentWaitlist;
using TowerApi.Repositories.Enrollment.EnrollmentWaitlist;

namespace TowerApi.Services.Enrollment.EnrollmentWaitlist
{
    public class EnrollmentWaitlistService
        : IEnrollmentWaitlistService
    {
        private readonly IEnrollmentWaitlistRepository _repository;

        public EnrollmentWaitlistService(
            IEnrollmentWaitlistRepository repository)
        {
            _repository = repository;
        }

        // دریافت یک مورد از لیست انتظار
        public Task<EnrollmentWaitlistItem?> GetById(
            long waitlistId)
        {
            return _repository.GetById(waitlistId);
        }

        // دریافت فهرست انتظار
        public Task<IReadOnlyList<EnrollmentWaitlistItem>> GetList(
            EnrollmentWaitlistQuery query)
        {
            return _repository.GetList(query);
        }

        // عضویت در لیست انتظار
        public async Task<(
            int Code,
            string MessageKey,
            EnrollmentWaitlistItem? Data)> Join(
                EnrollmentWaitlistJoinRequest request,
                long? currentUserId)
        {
            if (request == null ||
                request.ClassSessionId <= 0 ||
                request.ParticipantId <= 0)
            {
                return (
                    400,
                    "EnrollmentWaitlist.InvalidData",
                    null);
            }

            try
            {
                int? userId = ToAuditUserId(currentUserId);

                var result = await _repository.Join(
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
                    "EnrollmentWaitlist.JoinedSuccessfully",
                    result);
            }
            catch (SqlException ex)
            {
                return MapSqlError(ex);
            }
            catch (InvalidOperationException)
            {
                return (
                    400,
                    "EnrollmentWaitlist.InvalidUser",
                    null);
            }
        }

        // تغییر وضعیت عضو لیست انتظار
        public async Task<(
            int Code,
            string MessageKey,
            EnrollmentWaitlistItem? Data)> UpdateStatus(
                long waitlistId,
                EnrollmentWaitlistUpdateStatusRequest request,
                long? currentUserId)
        {
            if (waitlistId <= 0 ||
                request == null ||
                request.WaitlistStatus < 1 ||
                request.WaitlistStatus > 5)
            {
                return (
                    400,
                    "EnrollmentWaitlist.InvalidData",
                    null);
            }

            if (request.OfferedAt.HasValue &&
                request.ExpiresAt.HasValue &&
                request.ExpiresAt.Value < request.OfferedAt.Value)
            {
                return (
                    400,
                    "EnrollmentWaitlist.InvalidDateRange",
                    null);
            }

            try
            {
                int? userId = ToAuditUserId(currentUserId);

                var result = await _repository.UpdateStatus(
                    waitlistId,
                    request,
                    userId);

                if (result == null)
                {
                    return (
                        404,
                        "EnrollmentWaitlist.NotFound",
                        null);
                }

                return (
                    200,
                    "EnrollmentWaitlist.StatusUpdatedSuccessfully",
                    result);
            }
            catch (SqlException ex)
            {
                return MapSqlError(ex);
            }
            catch (InvalidOperationException)
            {
                return (
                    400,
                    "EnrollmentWaitlist.InvalidUser",
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
            EnrollmentWaitlistItem? Data) MapSqlError(
                SqlException ex)
        {
            var (code, messageKey) = ex.Number switch
            {
                51110 => (409,"EnrollmentWaitlist.AlreadyEnrolled"),
                51111 => (409,"EnrollmentWaitlist.AlreadyInWaitlist"),
                51112 => (400,"EnrollmentWaitlist.InvalidDateRange"),
                51113 => (404,"EnrollmentWaitlist.NotFound"),
                _ => (500,"Common.SystemError")
            };

            return (
                code,
                messageKey,
                null);
        }
    }
}
