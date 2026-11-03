
using TowerApi.Models.BuildingFloor;
using TowerApi.Repositories.BuildingFloor;

namespace TowerApi.Services.BuildingFloor
{
    public class BuildingFloorService : IBuildingFloorService
    {
        private readonly IBuildingFloorRepository _repository;

        public BuildingFloorService(
            IBuildingFloorRepository repository)
        {
            _repository = repository;
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)>
            GetListAsync(BuildingFloorQueryRequest request)
        {
            if (request == null)
                return (400, "BuildingFloors.InvalidQueryRequest", null);

            if (request.PageNumber < 1 || request.PageSize < 1 ||
                request.PageSize > 500)
            {
                return (400, "Common.InvalidPaginationParameters", null);
            }

            if (request.BuildingId.HasValue &&
                request.BuildingId.Value <= 0)
            {
                return (400, "BuildingFloors.InvalidBuildingId", null);
            }

            var result = await _repository.GetListAsync(request);

            return (
                result.ResultCode,
                result.ResultMessage,
                result.Data
            );
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)>
            GetByIdAsync(long buildingFloorId)
        {
            if (buildingFloorId <= 0)
            {
                return (
                    400,
                    "BuildingFloors.InvalidBuildingFloorId",
                    null
                );
            }

            var result = await _repository.GetByIdAsync(buildingFloorId);

            return (
                result.ResultCode,
                result.ResultMessage,
                result.Data
            );
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)>
            AddAsync(
                BuildingFloorCreateRequest request,
                int userId)
        {
            if (request == null)
                return (400, "Common.InvalidRequest", null);

            if (userId <= 0)
                return (401, "Common.Unauthorized", null);

            if (!ValidateRequest(request, out var messageKey))
                return (400, messageKey, null);

            var result = await _repository.AddAsync(request, userId);

            return (
                result.ResultCode,
                result.ResultMessage,
                result.Data
            );
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)>
            EditAsync(
                long buildingFloorId,
                BuildingFloorUpdateRequest request,
                int userId)
        {
            if (buildingFloorId <= 0)
            {
                return (
                    400,
                    "BuildingFloors.InvalidBuildingFloorId",
                    null
                );
            }

            if (request == null)
                return (400, "Common.InvalidRequest", null);

            if (userId <= 0)
                return (401, "Common.Unauthorized", null);

            if (!ValidateRequest(request, out var messageKey))
                return (400, messageKey, null);

            var result = await _repository.EditAsync(
                buildingFloorId,
                request,
                userId);

            return (
                result.ResultCode,
                result.ResultMessage,
                result.Data
            );
        }

        public async Task<(int ResultCode, string MessageKey)>
            DeleteAsync(long buildingFloorId, int userId)
        {
            if (buildingFloorId <= 0)
            {
                return (
                    400,
                    "BuildingFloors.InvalidBuildingFloorId"
                );
            }

            if (userId <= 0)
                return (401, "Common.Unauthorized");

            var result = await _repository.DeleteAsync(
                buildingFloorId,
                userId);

            return (
                result.ResultCode,
                result.ResultMessage
            );
        }

        public async Task<BuildingFloorBulkServiceResult>
            BulkSaveAsync(
                BuildingFloorBulkSaveRequest request,
                long currentUserId)
        {
            if (request?.Items == null || request.Items.Count == 0)
            {
                return InvalidBulkData(
                    "BuildingFloors.InvalidData");
            }

            if (currentUserId <= 0 || currentUserId > int.MaxValue)
            {
                return InvalidBulkData(
                    "Common.InvalidUserId");
            }

            foreach (var item in request.Items)
            {
                if (item.BuildingId <= 0)
                {
                    return InvalidBulkData(
                        "BuildingFloors.InvalidBuildingId");
                }

                if (item.BuildingFloorId < 0)
                {
                    return InvalidBulkData(
                        "BuildingFloors.InvalidBuildingFloorId");
                }

                if (!ValidateRequest(item, out var messageKey))
                    return InvalidBulkData(messageKey);
            }

            var duplicateIds = request.Items
                .Where(x =>
                    x.BuildingFloorId.HasValue &&
                    x.BuildingFloorId.Value > 0)
                .GroupBy(x => x.BuildingFloorId!.Value)
                .Any(g => g.Count() > 1);

            var duplicateFloorNumbers = request.Items
                .GroupBy(x => new { x.BuildingId, x.FloorNumber })
                .Any(g => g.Count() > 1);

            var duplicateFloorCodes = request.Items
                .GroupBy(x => new
                {
                    x.BuildingId,
                    FloorCode = x.FloorCode.Trim().ToUpperInvariant()
                })
                .Any(g => g.Count() > 1);

            if (duplicateIds ||
                duplicateFloorNumbers ||
                duplicateFloorCodes)
            {
                return InvalidBulkData(
                    "BuildingFloors.DuplicateItems");
            }

            var result = await _repository.BulkSaveAsync(
                request.Items,
                currentUserId);

            return new BuildingFloorBulkServiceResult
            {
                Code = result.ResultCode,
                MessageKey = result.ResultCode switch
                {
                    200 => "BuildingFloors.BulkSaveSuccessfully",
                    201 => "BuildingFloors.BulkSaveSuccessfully",
                    400 => "BuildingFloors.InvalidData",
                    404 => "BuildingFloors.ReferenceNotFound",
                    409 => "BuildingFloors.Conflict",
                    _ => "Common.SystemError"
                }
            };
        }

        private static bool ValidateRequest(
            BuildingFloorCreateRequest request,
            out string messageKey)
        {
            messageKey = string.Empty;

            if (request.BuildingId <= 0)
                messageKey = "BuildingFloors.InvalidBuildingId";

            else if (string.IsNullOrWhiteSpace(request.FloorCode) ||
                     request.FloorCode.Length > 40)
                messageKey = "BuildingFloors.InvalidFloorCode";

            else if (string.IsNullOrWhiteSpace(request.FloorName) ||
                     request.FloorName.Length > 200)
                messageKey = "BuildingFloors.InvalidFloorName";

            else if (request.FloorNameEn?.Length > 200)
                messageKey = "BuildingFloors.InvalidFloorNameEn";

            else if (request.MaxUnits < 1)
                messageKey = "BuildingFloors.InvalidMaxUnits";

            return string.IsNullOrEmpty(messageKey);
        }

        private static bool ValidateRequest(
            BuildingFloorBulkItem request,
            out string messageKey)
        {
            messageKey = string.Empty;

            if (request.BuildingId <= 0)
                messageKey = "BuildingFloors.InvalidBuildingId";

            else if (string.IsNullOrWhiteSpace(request.FloorCode) ||
                     request.FloorCode.Length > 40)
                messageKey = "BuildingFloors.InvalidFloorCode";

            else if (string.IsNullOrWhiteSpace(request.FloorName) ||
                     request.FloorName.Length > 200)
                messageKey = "BuildingFloors.InvalidFloorName";

            else if (request.FloorNameEn?.Length > 200)
                messageKey = "BuildingFloors.InvalidFloorNameEn";

            else if (request.MaxUnits < 1)
                messageKey = "BuildingFloors.InvalidMaxUnits";

            return string.IsNullOrEmpty(messageKey);
        }

        private static BuildingFloorBulkServiceResult InvalidBulkData(
            string messageKey)
        {
            return new BuildingFloorBulkServiceResult
            {
                Code = 400,
                MessageKey = messageKey
            };
        }
    }
}
