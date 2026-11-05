using TowerApi.Models.BuildingElevators;

namespace TowerApi.Repositories.BuildingElevators
{
    public interface IBuildingElevatorRepository
    {
        Task<(int ResultCode, string ResultMessage, BuildingElevatorViewModel? Data)>
            AddAsync(BuildingElevatorCreateRequest request, int? userCreater);

        Task<(int ResultCode, string ResultMessage, BuildingElevatorViewModel? Data)>
            EditAsync(long buildingElevatorId, BuildingElevatorUpdateRequest request, int? userUpdater);

        Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long buildingElevatorId, int? userUpdater);

        Task<(int ResultCode, string ResultMessage, BuildingElevatorViewModel? Data)>
            GetByIdAsync(long buildingElevatorId, bool includeDeleted);

        Task<(int ResultCode, string ResultMessage, List<BuildingElevatorViewModel> Data)>
            GetListAsync(BuildingElevatorQueryRequest request);

        Task<(int ResultCode, string? ResultMessage)>
            BulkSaveAsync(IEnumerable<BuildingElevatorBulkItem> items, long currentUserId);
    }
}
