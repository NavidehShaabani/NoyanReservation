
using TowerApi.Models.BuildingFloor;

namespace TowerApi.Repositories.BuildingFloor
{
    public interface IBuildingFloorRepository
    {
        Task<(
            int ResultCode,
            string ResultMessage,
            BuildingFloorViewModel? Data)>
            AddAsync(
                BuildingFloorCreateRequest request,
                int? userCreater);

        Task<(
            int ResultCode,
            string ResultMessage,
            BuildingFloorViewModel? Data)>
            EditAsync(
                long buildingFloorId,
                BuildingFloorUpdateRequest request,
                int? userUpdater);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(
                long buildingFloorId,
                int? userUpdater);

        Task<(
            int ResultCode,
            string ResultMessage,
            BuildingFloorViewModel? Data)>
            GetByIdAsync(long buildingFloorId);

        Task<(
            int ResultCode,
            string ResultMessage,
            List<BuildingFloorViewModel> Data)>
            GetListAsync(BuildingFloorQueryRequest request);

        Task<(int ResultCode, string? ResultMessage)>
            BulkSaveAsync(
                IEnumerable<BuildingFloorBulkItem> items,
                long currentUserId);
    }
}
