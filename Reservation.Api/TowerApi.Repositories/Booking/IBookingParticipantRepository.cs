using TowerApi.Models.Booking;

namespace TowerApi.Repositories.Booking
{
    public interface IBookingParticipantRepository
    {
        Task<(
            int ResultCode,
            string ResultMessage,
            BookingParticipantViewModel? Data
        )> GetByIdAsync(long participantId);

        Task<(
            int ResultCode,
            string ResultMessage,
            List<BookingParticipantViewModel> Data
        )> GetActiveListAsync(byte? participantType, long? userId);

        Task<(
            int ResultCode,
            string ResultMessage,
            BookingParticipantViewModel? Data
        )> SaveAsync(
            BookingParticipantSaveRequest request,
            long? ownerUserId,
            int? auditUserId);

        Task<(int ResultCode, string ResultMessage)> DeleteAsync(
            long participantId,
            int? auditUserId);
    }
}
