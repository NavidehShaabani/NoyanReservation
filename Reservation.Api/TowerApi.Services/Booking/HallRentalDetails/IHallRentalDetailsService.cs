
using TowerApi.Models.Booking.HallRentalDetails;

namespace TowerApi.Services.Booking.HallRentalDetails
{
    public interface IHallRentalDetailsService
    {
        Task<(
            int ResultCode,
            string ResultMessage,
            object? Data
        )> GetByIdAsync(long bookingId);

        Task<(
            int ResultCode,
            string ResultMessage,
            object? Data
        )> GetListAsync(HallRentalDetailsQueryRequest request);

        Task<(
            int ResultCode,
            string ResultMessage,
            object? Data
        )> SaveAsync(
            HallRentalDetailsSaveRequest request,
            long? userId);

        Task<(int ResultCode, string ResultMessage)> DeleteAsync(
            long bookingId);
    }
}
