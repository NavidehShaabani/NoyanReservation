using TowerApi.Models.BuildingStaircaseElevators;

namespace TowerApi.Services.BuildingStaircaseElevators
{
    public interface IBuildingStaircaseElevatorService
    {
        Task<(int ResultCode, string MessageKey, object? Data)> AddAsync(
            BuildingStaircaseElevatorCreateRequest request,
            long currentUserId);

        Task<(int ResultCode, string MessageKey, object? Data)> EditAsync(
            long id,
            long buildingId,
            BuildingStaircaseElevatorUpdateRequest request,
            long currentUserId);

        Task<(int ResultCode, string MessageKey, object? Data)> GetByIdAsync(
            long id,
            long buildingId);

        Task<(int ResultCode, string MessageKey, object? Data)> GetListAsync(
            BuildingStaircaseElevatorQueryRequest request);

        Task<(int ResultCode, string MessageKey)> BulkSaveAsync(
            BuildingStaircaseElevatorBulkSaveRequest request,
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
