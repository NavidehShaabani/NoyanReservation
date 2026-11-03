
using TowerApi.Models.BuildingStaircase;

namespace TowerApi.Repositories.BuildingStaircase
{
    public interface IBuildingStaircaseRepository
    {
        Task<(int ResultCode, string ResultMessage, BuildingStaircaseViewModel? Data)>
            AddAsync(BuildingStaircaseCreateRequest request, int? userCreater);

        Task<(int ResultCode, string ResultMessage, BuildingStaircaseViewModel? Data)>
            EditAsync(long buildingStaircaseId, BuildingStaircaseUpdateRequest request, int? userUpdater);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long buildingStaircaseId, int? userUpdater);

        Task<(int ResultCode, string ResultMessage, BuildingStaircaseViewModel? Data)>
            GetByIdAsync(long buildingStaircaseId, bool includeDeleted);

        Task<(int ResultCode, string ResultMessage, List<BuildingStaircaseViewModel> Data)>
            GetListAsync(BuildingStaircaseQueryRequest request);

        Task<(int ResultCode, string? ResultMessage)>
            BulkSaveAsync(IEnumerable<BuildingStaircaseBulkItem> items, long currentUserId);
    }
}
