using TowerApi.Models.BuildingFloorStaircase;

namespace TowerApi.Services.BuildingFloorStaircase
{
    public interface IBuildingFloorStaircaseService
    {
        Task<(int ResultCode, string MessageKey, object? Data)>
            GetListAsync(BuildingFloorStaircaseQueryRequest request);

        Task<(int ResultCode, string MessageKey, object? Data)>
            GetByIdAsync(long id);

        Task<(int ResultCode, string MessageKey, object? Data)>
            AddAsync(BuildingFloorStaircaseCreateRequest request, int userId);

        Task<(int ResultCode, string MessageKey, object? Data)>
            EditAsync(long id, BuildingFloorStaircaseUpdateRequest request, int userId);

        Task<(int ResultCode, string MessageKey)>
            DeleteAsync(long id, int userId);

        Task<BuildingFloorStaircaseBulkServiceResult>
            BulkSaveAsync(BuildingFloorStaircaseBulkSaveRequest request,
                long currentUserId);
    }
}
