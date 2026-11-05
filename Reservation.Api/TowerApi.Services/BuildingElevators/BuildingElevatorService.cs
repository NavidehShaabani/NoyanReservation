using TowerApi.Models.BuildingElevators;
using TowerApi.Repositories.BuildingElevators;


namespace TowerApi.Services.BuildingElevators
{
    public class BuildingElevatorService : IBuildingElevatorService
    {
        private readonly IBuildingElevatorRepository _repository;

        public BuildingElevatorService(IBuildingElevatorRepository repository)
        {
            _repository = repository;
        }

        private static bool IsValidUserId(long? userId)
        {
            return userId.HasValue &&
                   userId.Value > 0 &&
                   userId.Value <= int.MaxValue;
        }

        private static string? ValidateRequest(BuildingElevatorCreateRequest request)
        {
            if (request.BuildingId <= 0)
                return "Building.InvalidId";

            if (string.IsNullOrWhiteSpace(request.ElevatorCode) ||
                request.ElevatorCode.Length > 60)
                return "BuildingElevator.InvalidCode";

            if (string.IsNullOrWhiteSpace(request.ElevatorName) ||
                request.ElevatorName.Length > 200)
                return "BuildingElevator.InvalidName";

            if (request.ElevatorNameEn?.Length > 200)
                return "BuildingElevator.InvalidEnglishName";

            if (request.ElevatorType < 1 || request.ElevatorType > 7)
                return "BuildingElevator.InvalidType";

            if (request.Capacity.HasValue && request.Capacity.Value <= 0)
                return "BuildingElevator.InvalidCapacity";

            if (request.MaxWeight.HasValue && request.MaxWeight.Value <= 0)
                return "BuildingElevator.InvalidMaxWeight";

            if (request.Description?.Length > 1000)
                return "BuildingElevator.InvalidDescription";

            if (request.DisplayOrder <= 0)
                return "BuildingElevator.InvalidDisplayOrder";

            return null;
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            AddAsync(BuildingElevatorCreateRequest request, long? userId)
        {
            var validation = ValidateRequest(request);

            if (validation != null)
                return (400, validation, null);

            if (!IsValidUserId(userId))
                return (401, "User.Invalid", null);

            var result = await _repository.AddAsync(request, (int)userId!.Value);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            EditAsync(long id, BuildingElevatorUpdateRequest request, long? userId)
        {
            if (id <= 0)
                return (400, "BuildingElevator.InvalidId", null);

            var validation = ValidateRequest(request);

            if (validation != null)
                return (400, validation, null);

            if (!IsValidUserId(userId))
                return (401, "User.Invalid", null);

            var result = await _repository.EditAsync(
                id, request, (int)userId!.Value);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string MessageKey)>
            DeleteAsync(long id, long? userId)
        {
            if (id <= 0)
                return (400, "BuildingElevator.InvalidId");

            if (!IsValidUserId(userId))
                return (401, "User.Invalid");

            var result = await _repository.DeleteAsync(
                id, (int)userId!.Value);

            return (result.ResultCode, result.ResultMessage);
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            GetByIdAsync(long id, bool includeDeleted)
        {
            if (id <= 0)
                return (400, "BuildingElevator.InvalidId", null);

            var result = await _repository.GetByIdAsync(id, includeDeleted);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            GetListAsync(BuildingElevatorQueryRequest request)
        {
            if (request.BuildingId.HasValue && request.BuildingId.Value <= 0)
                return (400, "Building.InvalidId", null);

            if (request.ElevatorType.HasValue &&
                (request.ElevatorType.Value < 1 || request.ElevatorType.Value > 7))
                return (400, "BuildingElevator.InvalidType", null);

            if (request.Search?.Length > 200)
                return (400, "BuildingElevator.InvalidSearch", null);

            if (request.PageNumber < 1 ||
                request.PageSize < 1 ||
                request.PageSize > 200)
                return (400, "Common.InvalidPagination", null);

            var result = await _repository.GetListAsync(request);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<BuildingElevatorBulkServiceResult>
            BulkSaveAsync(BuildingElevatorBulkSaveRequest request, long currentUserId)
        {
            if (currentUserId <= 0 || currentUserId > int.MaxValue)
                return new() { Code = 401, MessageKey = "User.Invalid" };

            if (request.Items == null || request.Items.Count == 0)
                return new() { Code = 400, MessageKey = "BuildingElevator.BulkEmpty" };

            if (request.Items.Count > 500)
                return new() { Code = 400, MessageKey = "Common.BulkLimitExceeded" };

            foreach (var item in request.Items)
            {
                var validation = ValidateBulkItem(item);

                if (validation != null)
                    return new()
                    {
                        Code = 400,
                        MessageKey = validation
                    };

                if (item.BuildingElevatorId.HasValue &&
                    item.BuildingElevatorId.Value <= 0)
                {
                    return new()
                    {
                        Code = 400,
                        MessageKey = "BuildingElevator.InvalidId"
                    };
                }
            }

            var duplicateCodes = request.Items
                .GroupBy(x => new
                {
                    x.BuildingId,
                    Code = x.ElevatorCode.Trim().ToUpperInvariant()
                })
                .Any(g => g.Count() > 1);

            if (duplicateCodes)
                return new() { Code = 409, MessageKey = "BuildingElevator.DuplicateCodeInRequest" };

            var duplicateIds = request.Items
                .Where(x => x.BuildingElevatorId.HasValue)
                .GroupBy(x => x.BuildingElevatorId!.Value)
                .Any(g => g.Count() > 1);

            if (duplicateIds)
                return new() { Code = 409, MessageKey = "BuildingElevator.DuplicateIdInRequest" };

            var result = await _repository.BulkSaveAsync(request.Items, currentUserId);

            return new()
            {
                Code = result.ResultCode,
                MessageKey = result.ResultMessage ?? string.Empty
            };
        }
        private static string? ValidateBulkItem(BuildingElevatorBulkItem item)
        {
            if (item.BuildingId <= 0)
                return "Building.InvalidId";

            if (string.IsNullOrWhiteSpace(item.ElevatorCode) ||
                item.ElevatorCode.Length > 60)
                return "BuildingElevator.InvalidCode";

            if (string.IsNullOrWhiteSpace(item.ElevatorName) ||
                item.ElevatorName.Length > 200)
                return "BuildingElevator.InvalidName";

            if (item.ElevatorNameEn?.Length > 200)
                return "BuildingElevator.InvalidEnglishName";

            if (item.ElevatorType < 1 || item.ElevatorType > 7)
                return "BuildingElevator.InvalidType";

            if (item.Capacity.HasValue && item.Capacity.Value <= 0)
                return "BuildingElevator.InvalidCapacity";

            if (item.MaxWeight.HasValue && item.MaxWeight.Value <= 0)
                return "BuildingElevator.InvalidMaxWeight";

            if (item.Description?.Length > 1000)
                return "BuildingElevator.InvalidDescription";

            if (item.DisplayOrder <= 0)
                return "BuildingElevator.InvalidDisplayOrder";

            return null;
        }
    }
}
