using TowerApi.Models.BuildingFloorStaircase;

namespace TowerApi.Repositories.BuildingFloorStaircase
{
    public interface IBuildingFloorStaircaseRepository
    {
        Task<(int ResultCode, string ResultMessage, BuildingFloorStaircaseViewModel? Data)>
            AddAsync(BuildingFloorStaircaseCreateRequest request, int? userCreater);

        Task<(int ResultCode, string ResultMessage, BuildingFloorStaircaseViewModel? Data)>
            EditAsync(long id, BuildingFloorStaircaseUpdateRequest request, int? userUpdater);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long id, int? userUpdater);

        Task<(int ResultCode, string ResultMessage, BuildingFloorStaircaseViewModel? Data)>
            GetByIdAsync(long id);

        Task<(int ResultCode, string ResultMessage, List<BuildingFloorStaircaseViewModel> Data)>
            GetListAsync(BuildingFloorStaircaseQueryRequest request);

        Task<(int ResultCode, string? ResultMessage)>
            BulkSaveAsync(IEnumerable<BuildingFloorStaircaseBulkItem> items, long currentUserId);
    }
}
