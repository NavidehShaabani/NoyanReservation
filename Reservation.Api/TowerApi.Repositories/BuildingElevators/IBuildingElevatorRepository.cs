using TowerApi.Models.BuildingElevators;

namespace TowerApi.Repositories.BuildingElevators
{
    public interface IBuildingElevatorRepository
    {
        Task<(int ResultCode, BuildingElevatorViewModel? Data)> AddAsync(
            BuildingElevatorCreateRequest request,
            int userId);

        Task<(int ResultCode, BuildingElevatorViewModel? Data)> EditAsync(
            long id,
            BuildingElevatorUpdateRequest request,
            int userId);

        Task<int> DeleteAsync(
            long id,
            long buildingId,
            int userId);

        Task<(int ResultCode, BuildingElevatorViewModel? Data)> GetByIdAsync(
            long id,
            long buildingId);

        Task<(int ResultCode, List<BuildingElevatorViewModel> Data)> GetListAsync(
            BuildingElevatorQueryRequest request);

        Task<int> SetActiveAsync(
            long id,
            long buildingId,
            bool isActive,
            int userId);

        Task<int> BulkSaveAsync(
            IEnumerable<BuildingElevatorBulkItem> items,
            int userId);
    }
}
