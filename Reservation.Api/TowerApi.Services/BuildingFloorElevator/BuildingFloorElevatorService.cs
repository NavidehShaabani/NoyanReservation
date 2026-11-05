using TowerApi.Models.BuildingFloorElevator;
using TowerApi.Repositories.BuildingFloorElevator;
using TowerApi.Services.Helper;

namespace TowerApi.Services.BuildingFloorElevator
{
    public class BuildingFloorElevatorService : IBuildingFloorElevatorService
    {
        private const int InvalidInputCode = 400;

        private readonly IBuildingFloorElevatorRepository _repository;

        public BuildingFloorElevatorService(
            IBuildingFloorElevatorRepository repository)
        {
            _repository = repository;
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)> AddAsync(
            BuildingFloorElevatorCreateRequest request,
            long currentUserId)
        {
            var userId = ValidateUserId(currentUserId);

            if (userId is null)
                return (InvalidInputCode, "Common.InvalidUserId", null);

            var validation = ValidateRequest(request);

            if (validation is not null)
                return (InvalidInputCode, validation, null);

            var result = await _repository.AddAsync(request, userId.Value);

            return (
                result.ResultCode,
                ApiResponseMessageMapper.GetMessageKey(result.ResultCode),
                result.Data);
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)> EditAsync(
            long id,
            long buildingId,
            BuildingFloorElevatorUpdateRequest request,
            long currentUserId)
        {
            var userId = ValidateUserId(currentUserId);

            if (userId is null)
                return (InvalidInputCode, "Common.InvalidUserId", null);

            if (id <= 0)
                return (InvalidInputCode, "BuildingFloorElevator.InvalidId", null);

            if (buildingId <= 0)
                return (InvalidInputCode, "Building.InvalidId", null);

            if (request is null)
                return (InvalidInputCode, "Common.InvalidInput", null);

            var result = await _repository.EditAsync(
                id,
                buildingId,
                request.IsActive,
                userId.Value);

            return (
                result.ResultCode,
                ApiResponseMessageMapper.GetMessageKey(result.ResultCode),
                result.Data);
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)> GetByIdAsync(
            long id,
            long buildingId)
        {
            if (id <= 0)
                return (InvalidInputCode, "BuildingFloorElevator.InvalidId", null);

            if (buildingId <= 0)
                return (InvalidInputCode, "Building.InvalidId", null);

            var result = await _repository.GetByIdAsync(id, buildingId);

            return (
                result.ResultCode,
                ApiResponseMessageMapper.GetMessageKey(result.ResultCode),
                result.Data);
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)> GetListAsync(
            BuildingFloorElevatorQueryRequest request)
        {
            if (request is null || request.BuildingId <= 0)
                return (InvalidInputCode, "Building.InvalidId", null);

            if (request.BuildingFloorId.HasValue &&
                request.BuildingFloorId.Value <= 0)
            {
                return (
                    InvalidInputCode,
                    "BuildingFloorElevator.InvalidFloorId",
                    null);
            }

            if (request.BuildingElevatorId.HasValue &&
                request.BuildingElevatorId.Value <= 0)
            {
                return (
                    InvalidInputCode,
                    "BuildingFloorElevator.InvalidElevatorId",
                    null);
            }

            if (request.PageNumber <= 0 ||
                request.PageSize <= 0 ||
                request.PageSize > 500)
            {
                return (InvalidInputCode, "Common.InvalidInput", null);
            }

            var result = await _repository.GetListAsync(request);

            return (
                result.ResultCode,
                ApiResponseMessageMapper.GetMessageKey(result.ResultCode),
                result.Data);
        }

        public async Task<(int ResultCode, string MessageKey)> BulkSaveAsync(
            BuildingFloorElevatorBulkSaveRequest request,
            long currentUserId)
        {
            var userId = ValidateUserId(currentUserId);

            if (userId is null)
                return (InvalidInputCode, "Common.InvalidUserId");

            if (request?.Items is null || request.Items.Count == 0)
                return (
                    InvalidInputCode,
                    "BuildingFloorElevator.EmptyBulkItems");

            if (request.Items.Any(x => x is null))
                return (InvalidInputCode, "Common.InvalidInput");

            if (request.Items.Any(x =>
                    x.BuildingId <= 0 ||
                    x.BuildingFloorId <= 0 ||
                    x.BuildingElevatorId <= 0 ||
                    (x.BuildingFloorElevatorId.HasValue &&
                     x.BuildingFloorElevatorId.Value <= 0)))
            {
                return (
                    InvalidInputCode,
                    "BuildingFloorElevator.InvalidRelation");
            }

            var duplicateRelations = request.Items
                .GroupBy(x => new
                {
                    x.BuildingId,
                    x.BuildingFloorId,
                    x.BuildingElevatorId
                })
                .Any(g => g.Count() > 1);

            if (duplicateRelations)
            {
                return (
                    InvalidInputCode,
                    "BuildingFloorElevator.DuplicateRelation");
            }

            var duplicateIds = request.Items
                .Where(x => x.BuildingFloorElevatorId.HasValue)
                .GroupBy(x => x.BuildingFloorElevatorId)
                .Any(g => g.Count() > 1);

            if (duplicateIds)
            {
                return (
                    InvalidInputCode,
                    "BuildingFloorElevator.DuplicateId");
            }

            var resultCode = await _repository.BulkSaveAsync(
                request.Items,
                userId.Value);

            return (
                resultCode,
                ApiResponseMessageMapper.GetMessageKey(resultCode));
        }

        public async Task<(int ResultCode, string MessageKey)> SetActiveAsync(
            long id,
            long buildingId,
            bool isActive,
            long currentUserId)
        {
            var userId = ValidateUserId(currentUserId);

            if (userId is null)
                return (InvalidInputCode, "Common.InvalidUserId");

            if (id <= 0)
                return (
                    InvalidInputCode,
                    "BuildingFloorElevator.InvalidId");

            if (buildingId <= 0)
                return (InvalidInputCode, "Building.InvalidId");

            var resultCode = await _repository.SetActiveAsync(
                id,
                buildingId,
                isActive,
                userId.Value);

            return (
                resultCode,
                ApiResponseMessageMapper.GetMessageKey(resultCode));
        }

        public async Task<(int ResultCode, string MessageKey)> DeleteAsync(
            long id,
            long buildingId,
            long currentUserId)
        {
            var userId = ValidateUserId(currentUserId);

            if (userId is null)
                return (InvalidInputCode, "Common.InvalidUserId");

            if (id <= 0)
                return (
                    InvalidInputCode,
                    "BuildingFloorElevator.InvalidId");

            if (buildingId <= 0)
                return (InvalidInputCode, "Building.InvalidId");

            var resultCode = await _repository.DeleteAsync(
                id,
                buildingId,
                userId.Value);

            return (
                resultCode,
                ApiResponseMessageMapper.GetMessageKey(resultCode));
        }

        private static int? ValidateUserId(long currentUserId)
        {
            if (currentUserId <= 0 || currentUserId > int.MaxValue)
                return null;

            return (int)currentUserId;
        }

        private static string? ValidateRequest(
            BuildingFloorElevatorCreateRequest? request)
        {
            if (request is null)
                return "Common.InvalidInput";

            if (request.BuildingId <= 0)
                return "Building.InvalidId";

            if (request.BuildingFloorId <= 0)
                return "BuildingFloorElevator.InvalidFloorId";

            if (request.BuildingElevatorId <= 0)
                return "BuildingFloorElevator.InvalidElevatorId";

            return null;
        }
    }
}
