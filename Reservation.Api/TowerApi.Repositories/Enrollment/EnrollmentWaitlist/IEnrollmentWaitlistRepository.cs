
using TowerApi.Models.Enrollment.EnrollmentWaitlist;

namespace TowerApi.Repositories.Enrollment.EnrollmentWaitlist
{
    public interface IEnrollmentWaitlistRepository
    {
        Task<EnrollmentWaitlistItem?> GetById(
            long waitlistId);

        Task<IReadOnlyList<EnrollmentWaitlistItem>> GetList(
            EnrollmentWaitlistQuery query);

        Task<EnrollmentWaitlistItem?> Join(
            EnrollmentWaitlistJoinRequest request,
            int? currentUserId);

        Task<EnrollmentWaitlistItem?> UpdateStatus(
            long waitlistId,
            EnrollmentWaitlistUpdateStatusRequest request,
            int? currentUserId);
    }
}
