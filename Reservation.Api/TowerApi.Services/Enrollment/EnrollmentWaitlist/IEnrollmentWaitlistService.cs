
using TowerApi.Models.Enrollment.EnrollmentWaitlist;

namespace TowerApi.Services.Enrollment.EnrollmentWaitlist
{
    public interface IEnrollmentWaitlistService
    {
        Task<EnrollmentWaitlistItem?> GetById(
            long waitlistId);

        Task<IReadOnlyList<EnrollmentWaitlistItem>> GetList(
            EnrollmentWaitlistQuery query);

        Task<(
            int Code,
            string MessageKey,
            EnrollmentWaitlistItem? Data)> Join(
                EnrollmentWaitlistJoinRequest request,
                long? currentUserId);

        Task<(
            int Code,
            string MessageKey,
            EnrollmentWaitlistItem? Data)> UpdateStatus(
                long waitlistId,
                EnrollmentWaitlistUpdateStatusRequest request,
                long? currentUserId);
    }
}
