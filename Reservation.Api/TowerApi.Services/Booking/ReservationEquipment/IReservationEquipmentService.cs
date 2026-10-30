using TowerApi.Models.Booking.ReservationEquipment;

namespace TowerApi.Services.Booking.ReservationEquipment
{
    public interface IReservationEquipmentService
    {
        Task<(int ResultCode, string ResultMessage, ReservationEquipmentViewModel? Data)>
            GetByIdAsync(long reservationEquipmentId);

        Task<(int ResultCode, string ResultMessage, IEnumerable<ReservationEquipmentViewModel>? Data)>
            GetListAsync(ReservationEquipmentQueryRequest request);

        Task<(int ResultCode, string ResultMessage, ReservationEquipmentViewModel? Data)>
            SaveAsync(ReservationEquipmentSaveRequest request);

        Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long reservationEquipmentId);
    }
}
