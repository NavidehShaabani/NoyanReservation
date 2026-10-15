using TowerApi.Models.EmployeeTypes;
using TowerApi.Repositories.EmployeeTypes;

namespace TowerApi.Services.EmployeeTypes
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private readonly IEmployeeTypeRepository _repository;

        public EmployeeTypeService(IEmployeeTypeRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<EmployeeTypeItem>> GetAsync(EmployeeTypeQuery request)
        {
            request.PageNumber = Math.Max(1, request.PageNumber);
            request.PageSize = Math.Clamp(request.PageSize, 1, 200);

            return _repository.GetAsync(request);
        }

        public Task<EmployeeTypeDetails?> GetByIdAsync(int employeeTypeId)
        {
            return employeeTypeId <= 0
                ? Task.FromResult<EmployeeTypeDetails?>(null)
                : _repository.GetByIdAsync(employeeTypeId);
        }

        public async Task<(int Code, string MessageKey, object? Data)> AddAsync(
            EmployeeTypeCreateRequest request, long? userId)
        {
            if (string.IsNullOrWhiteSpace(request.EmployeeTypeName))
                return (400, "EmployeeTypes.NameRequired", null);

            var result = await _repository.AddAsync(
                request, ToSqlUserId(userId));

            return result.Code switch
            {
                200 => (200, "EmployeeTypes.AddSuccessfully",
                    new { EmployeeTypeId = result.Id }),
                400 => (400, "EmployeeTypes.InvalidData", null),
                409 => (409, "EmployeeTypes.Conflict", null),
                _ => (500, "Common.SystemError", null)
            };
        }

        public async Task<(int Code, string MessageKey)> EditAsync(
            int employeeTypeId,
            EmployeeTypeUpdateRequest request,
            long? userId)
        {
            if (employeeTypeId <= 0 ||
                string.IsNullOrWhiteSpace(request.EmployeeTypeName))
                return (400, "EmployeeTypes.InvalidData");

            var code = await _repository.EditAsync(
                employeeTypeId, request, ToSqlUserId(userId));

            return MapCode(code, "Edit");
        }

        public async Task<(int Code, string MessageKey)> DeleteAsync(
            int employeeTypeId, long? userId)
        {
            if (employeeTypeId <= 0)
                return (400, "EmployeeTypes.InvalidData");

            var code = await _repository.DeleteAsync(
                employeeTypeId, ToSqlUserId(userId));

            return MapCode(code, "Delete");
        }

        public async Task<(int Code, string MessageKey)> SetActiveAsync(
            int employeeTypeId, bool isActive, long? userId)
        {
            if (employeeTypeId <= 0)
                return (400, "EmployeeTypes.InvalidData");

            var code = await _repository.SetActiveAsync(
                employeeTypeId, isActive, ToSqlUserId(userId));

            return MapCode(code, "Active");
        }

        private static (int Code, string MessageKey) MapCode(
            int code, string operation)
        {
            return code switch
            {
                200 => (200, $"EmployeeTypes.{operation}Successfully"),
                400 => (400, "EmployeeTypes.InvalidData"),
                404 => (404, "EmployeeTypes.NotFound"),
                409 => (409, "EmployeeTypes.Conflict"),
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
