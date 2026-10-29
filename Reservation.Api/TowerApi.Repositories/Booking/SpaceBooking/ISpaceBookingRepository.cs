

using TowerApi.Models.Booking.SpaceBooking;

namespace TowerApi.Repositories.Booking.SpaceBooking
{
    public interface ISpaceBookingRepository
    {
        Task<(
            int ResultCode,
            string ResultMessage,
            List<SpaceBookingViewModel> Data)>
            GetListAsync(SpaceBookingQueryRequest request);

        Task<(
            int ResultCode,
            string ResultMessage,
            SpaceBookingViewModel? Data)>
            GetByIdAsync(long bookingId);

        Task<(
            int ResultCode,
            string ResultMessage,
            SpaceBookingViewModel? Data)>
            AddAsync(SpaceBookingCreateRequest request, int? userCreater);

        Task<(
            int ResultCode,
            string ResultMessage,
            SpaceBookingViewModel? Data)>
            EditAsync(
                long bookingId,
                SpaceBookingUpdateRequest request,
                int? userUpdater);

        Task<(
            int ResultCode,
            string ResultMessage,
            SpaceBookingConflictViewModel? Data)>
            CheckConflictAsync(SpaceBookingConflictRequest request);

        Task<(
            int ResultCode,
            string ResultMessage,
            SpaceBookingViewModel? Data)>
            ApproveAsync(long bookingId, int userId);

        Task<(
            int ResultCode,
            string ResultMessage,
            SpaceBookingViewModel? Data)>
            CancelAsync(long bookingId, int userId);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long bookingId, int userId);
    }
}
