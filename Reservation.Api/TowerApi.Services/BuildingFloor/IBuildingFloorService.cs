
using TowerApi.Models.BuildingFloor;

namespace TowerApi.Services.BuildingFloor
{

    public interface IBuildingFloorsService
    {
        Task<(int Code, string MessageKey, IReadOnlyList<BuildingFloorModel>? Data)>
            Get(long? buildingId, bool? isActive);

        Task<(int Code, string MessageKey, BuildingFloorModel? Data)>
            GetById(long buildingFloorId);

        Task<(int Code, string MessageKey, BuildingFloorModel? Data)>
            Insert(BuildingFloorInsertRequest request);

        Task<(int Code, string MessageKey, BuildingFloorModel? Data)>
            Update(long buildingFloorId, BuildingFloorUpdateRequest request);

        Task<(int Code, string MessageKey, IReadOnlyList<BuildingFloorModel>? Data)>
            BulkSave(BuildingFloorBulkSaveRequest request);

        Task<(int Code, string MessageKey, object? Data)>
            Delete(long buildingFloorId);

        Task<(int Code, string MessageKey, object? Data)>
            SetActive(long buildingFloorId, bool isActive);
    }
}
