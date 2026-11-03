
using TowerApi.Models.BuildingConfiguration;
using TowerApi.Repositories.BuildingConfiguration;

namespace TowerApi.Services.BuildingConfiguration
{
    public class BuildingConfigurationService
        : IBuildingConfigurationService
    {
        private readonly IBuildingConfigurationRepository _repository;

        public BuildingConfigurationService(
            IBuildingConfigurationRepository repository)
        {
            _repository = repository;
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)>
            GetListAsync(BuildingConfigurationQueryRequest request)
        {
            if (request == null)
                return (400, "BuildingConfigurations.InvalidQueryRequest", null);

            if (request.PageNumber < 1 ||
                request.PageSize < 1 ||
                request.PageSize > 500)
            {
                return (400, "Common.InvalidPaginationParameters", null);
            }

            if (request.BuildingId.HasValue &&
                request.BuildingId.Value <= 0)
            {
                return (400, "BuildingConfigurations.InvalidBuildingId", null);
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
            GetByIdAsync(
                long buildingConfigurationId,
                bool includeDeleted)
        {
            if (buildingConfigurationId <= 0)
            {
                return (
                    400,
                    "BuildingConfigurations.InvalidConfigurationId",
                    null
                );
            }

            var result = await _repository.GetByIdAsync(
                buildingConfigurationId,
                includeDeleted);

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
                BuildingConfigurationCreateRequest request,
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
                long buildingConfigurationId,
                BuildingConfigurationUpdateRequest request,
                int userId)
        {
            if (buildingConfigurationId <= 0)
            {
                return (
                    400,
                    "BuildingConfigurations.InvalidConfigurationId",
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
                buildingConfigurationId,
                request,
                userId);

            return (
                result.ResultCode,
                result.ResultMessage,
                result.Data
            );
        }

        public async Task<(int ResultCode, string MessageKey)>
            DeleteAsync(
                long buildingConfigurationId,
                int userId)
        {
            if (buildingConfigurationId <= 0)
            {
                return (
                    400,
                    "BuildingConfigurations.InvalidConfigurationId"
                );
            }

            if (userId <= 0)
                return (401, "Common.Unauthorized");

            var result = await _repository.DeleteAsync(
                buildingConfigurationId,
                userId);

            return (
                result.ResultCode,
                result.ResultMessage
            );
        }

        public async Task<BuildingConfigurationBulkServiceResult>
            BulkSaveAsync(
                BuildingConfigurationBulkSaveRequest request,
                long currentUserId)
        {
            if (request?.Items == null || request.Items.Count == 0)
            {
                return new BuildingConfigurationBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "BuildingConfigurations.InvalidData"
                };
            }

            if (currentUserId <= 0 || currentUserId > int.MaxValue)
            {
                return new BuildingConfigurationBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "Common.InvalidUserId"
                };
            }

            foreach (var item in request.Items)
            {
                if (item.BuildingId <= 0)
                {
                    return InvalidBulkData(
                        "BuildingConfigurations.InvalidBuildingId");
                }

                if (item.BuildingConfigurationId < 0)
                {
                    return InvalidBulkData(
                        "BuildingConfigurations.InvalidConfigurationId");
                }

                if (!ValidateRequest(item, out var messageKey))
                    return InvalidBulkData(messageKey);
            }

            var duplicateIds = request.Items
                .Where(x =>
                    x.BuildingConfigurationId.HasValue &&
                    x.BuildingConfigurationId.Value > 0)
                .GroupBy(x => x.BuildingConfigurationId!.Value)
                .Any(g => g.Count() > 1);

            var duplicateBuildings = request.Items
                .GroupBy(x => x.BuildingId)
                .Any(g => g.Count() > 1);

            if (duplicateIds || duplicateBuildings)
            {
                return InvalidBulkData(
                    "BuildingConfigurations.DuplicateItems");
            }

            var result = await _repository.BulkSaveAsync(
                request.Items,
                currentUserId);

            return new BuildingConfigurationBulkServiceResult
            {
                Code = result.ResultCode,
                MessageKey = result.ResultCode switch
                {
                    200 => "BuildingConfigurations.BulkSaveSuccessfully",
                    201 => "BuildingConfigurations.BulkSaveSuccessfully",
                    400 => "BuildingConfigurations.InvalidData",
                    404 => "BuildingConfigurations.BuildingNotFound",
                    409 => "BuildingConfigurations.Conflict",
                    _ => "Common.SystemError"
                }
            };
        }

        private static bool ValidateRequest(
            BuildingConfigurationBulkItem request,
            out string messageKey)
        {
            messageKey = string.Empty;

            if (request.BuildingId <= 0)
            {
                messageKey =
                    "BuildingConfigurations.InvalidBuildingId";
            }
            else if (request.BasementFloorCount < 0)
            {
                messageKey =
                    "BuildingConfigurations.InvalidBasementFloorCount";
            }
            else if (request.GroundFloorCount < 0)
            {
                messageKey =
                    "BuildingConfigurations.InvalidGroundFloorCount";
            }
            else if (request.AboveGroundFloorCount < 0)
            {
                messageKey =
                    "BuildingConfigurations.InvalidAboveGroundFloorCount";
            }
            else if (request.StaircaseCount < 0)
            {
                messageKey =
                    "BuildingConfigurations.InvalidStaircaseCount";
            }
            else if (request.ElevatorCount < 0)
            {
                messageKey =
                    "BuildingConfigurations.InvalidElevatorCount";
            }
            else if (request.DefaultUnitsPerFloor < 1)
            {
                messageKey =
                    "BuildingConfigurations.InvalidDefaultUnitsPerFloor";
            }
            else if (string.IsNullOrWhiteSpace(request.UnitNumberPattern) ||
                     request.UnitNumberPattern.Length > 100)
            {
                messageKey =
                    "BuildingConfigurations.InvalidUnitNumberPattern";
            }
            else if (request.UnitLetterStart?.Length > 1 ||
                     request.UnitLetterEnd?.Length > 1)
            {
                messageKey =
                    "BuildingConfigurations.InvalidUnitLetter";
            }

            return string.IsNullOrEmpty(messageKey);
        }

        private static bool ValidateRequest(
    BuildingConfigurationCreateRequest request,
    out string messageKey)
        {
            messageKey = string.Empty;

            if (request.BuildingId <= 0)
                messageKey = "BuildingConfigurations.InvalidBuildingId";

            else if (request.BasementFloorCount < 0)
                messageKey = "BuildingConfigurations.InvalidBasementFloorCount";

            else if (request.GroundFloorCount < 0)
                messageKey = "BuildingConfigurations.InvalidGroundFloorCount";

            else if (request.AboveGroundFloorCount < 0)
                messageKey = "BuildingConfigurations.InvalidAboveGroundFloorCount";

            else if (request.StaircaseCount < 0)
                messageKey = "BuildingConfigurations.InvalidStaircaseCount";

            else if (request.ElevatorCount < 0)
                messageKey = "BuildingConfigurations.InvalidElevatorCount";

            else if (request.DefaultUnitsPerFloor < 1)
                messageKey = "BuildingConfigurations.InvalidDefaultUnitsPerFloor";

            else if (string.IsNullOrWhiteSpace(request.UnitNumberPattern) ||
                     request.UnitNumberPattern.Length > 100)
                messageKey = "BuildingConfigurations.InvalidUnitNumberPattern";

            else if (request.UnitLetterStart?.Length > 1 ||
                     request.UnitLetterEnd?.Length > 1)
                messageKey = "BuildingConfigurations.InvalidUnitLetter";

            return string.IsNullOrEmpty(messageKey);
        }

        private static BuildingConfigurationBulkServiceResult
            InvalidBulkData(string messageKey)
        {
            return new BuildingConfigurationBulkServiceResult
            {
                Code = 400,
                MessageKey = messageKey
            };
        }
    }
}
