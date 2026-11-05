using TowerApi.Models.BuildingFloorElevator;

namespace TowerApi.Services.BuildingFloorElevator
{
    public interface IBuildingFloorElevatorService
    {
        Task<(int ResultCode, string MessageKey, object? Data)> AddAsync(
            BuildingFloorElevatorCreateRequest request,
            long currentUserId);

        Task<(int ResultCode, string MessageKey, object? Data)> EditAsync(
            long id,
            long buildingId,
            BuildingFloorElevatorUpdateRequest request,
            long currentUserId);

        Task<(int ResultCode, string MessageKey, object? Data)> GetByIdAsync(
            long id,
            long buildingId);

        Task<(int ResultCode, string MessageKey, object? Data)> GetListAsync(
            BuildingFloorElevatorQueryRequest request);

        Task<(int ResultCode, string MessageKey)> BulkSaveAsync(
            BuildingFloorElevatorBulkSaveRequest request,
            long currentUserId);

        Task<(int ResultCode, string MessageKey)> SetActiveAsync(
            long id,
            long buildingId,
            bool isActive,
            long currentUserId);

        Task<(int ResultCode, string MessageKey)> DeleteAsync(
            long id,
            long buildingId,
            long currentUserId);
    }
}
