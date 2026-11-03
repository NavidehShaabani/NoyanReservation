using TowerApi.Models.Unit;
using TowerApi.Repositories.Unit;

namespace TowerApi.Services.Unit
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _repository;

        public UnitService(IUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            GetListAsync(UnitQueryRequest request)
        {
            if (request == null ||
                request.PageNumber < 1 ||
                request.PageSize < 1 ||
                request.PageSize > 500 ||
                (request.BuildingId.HasValue && request.BuildingId.Value <= 0) ||
                (request.BuildingFloorId.HasValue && request.BuildingFloorId.Value <= 0))
            {
                return (400, "Units.InvalidQueryRequest", null);
            }

            var result = await _repository.GetListAsync(request);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            GetByIdAsync(long unitId, bool includeDeleted)
        {
            if (unitId <= 0)
                return (400, "Units.InvalidUnitId", null);

            var result = await _repository.GetByIdAsync(unitId, includeDeleted);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string MessageKey, object? Data)>
            AddAsync(UnitCreateRequest request, int userId)
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
            EditAsync(long unitId, UnitUpdateRequest request, int userId)
        {
            if (unitId <= 0)
                return (400, "Units.InvalidUnitId", null);

            if (request == null)
                return (400, "Common.InvalidRequest", null);

            if (userId <= 0)
                return (400, "Common.InvalidUserId", null);

            var validation = ValidateRequest(request);

            if (validation != null)
                return (400, validation, null);

            var result = await _repository.EditAsync(unitId, request, userId);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string MessageKey)>
            DeleteAsync(long unitId, int userId)
        {
            if (unitId <= 0)
                return (400, "Units.InvalidUnitId");

            if (userId <= 0)
                return (400, "Common.InvalidUserId");

            return await _repository.DeleteAsync(unitId, userId);
        }

        public async Task<UnitBulkServiceResult>
            BulkSaveAsync(UnitBulkSaveRequest request, long currentUserId)
        {
            if (request?.Units == null || request.Units.Count == 0)
            {
                return new UnitBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "Units.InvalidBulkData"
                };
            }

            if (currentUserId <= 0 || currentUserId > int.MaxValue)
            {
                return new UnitBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "Common.InvalidUserId"
                };
            }

            var duplicateIds = request.Units
                .Where(x => x.UnitId.HasValue && x.UnitId.Value > 0)
                .GroupBy(x => x.UnitId)
                .Any(g => g.Count() > 1);

            if (duplicateIds)
            {
                return new UnitBulkServiceResult
                {
                    Code = 400,
                    MessageKey = "Units.DuplicateIds"
                };
            }

            foreach (var item in request.Units)
            {
                var validation = ValidateBulkItem(item);

                if (validation != null)
                {
                    return new UnitBulkServiceResult
                    {
                        Code = 400,
                        MessageKey = validation
                    };
                }
            }

            // برای تشخیص تکرار شماره واحد در درخواست گروهی،
            // سیاست نهایی شماره‌گذاری از BuildingConfigurations خوانده می‌شود.
            // بنابراین کنترل قطعی تکرار در Stored Procedure انجام می‌شود.

            var result = await _repository.BulkSaveAsync(
                request.Units, currentUserId);

            return new UnitBulkServiceResult
            {
                Code = result.ResultCode,
                MessageKey = result.ResultMessage ?? "Common.SystemError"
            };
        }

        private static string? ValidateRequest(UnitCreateRequest request)
        {
            if (request.BuildingId <= 0)
                return "Units.InvalidBuildingId";

            if (request.BuildingFloorId.HasValue &&
                request.BuildingFloorId.Value <= 0)
                return "Units.InvalidBuildingFloorId";

            if (string.IsNullOrWhiteSpace(request.UnitNumber) ||
                request.UnitNumber.Trim().Length > 100)
                return "Units.InvalidUnitNumber";

            if (request.Area.HasValue && request.Area.Value < 0)
                return "Units.InvalidArea";

            if (request.UnitDescription?.Length > 2000)
                return "Units.InvalidDescription";

            return null;
        }

        private static string? ValidateBulkItem(UnitBulkItem item)
        {
            if (item == null)
                return "Units.InvalidBulkData";

            if (item.UnitId.HasValue && item.UnitId.Value < 0)
                return "Units.InvalidUnitId";

            if (item.BuildingId <= 0)
                return "Units.InvalidBuildingId";

            if (item.BuildingFloorId.HasValue &&
                item.BuildingFloorId.Value <= 0)
                return "Units.InvalidBuildingFloorId";

            if (string.IsNullOrWhiteSpace(item.UnitNumber) ||
                item.UnitNumber.Trim().Length > 100)
                return "Units.InvalidUnitNumber";

            if (item.Area.HasValue && item.Area.Value < 0)
                return "Units.InvalidArea";

            if (item.UnitDescription?.Length > 2000)
                return "Units.InvalidDescription";

            return null;
        }
    }
}
