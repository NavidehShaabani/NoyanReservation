using TowerApi.Models.Enrollment.EnrollmentClass;


namespace TowerApi.Services.Enrollment.EnrollmentClass
{
    public interface IEnrollmentClassService
    {
        Task<EnrollmentClassItem?> GetById(long enrollmentId);

        Task<IReadOnlyList<EnrollmentClassItem>> GetList(
            EnrollmentClassQuery query);

        Task<(int Code, string MessageKey, EnrollmentClassItem? Data)>
            Register(
                EnrollmentClassRegisterRequest request,
                long? currentUserId);

        Task<(int Code, string MessageKey, EnrollmentClassCapacity? Data)>
            CheckCapacity(long classSessionId);

        Task<(int Code, string MessageKey, EnrollmentClassItem? Data)>
            Cancel(
                long enrollmentId,
                EnrollmentClassCancelRequest request,
                long? currentUserId);

        Task<(int Code, string MessageKey, EnrollmentClassItem? Data)>
            SetPaymentStatus(
                long enrollmentId,
                byte paymentStatus,
                long? currentUserId);
    }
}
