using TowerApi.Models.UnitStaircase;
using TowerApi.Repositories.UnitStaircase;

namespace TowerApi.Services.UnitStaircase
{
    public class UnitStaircaseService : IUnitStaircaseService
    {
        private readonly IUnitStaircaseRepository _repository;

        public UnitStaircaseService(
            IUnitStaircaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)>
            GetListAsync(UnitStaircaseQueryRequest request)
        {
            if (request == null ||
                request.PageNumber < 1 ||
                request.PageSize < 1 ||
                request.PageSize > 500 ||
                (request.UnitId.HasValue && request.UnitId <= 0) ||
                (request.BuildingFloorId.HasValue &&
                 request.BuildingFloorId <= 0) ||
                (request.BuildingStaircaseId.HasValue &&
                 request.BuildingStaircaseId <= 0))
            {
                return (400, "UnitStaircases.InvalidQueryRequest", null);
            }

            var result = await _repository.GetListAsync(request);

            return (
                result.ResultCode,
                result.ResultMessage,
                result.Data);
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)>
            GetByIdAsync(long unitStaircaseId)
        {
            if (unitStaircaseId <= 0)
                return (400, "UnitStaircases.InvalidId", null);

            var result = await _repository.GetByIdAsync(unitStaircaseId);

            return (
                result.ResultCode,
                result.ResultMessage,
                result.Data);
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)>
            AddAsync(UnitStaircaseCreateRequest request, int userId)
        {
            if (request == null)
                return (400, "Common.InvalidRequest", null);

            if (userId <= 0)
                return (400, "Common.InvalidUserId", null);

            var validation = ValidateRequest(request);

            if (validation != null)
                return (400, validation, null);

            var result = await _repository.AddAsync(request, userId);

            return (
                result.ResultCode,
                result.ResultMessage,
                result.Data);
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            object? Data)>
            EditAsync(
                long unitStaircaseId,
                UnitStaircaseUpdateRequest request)
        {
            if (unitStaircaseId <= 0)
                return (400, "UnitStaircases.InvalidId", null);

            if (request == null)
                return (400, "Common.InvalidRequest", null);

            var validation = ValidateRequest(request);

            if (validation != null)
                return (400, validation, null);

            var result = await _repository.EditAsync(
                unitStaircaseId,
                request);

            return (
                result.ResultCode,
                result.ResultMessage,
                result.Data);
        }

        public async Task<(int ResultCode, string MessageKey)>
            DeleteAsync(long unitStaircaseId)
        {
            if (unitStaircaseId <= 0)
                return (400, "UnitStaircases.InvalidId");

            return await _repository.DeleteAsync(unitStaircaseId);
        }

        public async Task<UnitStaircaseBulkServiceResult>
            BulkSaveAsync(
                UnitStaircaseBulkSaveRequest request,
                long currentUserId)
        {
            if (request?.Items == null || request.Items.Count == 0)
            {
                return new UnitStaircaseBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "UnitStaircases.InvalidBulkData"
                };
            }

            if (currentUserId <= 0 || currentUserId > int.MaxValue)
            {
                return new UnitStaircaseBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "Common.InvalidUserId"
                };
            }

            var duplicateIds = request.Items
                .Where(x => x.UnitStaircaseId.HasValue &&
                            x.UnitStaircaseId.Value > 0)
                .GroupBy(x => x.UnitStaircaseId)
                .Any(g => g.Count() > 1);

            if (duplicateIds)
            {
                return new UnitStaircaseBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "UnitStaircases.DuplicateIds"
                };
            }

            foreach (var item in request.Items)
            {
                var validation = ValidateBulkItem(item);

                if (validation != null)
                {
                    return new UnitStaircaseBulkServiceResult
                    {
                        Code = 400,
                        MessageKey = validation
                    };
                }
            }

            var duplicateActivePrimary = request.Items
                .Where(x => (x.IsPrimary ?? false) &&
                            (x.IsActive ?? true))
                .GroupBy(x => x.UnitId)
                .Any(g => g.Count() > 1);

            if (duplicateActivePrimary)
            {
                return new UnitStaircaseBulkServiceResult
                {
                    Code = 409,
                    MessageKey =
                        "UnitStaircases.MultiplePrimaryForUnit"
                };
            }

            var duplicateRelations = request.Items
                .Where(x => x.IsActive ?? true)
                .GroupBy(x => new
                {
                    x.UnitId,
                    x.BuildingFloorId,
                    x.BuildingStaircaseId
                })
                .Any(g => g.Count() > 1);

            if (duplicateRelations)
            {
                return new UnitStaircaseBulkServiceResult
                {
                    Code = 409,
                    MessageKey =
                        "UnitStaircases.DuplicateRelation"
                };
            }

            var result = await _repository.BulkSaveAsync(
                request.Items,
                currentUserId);

            return new UnitStaircaseBulkServiceResult
            {
                Code = result.ResultCode,
                MessageKey = result.ResultMessage
                    ?? "Common.SystemError"
            };
        }

        private static string? ValidateRequest(
            UnitStaircaseCreateRequest request)
        {
            if (request.UnitId <= 0)
                return "UnitStaircases.InvalidUnitId";

            if (request.BuildingFloorId <= 0)
                return "UnitStaircases.InvalidBuildingFloorId";

            if (request.BuildingStaircaseId <= 0)
                return "UnitStaircases.InvalidBuildingStaircaseId";

            return null;
        }

        private static string? ValidateBulkItem(
            UnitStaircaseBulkItem item)
        {
            if (item == null)
                return "UnitStaircases.InvalidBulkData";

            if (item.UnitStaircaseId.HasValue &&
                item.UnitStaircaseId.Value < 0)
                return "UnitStaircases.InvalidId";

            if (item.UnitId <= 0)
                return "UnitStaircases.InvalidUnitId";

            if (item.BuildingFloorId <= 0)
                return "UnitStaircases.InvalidBuildingFloorId";

            if (item.BuildingStaircaseId <= 0)
                return "UnitStaircases.InvalidBuildingStaircaseId";

            return null;
        }
    }
}
