using TowerApi.Models.Booking.HallRentalDetails;

namespace TowerApi.Repositories.Booking.HallRentalDetails
{
    public interface IHallRentalDetailsRepository
    {
        Task<(
            int ResultCode,
            string ResultMessage,
            HallRentalDetailsViewModel? Data
        )> GetByIdAsync(long bookingId);

        Task<(
            int ResultCode,
            string ResultMessage,
            List<HallRentalDetailsViewModel> Data
        )> GetListAsync(HallRentalDetailsQueryRequest request);

        Task<(
            int ResultCode,
            string ResultMessage,
            HallRentalDetailsViewModel? Data
        )> SaveAsync(
            HallRentalDetailsSaveRequest request,
            int? userId);

        Task<(int ResultCode, string ResultMessage)> DeleteAsync(
            long bookingId);
    }
}
