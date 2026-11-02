
using TowerApi.Models.Enrollment.EnrollmentClass;

namespace TowerApi.Repositories.Enrollment.EnrollmentClass
{
    public interface IEnrollmentClassRepository
    {
        Task<EnrollmentClassItem?> GetById(long enrollmentId);

        Task<IReadOnlyList<EnrollmentClassItem>> GetList(
            EnrollmentClassQuery query);

        Task<EnrollmentClassItem?> Register(
            EnrollmentClassRegisterRequest request,
            int? userId);

        Task<EnrollmentClassCapacity?> CheckCapacity(
            long classSessionId);

        Task<EnrollmentClassItem?> Cancel(
            long enrollmentId,
            string? cancellationReason,
            string? cancellationReasonEn,
            int? userId);

        Task<EnrollmentClassItem?> SetPaymentStatus(
            long enrollmentId,
            byte paymentStatus,
            int? userId);
    }
}
