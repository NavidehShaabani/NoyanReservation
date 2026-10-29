using TowerApi.Models.Booking.SpaceBooking;

namespace TowerApi.Services.Booking.SpaceBooking
{
    public interface ISpaceBookingService
    {
        Task<(int ResultCode, string ResultMessage, object? Data)>
            GetListAsync(SpaceBookingQueryRequest request);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            GetByIdAsync(long bookingId);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            AddAsync(SpaceBookingCreateRequest request, int userId);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            EditAsync(
                long bookingId,
                SpaceBookingUpdateRequest request,
                int userId);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            CheckConflictAsync(SpaceBookingConflictRequest request);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            ApproveAsync(long bookingId, int userId);

        Task<(int ResultCode, string ResultMessage, object? Data)>
            CancelAsync(long bookingId, int userId);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long bookingId, int userId);
    }
}
