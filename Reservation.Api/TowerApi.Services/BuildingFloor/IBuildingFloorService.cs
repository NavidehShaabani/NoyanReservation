
using TowerApi.Models.BuildingFloor;

namespace TowerApi.Services.BuildingFloor
{
    public interface IBuildingFloorService
    {
        Task<(
            int ResultCode,
            string MessageKey,
            object? Data)>
            GetListAsync(BuildingFloorQueryRequest request);

        Task<(
            int ResultCode,
            string MessageKey,
            object? Data)>
            GetByIdAsync(long buildingFloorId);

        Task<(
            int ResultCode,
            string MessageKey,
            object? Data)>
            AddAsync(
                BuildingFloorCreateRequest request,
                int userId);

        Task<(
            int ResultCode,
            string MessageKey,
            object? Data)>
            EditAsync(
                long buildingFloorId,
                BuildingFloorUpdateRequest request,
                int userId);

        Task<(
            int ResultCode,
            string MessageKey)>
            DeleteAsync(
                long buildingFloorId,
                int userId);

        Task<BuildingFloorBulkServiceResult>
            BulkSaveAsync(
                BuildingFloorBulkSaveRequest request,
                long currentUserId);
    }
}
