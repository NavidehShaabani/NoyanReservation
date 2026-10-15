using TowerApi.Models.EmployeeAssignments;
using TowerApi.Repositories.EmployeeAssignments;

namespace TowerApi.Services.EmployeeAssignments
{

    public class EmployeeAssignmentService : IEmployeeAssignmentService
    {
        private readonly IEmployeeAssignmentRepository _repository;

        public EmployeeAssignmentService(
            IEmployeeAssignmentRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<EmployeeAssignmentItem>> GetAsync(
            EmployeeAssignmentQuery request)
        {
            request.PageNumber = Math.Max(1, request.PageNumber);
            request.PageSize = Math.Clamp(request.PageSize, 1, 200);

            return _repository.GetAsync(request);
        }

        public Task<EmployeeAssignmentItem?> GetByIdAsync(long id)
        {
            return id <= 0
                ? Task.FromResult<EmployeeAssignmentItem?>(null)
                : _repository.GetByIdAsync(id);
        }

        public async Task<(int Code, string MessageKey, object? Data)> AddAsync(
            EmployeeAssignmentCreateRequest request, long? userId)
        {
            if (request.EmployeeId <= 0 ||
                request.OrgId <= 0 ||
                request.StartDate == default)
            {
                return (400, "EmployeeAssignments.InvalidData", null);
            }

            if (request.EndDate.HasValue &&
                request.EndDate.Value.Date < request.StartDate.Date)
            {
                return (400, "EmployeeAssignments.InvalidDateRange", null);
            }

            var result = await _repository.AddAsync(
                request, ToSqlUserId(userId));

            return result.Code switch
            {
                200 => (
                    200,
                    "EmployeeAssignments.AddSuccessfully",
                    new { EmployeeAssignmentId = result.Id }),

                400 => (400, "EmployeeAssignments.InvalidData", null),
                404 => (404, "EmployeeAssignments.ReferenceNotFound", null),
                409 => (409, "EmployeeAssignments.Conflict", null),
                _ => (500, "Common.SystemError", null)
            };
        }

        public async Task<(int Code, string MessageKey)> EditAsync(
            long id,
            EmployeeAssignmentUpdateRequest request,
            long? userId)
        {
            if (id <= 0 || request.OrgId <= 0 ||
                request.StartDate == default)
            {
                return (400, "EmployeeAssignments.InvalidData");
            }

            if (request.EndDate.HasValue &&
                request.EndDate.Value.Date < request.StartDate.Date)
            {
                return (400, "EmployeeAssignments.InvalidDateRange");
            }

            var code = await _repository.EditAsync(
                id, request, ToSqlUserId(userId));

            return MapCode(code, "Edit");
        }

        public async Task<(int Code, string MessageKey)> DeleteAsync(
            long id, long? userId)
        {
            if (id <= 0)
                return (400, "EmployeeAssignments.InvalidData");

            var code = await _repository.DeleteAsync(
                id, ToSqlUserId(userId));

            return MapCode(code, "Delete");
        }

        public async Task<(int Code, string MessageKey)> SetActiveAsync(
            long id, bool isActive, long? userId)
        {
            if (id <= 0)
                return (400, "EmployeeAssignments.InvalidData");

            var code = await _repository.SetActiveAsync(
                id, isActive, ToSqlUserId(userId));

            return MapCode(code, "Active");
        }

        private static (int Code, string MessageKey) MapCode(
            int code, string operation)
        {
            return code switch
            {
                200 => (200, $"EmployeeAssignments.{operation}Successfully"),
                400 => (400, "EmployeeAssignments.InvalidData"),
                404 => (404, "EmployeeAssignments.NotFound"),
                409 => (409, "EmployeeAssignments.Conflict"),
                _ => (500, "Common.SystemError")
            };
        }

        private static int? ToSqlUserId(long? userId)
        {
            if (!userId.HasValue)
                return null;

            if (userId.Value < 0 || userId.Value > int.MaxValue)
                throw new InvalidOperationException(
                    "شناسه کاربر جاری در محدوده INT دیتابیس نیست.");

            return (int)userId.Value;
        }
    }
}
