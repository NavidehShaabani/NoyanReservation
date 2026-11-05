using TowerApi.Models.BuildingElevators;
using TowerApi.Repositories.BuildingElevators;
using TowerApi.Services.Helper;

namespace TowerApi.Services.BuildingElevators
{

    public class BuildingElevatorService : IBuildingElevatorService
    {
        private const int SuccessCode = 200;
        private const int InvalidInputCode = 400;

        private readonly IBuildingElevatorRepository _repository;

        public BuildingElevatorService(
            IBuildingElevatorRepository repository)
        {
            _repository = repository;
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)> AddAsync(
            BuildingElevatorCreateRequest request,
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

        public async Task<(int ResultCode, string MessageKey, object? Data)> EditAsync(
            long id,
            BuildingElevatorUpdateRequest request,
            long currentUserId)
        {
            var userId = ValidateUserId(currentUserId);

            if (userId is null)
                return (InvalidInputCode, "Common.InvalidUserId", null);

            if (id <= 0)
                return (InvalidInputCode, "BuildingElevator.InvalidId", null);

            var validation = ValidateRequest(request);

            if (validation is not null)
                return (InvalidInputCode, validation, null);

            var result = await _repository.EditAsync(id, request, userId.Value);

            return (
                result.ResultCode,
                ApiResponseMessageMapper.GetMessageKey(result.ResultCode),
                result.Data);
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)> GetByIdAsync(
            long id,
            long buildingId)
        {
            if (id <= 0)
                return (InvalidInputCode, "BuildingElevator.InvalidId", null);

            if (buildingId <= 0)
                return (InvalidInputCode, "Building.InvalidId", null);

            var result = await _repository.GetByIdAsync(id, buildingId);

            return (
                result.ResultCode,
                ApiResponseMessageMapper.GetMessageKey(result.ResultCode),
                result.Data);
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)> GetListAsync(
            BuildingElevatorQueryRequest request)
        {
            if (request is null || request.BuildingId <= 0)
                return (InvalidInputCode, "Building.InvalidId", null);

            if (request.PageNumber <= 0 || request.PageSize <= 0 || request.PageSize > 500)
                return (InvalidInputCode, "Common.InvalidInput", null);

            if (request.ElevatorType.HasValue &&
                (request.ElevatorType.Value < 1 || request.ElevatorType.Value > 7))
            {
                return (InvalidInputCode, "BuildingElevator.InvalidType", null);
            }

            var result = await _repository.GetListAsync(request);

            return (
                result.ResultCode,
                ApiResponseMessageMapper.GetMessageKey(result.ResultCode),
                result.Data);
        }

        public async Task<(int ResultCode, string MessageKey)> BulkSaveAsync(
            BuildingElevatorBulkSaveRequest request,
            long currentUserId)
        {
            var userId = ValidateUserId(currentUserId);

            if (userId is null)
                return (InvalidInputCode, "Common.InvalidUserId");

            if (request?.Items is null || request.Items.Count == 0)
                return (InvalidInputCode, "BuildingElevator.EmptyBulkItems");

            var duplicateCodes = request.Items
                .GroupBy(
                    x => new
                    {
                        x.BuildingId,
                        Code = (x.ElevatorCode ?? string.Empty).Trim()
                    })
                .Any(g => g.Count() > 1);

            if (duplicateCodes)
                return (InvalidInputCode, "BuildingElevator.DuplicateCode");

            foreach (var item in request.Items)
            {
                var validation = ValidateBulkItem(item);

                if (validation is not null)
                    return (InvalidInputCode, validation);
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
                return (InvalidInputCode, "BuildingElevator.InvalidId");

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
                return (InvalidInputCode, "BuildingElevator.InvalidId");

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
            BuildingElevatorCreateRequest? request)
        {
            if (request is null)
                return "Common.InvalidInput";

            if (request.BuildingId <= 0)
                return "Building.InvalidId";

            if (string.IsNullOrWhiteSpace(request.ElevatorCode))
                return "BuildingElevator.InvalidCode";

            if (request.ElevatorCode.Trim().Length > 60)
                return "BuildingElevator.InvalidCode";

            if (string.IsNullOrWhiteSpace(request.ElevatorName))
                return "BuildingElevator.InvalidName";

            if (request.ElevatorName.Trim().Length > 200)
                return "BuildingElevator.InvalidName";

            if (request.ElevatorNameEn?.Length > 200)
                return "BuildingElevator.InvalidName";

            if (request.ElevatorType < 1 || request.ElevatorType > 7)
                return "BuildingElevator.InvalidType";

            if (request.Capacity.HasValue && request.Capacity.Value <= 0)
                return "BuildingElevator.InvalidCapacity";

            if (request.MaxWeight.HasValue && request.MaxWeight.Value <= 0)
                return "BuildingElevator.InvalidMaxWeight";

            if (request.DisplayOrder <= 0)
                return "BuildingElevator.InvalidDisplayOrder";

            if (request.Description?.Length > 1000)
                return "Common.InvalidInput";

            return null;
        }

        private static string? ValidateBulkItem(BuildingElevatorBulkItem? item)
        {
            if (item is null)
                return "Common.InvalidInput";

            if (item.BuildingElevatorId.HasValue &&
                item.BuildingElevatorId.Value <= 0)
            {
                return "BuildingElevator.InvalidId";
            }

            var request = new BuildingElevatorCreateRequest
            {
                BuildingId = item.BuildingId,
                ElevatorCode = item.ElevatorCode,
                ElevatorName = item.ElevatorName,
                ElevatorNameEn = item.ElevatorNameEn,
                ElevatorType = item.ElevatorType,
                Capacity = item.Capacity,
                MaxWeight = item.MaxWeight,
                IsService = item.IsService,
                IsEmergency = item.IsEmergency,
                Description = item.Description,
                DisplayOrder = item.DisplayOrder,
                IsActive = item.IsActive
            };

            return ValidateRequest(request);
        }
    }
}
