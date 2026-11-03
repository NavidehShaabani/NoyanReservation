
using TowerApi.Models.Unit;

namespace TowerApi.Services.Unit
{
    public interface IUnitService
    {
        Task<(int ResultCode, string MessageKey, object? Data)>
            GetListAsync(UnitQueryRequest request);

        Task<(int ResultCode, string MessageKey, object? Data)>
            GetByIdAsync(long unitId, bool includeDeleted);

        Task<(int ResultCode, string MessageKey, object? Data)>
            AddAsync(UnitCreateRequest request, int userId);

        Task<(int ResultCode, string MessageKey, object? Data)>
            EditAsync(long unitId, UnitUpdateRequest request, int userId);

        Task<(int ResultCode, string MessageKey)>
            DeleteAsync(long unitId, int userId);

        Task<UnitBulkServiceResult>
            BulkSaveAsync(UnitBulkSaveRequest request, long currentUserId);
    }
}
