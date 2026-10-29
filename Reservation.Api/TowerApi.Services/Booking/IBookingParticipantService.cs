
using TowerApi.Models.Booking;
namespace TowerApi.Services.Booking
{
    public interface IBookingParticipantService
    {
        Task<(
            int ResultCode,
            string ResultMessage,
            object? Data
        )> GetByIdAsync(long participantId);

        Task<(
            int ResultCode,
            string ResultMessage,
            object? Data
        )> GetActiveListAsync(byte? participantType, long? userId);

        Task<(
            int ResultCode,
            string ResultMessage,
            object? Data
        )> SaveAsync(
            BookingParticipantSaveRequest request,
            long? ownerUserId,
            long? auditUserId);

        Task<(int ResultCode, string ResultMessage)> DeleteAsync(
            long participantId,
            long? auditUserId);
    }
}
