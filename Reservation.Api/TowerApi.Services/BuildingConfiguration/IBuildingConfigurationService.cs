
using TowerApi.Models.BuildingConfiguration;

namespace TowerApi.Services.BuildingConfiguration
{
    public interface IBuildingConfigurationService
    {
        Task<(int ResultCode, string MessageKey, object? Data)>
            GetListAsync(
                BuildingConfigurationQueryRequest request);

        Task<(int ResultCode, string MessageKey, object? Data)>
            GetByIdAsync(
                long buildingConfigurationId,
                bool includeDeleted);

        Task<(int ResultCode, string MessageKey, object? Data)>
            AddAsync(
                BuildingConfigurationCreateRequest request,
                int userId);

        Task<(int ResultCode, string MessageKey, object? Data)>
            EditAsync(
                long buildingConfigurationId,
                BuildingConfigurationUpdateRequest request,
                int userId);

        Task<(int ResultCode, string MessageKey)>
            DeleteAsync(
                long buildingConfigurationId,
                int userId);

        Task<BuildingConfigurationBulkServiceResult>
            BulkSaveAsync(
                BuildingConfigurationBulkSaveRequest request,
                long currentUserId);
    }
}
