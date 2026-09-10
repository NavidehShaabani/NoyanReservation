using TowerApi.Models.Building;

namespace TowerApi.Repositories.Building
{
    public interface IBuildingRepository
    {
        Task<(int ResultCode, string ResultMessage, BuildingViewModel? Data)>
            AddAsync(
                BuildingCreateRequest request,
                int? userCreater);

        Task<(int ResultCode, string ResultMessage, BuildingViewModel? Data)>
            EditAsync(
                long buildingId,
                BuildingUpdateRequest request,
                int? userUpdater);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(
                long buildingId,
                int? userUpdater);

        Task<(int ResultCode, string ResultMessage, BuildingViewModel? Data)>
            GetByIdAsync(
                long buildingId,
                bool includeDeleted);

        Task<(int ResultCode, string ResultMessage, List<BuildingViewModel> Data)>
            GetListAsync(
                BuildingQueryRequest request);
    }
}