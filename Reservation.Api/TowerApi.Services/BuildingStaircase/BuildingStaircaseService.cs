
using TowerApi.Models.BuildingStaircase;
using TowerApi.Repositories.BuildingStaircase;
using TowerApi.Services.Interfaces;

namespace TowerApi.Services.BuildingStaircase
{
    public class BuildingStaircaseService : IBuildingStaircaseService
    {
        private readonly IBuildingStaircaseRepository _repository;

        public BuildingStaircaseService(IBuildingStaircaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            GetListAsync(BuildingStaircaseQueryRequest request)
        {
            if (request == null ||
                request.PageNumber < 1 ||
                request.PageSize < 1 ||
                request.PageSize > 500 ||
                (request.BuildingId.HasValue && request.BuildingId.Value <= 0))
            {
                return (400, "BuildingStaircases.InvalidQueryRequest", null);
            }

            var result = await _repository.GetListAsync(request);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            GetByIdAsync(long buildingStaircaseId, bool includeDeleted)
        {
            if (buildingStaircaseId <= 0)
                return (400, "BuildingStaircases.InvalidBuildingStaircaseId", null);

            var result = await _repository.GetByIdAsync(buildingStaircaseId, includeDeleted);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            AddAsync(BuildingStaircaseCreateRequest request, int userId)
        {
            if (request == null)
                return (400, "Common.InvalidRequest", null);

            if (userId <= 0)
                return (400, "Common.InvalidUserId", null);

            var validation = ValidateRequest(request);

            if (validation != null)
                return (400, validation, null);

            var result = await _repository.AddAsync(request, userId);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            EditAsync(long buildingStaircaseId,
                BuildingStaircaseUpdateRequest request, int userId)
        {
            if (buildingStaircaseId <= 0)
                return (400, "BuildingStaircases.InvalidBuildingStaircaseId", null);

            if (request == null)
                return (400, "Common.InvalidRequest", null);

            if (userId <= 0)
                return (400, "Common.InvalidUserId", null);

            var validation = ValidateRequest(request);

            if (validation != null)
                return (400, validation, null);

            var result = await _repository.EditAsync(
                buildingStaircaseId, request, userId);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string MessageKey)>
            DeleteAsync(long buildingStaircaseId, int userId)
        {
            if (buildingStaircaseId <= 0)
                return (400, "BuildingStaircases.InvalidBuildingStaircaseId");

            if (userId <= 0)
                return (400, "Common.InvalidUserId");

            return await _repository.DeleteAsync(buildingStaircaseId, userId);
        }

        public async Task<BuildingStaircaseBulkServiceResult>
            BulkSaveAsync(BuildingStaircaseBulkSaveRequest request, long currentUserId)
        {
            if (request?.Items == null || request.Items.Count == 0)
            {
                return new BuildingStaircaseBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "BuildingStaircases.InvalidBulkData"
                };
            }

            if (currentUserId <= 0 || currentUserId > int.MaxValue)
            {
                return new BuildingStaircaseBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "Common.InvalidUserId"
                };
            }

            var duplicateIds = request.Items
                .Where(x => x.BuildingStaircaseId.HasValue &&
                            x.BuildingStaircaseId.Value > 0)
                .GroupBy(x => x.BuildingStaircaseId)
                .Any(g => g.Count() > 1);

            if (duplicateIds)
            {
                return new BuildingStaircaseBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "BuildingStaircases.DuplicateIds"
                };
            }

            var duplicateCodes = request.Items
                .GroupBy(x => new
                {
                    x.BuildingId,
                    Code = (x.StaircaseCode ?? string.Empty).Trim().ToUpperInvariant()
                })
                .Any(g => g.Count() > 1);

            if (duplicateCodes)
            {
                return new BuildingStaircaseBulkServiceResult
                {
                    Code = 409,
                    MessageKey = "BuildingStaircases.DuplicateCodes"
                };
            }

            foreach (var item in request.Items)
            {
                var validation = ValidateBulkItem(item);

                if (validation != null)
                {
                    return new BuildingStaircaseBulkServiceResult
                    {
                        Code = 400,
                        MessageKey = validation
                    };
                }
            }

            var result = await _repository.BulkSaveAsync(
                request.Items, currentUserId);

            return new BuildingStaircaseBulkServiceResult
            {
                Code = result.ResultCode,
                MessageKey = result.ResultMessage ?? "Common.SystemError"
            };
        }

        private static string? ValidateRequest(BuildingStaircaseCreateRequest request)
        {
            if (request.BuildingId <= 0)
                return "BuildingStaircases.InvalidBuildingId";

            if (string.IsNullOrWhiteSpace(request.StaircaseCode) ||
                request.StaircaseCode.Trim().Length > 60)
                return "BuildingStaircases.InvalidStaircaseCode";

            if (string.IsNullOrWhiteSpace(request.StaircaseName) ||
                request.StaircaseName.Trim().Length > 200)
                return "BuildingStaircases.InvalidStaircaseName";

            if (request.StaircaseNameEn?.Length > 200)
                return "BuildingStaircases.InvalidStaircaseNameEn";

            if (request.StaircaseType < 1 || request.StaircaseType > 5)
                return "BuildingStaircases.InvalidStaircaseType";

            if (request.Description?.Length > 1000)
                return "BuildingStaircases.InvalidDescription";

            if (request.DisplayOrder < 1)
                return "BuildingStaircases.InvalidDisplayOrder";

            return null;
        }

        private static string? ValidateBulkItem(BuildingStaircaseBulkItem item)
        {
            if (item == null)
                return "BuildingStaircases.InvalidBulkData";

            if (item.BuildingId <= 0)
                return "BuildingStaircases.InvalidBuildingId";

            if (item.BuildingStaircaseId.HasValue &&
                item.BuildingStaircaseId.Value < 0)
                return "BuildingStaircases.InvalidBuildingStaircaseId";

            if (string.IsNullOrWhiteSpace(item.StaircaseCode) ||
                item.StaircaseCode.Trim().Length > 60)
                return "BuildingStaircases.InvalidStaircaseCode";

            if (string.IsNullOrWhiteSpace(item.StaircaseName) ||
                item.StaircaseName.Trim().Length > 200)
                return "BuildingStaircases.InvalidStaircaseName";

            if (item.StaircaseNameEn?.Length > 200)
                return "BuildingStaircases.InvalidStaircaseNameEn";

            if (item.Description?.Length > 1000)
                return "BuildingStaircases.InvalidDescription";

            if (item.DisplayOrder < 1)
                return "BuildingStaircases.InvalidDisplayOrder";

            return null;
        }
    }
}
