
using TowerApi.Models.BuildingFloor;

namespace TowerApi.Repositories.BuildingFloor
{

    public interface IBuildingFloorsRepository
    {
        Task<(
            int ResultCode,
            string? ResultMessage,
            IReadOnlyList<BuildingFloorModel> Data
        )> Get(
            long? buildingId,
            bool? isActive);

        Task<(
            int ResultCode,
            string? ResultMessage,
            BuildingFloorModel? Data
        )> GetById(long buildingFloorId);

        Task<(
            int ResultCode,
            string? ResultMessage,
            BuildingFloorModel? Data
        )> Insert(
            BuildingFloorInsertRequest request,
            int userId);

        Task<(
            int ResultCode,
            string? ResultMessage,
            BuildingFloorModel? Data
        )> Update(
            long buildingFloorId,
            BuildingFloorUpdateRequest request,
            int userId);

        Task<(
            int ResultCode,
            string? ResultMessage,
            IReadOnlyList<BuildingFloorModel> Data
        )> BulkSave(
            BuildingFloorBulkSaveRequest request,
            int userId);

        Task<(
            int ResultCode,
            string? ResultMessage
        )> Delete(long buildingFloorId);

        Task<(
            int ResultCode,
            string? ResultMessage
        )> SetActive(
            long buildingFloorId,
            bool isActive,
            int userId);
    }
}
