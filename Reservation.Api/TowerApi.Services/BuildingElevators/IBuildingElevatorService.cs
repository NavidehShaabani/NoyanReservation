using TowerApi.Models.BuildingElevators;

namespace TowerApi.Services.BuildingElevators
{
    public interface IBuildingElevatorService
    {
        Task<(int ResultCode, string MessageKey, object? Data)>
            AddAsync(BuildingElevatorCreateRequest request, long? userId);

        Task<(int ResultCode, string MessageKey, object? Data)>
            EditAsync(long id, BuildingElevatorUpdateRequest request, long? userId);

        Task<(int ResultCode, string MessageKey)>
            DeleteAsync(long id, long? userId);

        Task<(int ResultCode, string MessageKey, object? Data)>
            GetByIdAsync(long id, bool includeDeleted);

        Task<(int ResultCode, string MessageKey, object? Data)>
            GetListAsync(BuildingElevatorQueryRequest request);

        Task<BuildingElevatorBulkServiceResult>
            BulkSaveAsync(BuildingElevatorBulkSaveRequest request, long currentUserId);
    }
}
