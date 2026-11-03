using TowerApi.Models.BuildingFloorStaircase;
using TowerApi.Repositories.BuildingFloorStaircase;

namespace TowerApi.Services.BuildingFloorStaircase
{
    public class BuildingFloorStaircaseService
         : IBuildingFloorStaircaseService
    {
        private readonly IBuildingFloorStaircaseRepository _repository;

        public BuildingFloorStaircaseService(
            IBuildingFloorStaircaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            GetListAsync(BuildingFloorStaircaseQueryRequest request)
        {
            if (request == null ||
                request.PageNumber < 1 ||
                request.PageSize < 1 ||
                request.PageSize > 500 ||
                (request.BuildingId.HasValue && request.BuildingId.Value <= 0) ||
                (request.BuildingFloorId.HasValue && request.BuildingFloorId.Value <= 0) ||
                (request.BuildingStaircaseId.HasValue && request.BuildingStaircaseId.Value <= 0))
            {
                return (400, "BuildingFloorStaircases.InvalidQueryRequest", null);
            }

            var result = await _repository.GetListAsync(request);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            GetByIdAsync(long id)
        {
            if (id <= 0)
                return (400, "BuildingFloorStaircases.InvalidId", null);

            var result = await _repository.GetByIdAsync(id);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            AddAsync(BuildingFloorStaircaseCreateRequest request, int userId)
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
            EditAsync(long id, BuildingFloorStaircaseUpdateRequest request,
                int userId)
        {
            if (id <= 0)
                return (400, "BuildingFloorStaircases.InvalidId", null);

            if (request == null)
                return (400, "Common.InvalidRequest", null);

            if (userId <= 0)
                return (400, "Common.InvalidUserId", null);

            var validation = ValidateRequest(request);

            if (validation != null)
                return (400, validation, null);

            var result = await _repository.EditAsync(id, request, userId);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string MessageKey)>
            DeleteAsync(long id, int userId)
        {
            if (id <= 0)
                return (400, "BuildingFloorStaircases.InvalidId");

            if (userId <= 0)
                return (400, "Common.InvalidUserId");

            return await _repository.DeleteAsync(id, userId);
        }

        public async Task<BuildingFloorStaircaseBulkServiceResult>
            BulkSaveAsync(BuildingFloorStaircaseBulkSaveRequest request,
                long currentUserId)
        {
            if (request?.Items == null || request.Items.Count == 0)
            {
                return new BuildingFloorStaircaseBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "BuildingFloorStaircases.InvalidBulkData"
                };
            }

            if (currentUserId <= 0 || currentUserId > int.MaxValue)
            {
                return new BuildingFloorStaircaseBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "Common.InvalidUserId"
                };
            }

            var duplicateIds = request.Items
                .Where(x => x.BuildingFloorStaircaseId.HasValue &&
                            x.BuildingFloorStaircaseId.Value > 0)
                .GroupBy(x => x.BuildingFloorStaircaseId)
                .Any(g => g.Count() > 1);

            if (duplicateIds)
            {
                return new BuildingFloorStaircaseBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "BuildingFloorStaircases.DuplicateIds"
                };
            }

            var duplicatePairs = request.Items
                .GroupBy(x => new
                {
                    x.BuildingFloorId,
                    x.BuildingStaircaseId
                })
                .Any(g => g.Count() > 1);

            if (duplicatePairs)
            {
                return new BuildingFloorStaircaseBulkServiceResult
                {
                    Code = 409,
                    MessageKey = "BuildingFloorStaircases.DuplicateMappings"
                };
            }

            foreach (var item in request.Items)
            {
                var validation = ValidateBulkItem(item);

                if (validation != null)
                {
                    return new BuildingFloorStaircaseBulkServiceResult
                    {
                        Code = 400,
                        MessageKey = validation
                    };
                }
            }

            var result = await _repository.BulkSaveAsync(
                request.Items, currentUserId);

            return new BuildingFloorStaircaseBulkServiceResult
            {
                Code = result.ResultCode,
                MessageKey = result.ResultMessage ?? "Common.SystemError"
            };
        }

        private static string? ValidateRequest(
            BuildingFloorStaircaseCreateRequest request)
        {
            if (request.BuildingId <= 0)
                return "BuildingFloorStaircases.InvalidBuildingId";

            if (request.BuildingFloorId <= 0)
                return "BuildingFloorStaircases.InvalidBuildingFloorId";

            if (request.BuildingStaircaseId <= 0)
                return "BuildingFloorStaircases.InvalidBuildingStaircaseId";

            return null;
        }

        private static string? ValidateBulkItem(
            BuildingFloorStaircaseBulkItem item)
        {
            if (item == null)
                return "BuildingFloorStaircases.InvalidBulkData";

            if (item.BuildingFloorStaircaseId.HasValue &&
                item.BuildingFloorStaircaseId.Value < 0)
                return "BuildingFloorStaircases.InvalidId";

            if (item.BuildingId <= 0)
                return "BuildingFloorStaircases.InvalidBuildingId";

            if (item.BuildingFloorId <= 0)
                return "BuildingFloorStaircases.InvalidBuildingFloorId";

            if (item.BuildingStaircaseId <= 0)
                return "BuildingFloorStaircases.InvalidBuildingStaircaseId";

            return null;
        }
    }
}
