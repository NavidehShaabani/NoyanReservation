using TowerApi.Models.Booking.Equipment;

namespace TowerApi.Services.Booking.Equipment
{
    public interface IEquipmentService
    {
        Task<(int ResultCode, string ResultMessage, EquipmentViewModel? Data)>
            GetByIdAsync(long equipmentId);

        Task<(int ResultCode, string ResultMessage, IEnumerable<EquipmentViewModel>? Data)>
            GetListAsync(EquipmentQueryRequest request);

        Task<(int ResultCode, string ResultMessage, EquipmentViewModel? Data)>
            SaveAsync(EquipmentSaveRequest request);

        Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long equipmentId);
    }
}
