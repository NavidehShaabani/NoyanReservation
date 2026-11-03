using TowerApi.Models.UnitStaircase;

namespace TowerApi.Services.UnitStaircase
{
    public interface IUnitStaircaseService
    {
        Task<(int ResultCode, string MessageKey, object? Data)>
            GetListAsync(UnitStaircaseQueryRequest request);

        Task<(int ResultCode, string MessageKey, object? Data)>
            GetByIdAsync(long unitStaircaseId);

        Task<(int ResultCode, string MessageKey, object? Data)>
            AddAsync(UnitStaircaseCreateRequest request, int userId);

        Task<(int ResultCode, string MessageKey, object? Data)>
            EditAsync(
                long unitStaircaseId,
                UnitStaircaseUpdateRequest request);

        Task<(int ResultCode, string MessageKey)>
            DeleteAsync(long unitStaircaseId);

        Task<UnitStaircaseBulkServiceResult>
            BulkSaveAsync(
                UnitStaircaseBulkSaveRequest request,
                long currentUserId);
    }
}
