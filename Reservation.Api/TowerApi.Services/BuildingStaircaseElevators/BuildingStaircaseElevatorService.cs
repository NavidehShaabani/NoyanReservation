using TowerApi.Models.BuildingStaircaseElevators;
using TowerApi.Repositories.BuildingStaircaseElevators;
using TowerApi.Services.Helper;

namespace TowerApi.Services.BuildingStaircaseElevators
{

    public class BuildingStaircaseElevatorService
        : IBuildingStaircaseElevatorService
    {
        private const int InvalidInputCode = 400;

        private readonly IBuildingStaircaseElevatorRepository _repository;

        public BuildingStaircaseElevatorService(
            IBuildingStaircaseElevatorRepository repository)
        {
            _repository = repository;
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)> AddAsync(
            BuildingStaircaseElevatorCreateRequest request,
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
            BuildingStaircaseElevatorUpdateRequest request,
            long currentUserId)
        {
            var userId = ValidateUserId(currentUserId);

            if (userId is null)
                return (InvalidInputCode, "Common.InvalidUserId", null);

            if (id <= 0)
                return (
                    InvalidInputCode,
                    "BuildingStaircaseElevator.InvalidId",
                    null);

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
                return (
                    InvalidInputCode,
                    "BuildingStaircaseElevator.InvalidId",
                    null);

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
            BuildingStaircaseElevatorQueryRequest request)
        {
            if (request is null || request.BuildingId <= 0)
                return (InvalidInputCode, "Building.InvalidId", null);

            if (request.BuildingStaircaseId.HasValue &&
                request.BuildingStaircaseId.Value <= 0)
            {
                return (
                    InvalidInputCode,
                    "BuildingStaircaseElevator.InvalidStaircaseId",
                    null);
            }

            if (request.BuildingElevatorId.HasValue &&
                request.BuildingElevatorId.Value <= 0)
            {
                return (
                    InvalidInputCode,
                    "BuildingStaircaseElevator.InvalidElevatorId",
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
            BuildingStaircaseElevatorBulkSaveRequest request,
            long currentUserId)
        {
            var userId = ValidateUserId(currentUserId);

            if (userId is null)
                return (InvalidInputCode, "Common.InvalidUserId");

            if (request?.Items is null || request.Items.Count == 0)
            {
                return (
                    InvalidInputCode,
                    "BuildingStaircaseElevator.EmptyBulkItems");
            }

            if (request.Items.Any(x => x is null))
                return (InvalidInputCode, "Common.InvalidInput");

            if (request.Items.Any(x =>
                    x.BuildingId <= 0 ||
                    x.BuildingStaircaseId <= 0 ||
                    x.BuildingElevatorId <= 0 ||
                    (x.BuildingStaircaseElevatorId.HasValue &&
                     x.BuildingStaircaseElevatorId.Value <= 0)))
            {
                return (
                    InvalidInputCode,
                    "BuildingStaircaseElevator.InvalidRelation");
            }

            var duplicateRelations = request.Items
                .GroupBy(x => new
                {
                    x.BuildingId,
                    x.BuildingStaircaseId,
                    x.BuildingElevatorId
                })
                .Any(g => g.Count() > 1);

            if (duplicateRelations)
            {
                return (
                    InvalidInputCode,
                    "BuildingStaircaseElevator.DuplicateRelation");
            }

            var duplicateIds = request.Items
                .Where(x => x.BuildingStaircaseElevatorId.HasValue)
                .GroupBy(x => x.BuildingStaircaseElevatorId)
                .Any(g => g.Count() > 1);

            if (duplicateIds)
            {
                return (
                    InvalidInputCode,
                    "BuildingStaircaseElevator.DuplicateId");
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
                    "BuildingStaircaseElevator.InvalidId");

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
                    "BuildingStaircaseElevator.InvalidId");

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
            BuildingStaircaseElevatorCreateRequest? request)
        {
            if (request is null)
                return "Common.InvalidInput";

            if (request.BuildingId <= 0)
                return "Building.InvalidId";

            if (request.BuildingStaircaseId <= 0)
                return "BuildingStaircaseElevator.InvalidStaircaseId";

            if (request.BuildingElevatorId <= 0)
                return "BuildingStaircaseElevator.InvalidElevatorId";

            return null;
        }
    }
}
