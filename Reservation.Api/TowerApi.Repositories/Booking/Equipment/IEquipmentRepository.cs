using TowerApi.Models.Booking.Equipment;

namespace TowerApi.Repositories.Booking.Equipment
{
    public interface IEquipmentRepository
    {
        Task<(int ResultCode, string ResultMessage, EquipmentViewModel? Data)>
            GetByIdAsync(long equipmentId);

        Task<(int ResultCode, string ResultMessage, IEnumerable<EquipmentViewModel>? Data)>
            GetListAsync(EquipmentQueryRequest request);

        Task<(int ResultCode, string ResultMessage, EquipmentViewModel? Data)>
            SaveAsync(EquipmentSaveRequest request, int userId);

        Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long equipmentId, int userId);
    }
}
