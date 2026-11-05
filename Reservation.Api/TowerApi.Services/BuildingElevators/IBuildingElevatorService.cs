using TowerApi.Models.BuildingElevators;

namespace TowerApi.Services.BuildingElevators
{
    public interface IBuildingElevatorService
    {
        Task<(int ResultCode, string MessageKey, object? Data)> AddAsync(
            BuildingElevatorCreateRequest request,
            long currentUserId);

        Task<(int ResultCode, string MessageKey, object? Data)> EditAsync(
            long id,
            BuildingElevatorUpdateRequest request,
            long currentUserId);

        Task<(int ResultCode, string MessageKey, object? Data)> GetByIdAsync(
            long id,
            long buildingId);

        Task<(int ResultCode, string MessageKey, object? Data)> GetListAsync(
            BuildingElevatorQueryRequest request);

        Task<(int ResultCode, string MessageKey)> BulkSaveAsync(
            BuildingElevatorBulkSaveRequest request,
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
