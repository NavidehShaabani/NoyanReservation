using TowerApi.Models.BuildingStaircaseElevators;

namespace TowerApi.Repositories.BuildingStaircaseElevators
{
    public interface IBuildingStaircaseElevatorRepository
    {
        Task<(int ResultCode, BuildingStaircaseElevatorViewModel? Data)> AddAsync(
            BuildingStaircaseElevatorCreateRequest request,
            int userId);

        Task<(int ResultCode, BuildingStaircaseElevatorViewModel? Data)> EditAsync(
            long id,
            long buildingId,
            bool isActive,
            int userId);

        Task<int> DeleteAsync(
            long id,
            long buildingId,
            int userId);

        Task<(int ResultCode, BuildingStaircaseElevatorViewModel? Data)> GetByIdAsync(
            long id,
            long buildingId);

        Task<(int ResultCode, List<BuildingStaircaseElevatorViewModel> Data)> GetListAsync(
            BuildingStaircaseElevatorQueryRequest request);

        Task<int> SetActiveAsync(
            long id,
            long buildingId,
            bool isActive,
            int userId);

        Task<int> BulkSaveAsync(
            IEnumerable<BuildingStaircaseElevatorBulkItem> items,
            int userId);
    }
}
