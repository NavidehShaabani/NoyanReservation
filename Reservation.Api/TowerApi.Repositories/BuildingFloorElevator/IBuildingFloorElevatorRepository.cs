using TowerApi.Models.BuildingFloorElevator;

namespace TowerApi.Repositories.BuildingFloorElevator
{
    public interface IBuildingFloorElevatorRepository
    {
        Task<(int ResultCode, BuildingFloorElevatorViewModel? Data)> AddAsync(
            BuildingFloorElevatorCreateRequest request,
            int userId);

        Task<(int ResultCode, BuildingFloorElevatorViewModel? Data)> EditAsync(
            long id,
            long buildingId,
            bool isActive,
            int userId);

        Task<int> DeleteAsync(
            long id,
            long buildingId,
            int userId);

        Task<(int ResultCode, BuildingFloorElevatorViewModel? Data)> GetByIdAsync(
            long id,
            long buildingId);

        Task<(int ResultCode, List<BuildingFloorElevatorViewModel> Data)> GetListAsync(
            BuildingFloorElevatorQueryRequest request);

        Task<int> SetActiveAsync(
            long id,
            long buildingId,
            bool isActive,
            int userId);

        Task<int> BulkSaveAsync(
            IEnumerable<BuildingFloorElevatorBulkItem> items,
            int userId);
    }
}
