
using TowerApi.Models.BuildingConfiguration;

namespace TowerApi.Repositories.BuildingConfiguration
{
    public interface IBuildingConfigurationRepository
    {
        Task<(int ResultCode, string ResultMessage,
            BuildingConfigurationViewModel? Data)>
            AddAsync(
                BuildingConfigurationCreateRequest request,
                int? userCreater);

        Task<(int ResultCode, string ResultMessage,
            BuildingConfigurationViewModel? Data)>
            EditAsync(
                long buildingConfigurationId,
                BuildingConfigurationUpdateRequest request,
                int? userUpdater);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long buildingConfigurationId, int? userUpdater);

        Task<(int ResultCode, string ResultMessage,
            BuildingConfigurationViewModel? Data)>
            GetByIdAsync(long buildingConfigurationId, bool includeDeleted);

        Task<(int ResultCode, string ResultMessage,
            List<BuildingConfigurationViewModel> Data)>
            GetListAsync(BuildingConfigurationQueryRequest request);

        Task<(int ResultCode, string? ResultMessage)>
            BulkSaveAsync(
                IEnumerable<BuildingConfigurationBulkItem> items,
                long currentUserId);
    }
}
