
using TowerApi.Models.BuildingStaircase;

namespace TowerApi.Services.BuildingStaircase
{
    public interface IBuildingStaircaseService
    {
        Task<(int ResultCode, string MessageKey, object? Data)>
            GetListAsync(BuildingStaircaseQueryRequest request);

        Task<(int ResultCode, string MessageKey, object? Data)>
            GetByIdAsync(long buildingStaircaseId, bool includeDeleted);

        Task<(int ResultCode, string MessageKey, object? Data)>
            AddAsync(BuildingStaircaseCreateRequest request, int userId);

        Task<(int ResultCode, string MessageKey, object? Data)>
            EditAsync(long buildingStaircaseId, BuildingStaircaseUpdateRequest request, int userId);

        Task<(int ResultCode, string MessageKey)>
            DeleteAsync(long buildingStaircaseId, int userId);

        Task<BuildingStaircaseBulkServiceResult>
            BulkSaveAsync(BuildingStaircaseBulkSaveRequest request, long currentUserId);
    }
}
