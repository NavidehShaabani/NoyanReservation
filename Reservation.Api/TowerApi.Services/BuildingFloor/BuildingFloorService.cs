
using TowerApi.Models.BuildingFloor;
using TowerApi.Repositories.BuildingFloor;

namespace TowerApi.Services.BuildingFloor
{
    public class BuildingFloorsService : IBuildingFloorsService
    {
        private readonly IBuildingFloorsRepository _repository;
        private readonly ICurrentUser _currentUser;

        public BuildingFloorsService(
            IBuildingFloorsRepository repository,
            ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        private bool TryGetUserId(out int userId)
        {
            userId = 0;

            if (!_currentUser.UserId.HasValue ||
                _currentUser.UserId.Value <= 0 ||
                _currentUser.UserId.Value > int.MaxValue)
            {
                return false;
            }

            userId = (int)_currentUser.UserId.Value;
            return true;
        }

        private static string GetMessageKey(
            int code,
            string? message)
        {
            if (code == 500)
                return "Common.InternalServerError";

            var value = (message ?? string.Empty).Trim();

            // پیام‌های شناخته‌شده Stored Procedure
            if (value.Contains("No records", StringComparison.OrdinalIgnoreCase))
                return "BuildingFloors.ItemsRequired";

            if (value.Contains("Invalid floor", StringComparison.OrdinalIgnoreCase))
                return "BuildingFloors.InvalidData";

            if (value.Contains("Duplicate floor", StringComparison.OrdinalIgnoreCase))
                return "BuildingFloors.DuplicateInRequest";

            if (value.Contains("already exists", StringComparison.OrdinalIgnoreCase))
                return "BuildingFloors.DuplicateFloor";

            if (value.Contains("building", StringComparison.OrdinalIgnoreCase) &&
                value.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return "BuildingFloors.BuildingNotFound";

            if (value.Contains("floor", StringComparison.OrdinalIgnoreCase) &&
                value.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return "BuildingFloors.NotFound";

            if (value.Contains("dependent", StringComparison.OrdinalIgnoreCase))
                return "BuildingFloors.HasDependencies";

            if (value.Contains("active units", StringComparison.OrdinalIgnoreCase))
                return "BuildingFloors.HasActiveUnits";

            if (value.Contains("capacity", StringComparison.OrdinalIgnoreCase))
                return "BuildingFloors.CapacityTooLow";

            if (code == 201)
                return "BuildingFloors.InsertSuccess";

            if (code == 200)
            {
                if (value.Contains("deleted", StringComparison.OrdinalIgnoreCase))
                    return "BuildingFloors.DeleteSuccess";

                if (value.Contains("status", StringComparison.OrdinalIgnoreCase))
                    return "BuildingFloors.SetActiveSuccess";

                if (value.Contains("updated", StringComparison.OrdinalIgnoreCase))
                    return "BuildingFloors.UpdateSuccess";

                if (value.Contains("saved", StringComparison.OrdinalIgnoreCase))
                    return "BuildingFloors.BulkSaveSuccess";

                return "BuildingFloors.GetSuccess";
            }

            return code switch
            {
                400 => "BuildingFloors.InvalidData",
                404 => "BuildingFloors.NotFound",
                409 => "BuildingFloors.Conflict",
                _ => "Common.InternalServerError"
            };
        }

        private static bool IsValidText(
            string? value,
            int maxLength)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   value.Trim().Length <= maxLength;
        }

        private static bool IsValidOptionalText(
            string? value,
            int maxLength)
        {
            return value == null || value.Length <= maxLength;
        }

        private static bool IsValidFloor(
            string? floorCode,
            string? floorName,
            string? floorNameEn,
            int maxUnits)
        {
            return IsValidText(floorCode, 40) &&
                   IsValidText(floorName, 200) &&
                   IsValidOptionalText(floorNameEn, 200) &&
                   maxUnits > 0;
        }

        public async Task<(
            int Code,
            string MessageKey,
            IReadOnlyList<BuildingFloorModel>? Data
        )> Get(long? buildingId, bool? isActive)
        {
            if (buildingId.HasValue && buildingId.Value <= 0)
                return (400, "BuildingFloors.InvalidBuildingId", null);

            var result = await _repository.Get(buildingId, isActive);

            return (
                result.ResultCode,
                GetMessageKey(result.ResultCode, result.ResultMessage),
                result.Data
            );
        }

        public async Task<(
            int Code,
            string MessageKey,
            BuildingFloorModel? Data
        )> GetById(long buildingFloorId)
        {
            if (buildingFloorId <= 0)
                return (400, "BuildingFloors.InvalidId", null);

            var result = await _repository.GetById(buildingFloorId);

            return (
                result.ResultCode,
                GetMessageKey(result.ResultCode, result.ResultMessage),
                result.Data
            );
        }

        public async Task<(
            int Code,
            string MessageKey,
            BuildingFloorModel? Data
        )> Insert(BuildingFloorInsertRequest request)
        {
            if (request == null ||
                request.BuildingId <= 0 ||
                !IsValidFloor(
                    request.FloorCode,
                    request.FloorName,
                    request.FloorNameEn,
                    request.MaxUnits))
            {
                return (400, "BuildingFloors.InvalidData", null);
            }

            if (!TryGetUserId(out var userId))
                return (401, "Common.Unauthorized", null);

            var result = await _repository.Insert(request, userId);

            return (
                result.ResultCode,
                GetMessageKey(result.ResultCode, result.ResultMessage),
                result.Data
            );
        }

        public async Task<(
            int Code,
            string MessageKey,
            BuildingFloorModel? Data
        )> Update(
            long buildingFloorId,
            BuildingFloorUpdateRequest request)
        {
            if (buildingFloorId <= 0 ||
                request == null ||
                !IsValidFloor(
                    request.FloorCode,
                    request.FloorName,
                    request.FloorNameEn,
                    request.MaxUnits))
            {
                return (400, "BuildingFloors.InvalidData", null);
            }

            if (!TryGetUserId(out var userId))
                return (401, "Common.Unauthorized", null);

            var result = await _repository.Update(
                buildingFloorId,
                request,
                userId);

            return (
                result.ResultCode,
                GetMessageKey(result.ResultCode, result.ResultMessage),
                result.Data
            );
        }

        public async Task<(
            int Code,
            string MessageKey,
            IReadOnlyList<BuildingFloorModel>? Data
        )> BulkSave(BuildingFloorBulkSaveRequest request)
        {
            if (request?.Items == null || request.Items.Count == 0)
                return (400, "BuildingFloors.ItemsRequired", null);

            foreach (var item in request.Items)
            {
                if (item.BuildingFloorId < 0 ||
                    item.BuildingId <= 0 ||
                    !IsValidFloor(
                        item.FloorCode,
                        item.FloorName,
                        item.FloorNameEn,
                        item.MaxUnits))
                {
                    return (400, "BuildingFloors.InvalidData", null);
                }
            }

            if (!TryGetUserId(out var userId))
                return (401, "Common.Unauthorized", null);

            var result = await _repository.BulkSave(request, userId);

            return (
                result.ResultCode,
                GetMessageKey(result.ResultCode, result.ResultMessage),
                result.Data
            );
        }

        public async Task<(
            int Code,
            string MessageKey,
            object? Data
        )> Delete(long buildingFloorId)
        {
            if (buildingFloorId <= 0)
                return (400, "BuildingFloors.InvalidId", null);

            var result = await _repository.Delete(buildingFloorId);

            return (
                result.ResultCode,
                GetMessageKey(result.ResultCode, result.ResultMessage),
                null
            );
        }

        public async Task<(
            int Code,
            string MessageKey,
            object? Data
        )> SetActive(long buildingFloorId, bool isActive)
        {
            if (buildingFloorId <= 0)
                return (400, "BuildingFloors.InvalidId", null);

            if (!TryGetUserId(out var userId))
                return (401, "Common.Unauthorized", null);

            var result = await _repository.SetActive(
                buildingFloorId,
                isActive,
                userId);

            return (
                result.ResultCode,
                GetMessageKey(result.ResultCode, result.ResultMessage),
                null
            );
        }
    }
}
