using TowerApi.Models.Employees;
using TowerApi.Repositories.Employees;

namespace TowerApi.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<EmployeeItem>> GetAsync(EmployeeQuery request)
        {
            request.PageNumber = Math.Max(1, request.PageNumber);
            request.PageSize = Math.Clamp(request.PageSize, 1, 200);

            return _repository.GetAsync(request);
        }

        public Task<EmployeeDetails?> GetByIdAsync(long employeeId)
        {
            return employeeId <= 0
                ? Task.FromResult<EmployeeDetails?>(null)
                : _repository.GetByIdAsync(employeeId);
        }

        public async Task<(int Code, string MessageKey, object? Data)> AddAsync(
            EmployeeCreateRequest request, long? userId)
        {
            if (string.IsNullOrWhiteSpace(request.Mobile) ||
                string.IsNullOrWhiteSpace(request.FirstName) ||
                string.IsNullOrWhiteSpace(request.LastName) ||
                request.OrgId <= 0 ||
                request.EmployeeTypeId <= 0 ||
                request.Gender is not (1 or 2))
            {
                return (400, "Employees.InvalidData", null);
            }

            if (request.EndDate.HasValue &&
                request.HireDate.HasValue &&
                request.EndDate.Value.Date < request.HireDate.Value.Date)
            {
                return (400, "Employees.InvalidDateRange", null);
            }

            if (request.BaseSalary < 0 || request.HourlyRate < 0)
                return (400, "Employees.InvalidSalary", null);

            string? passwordHash = null;

            if (!string.IsNullOrWhiteSpace(request.Password))
                passwordHash = request.Password;//BCrypt.Net.BCrypt.HashPassword(request.Password);

            var result = await _repository.AddAsync(
                request, passwordHash, ToSqlUserId(userId));

            return result.Code switch
            {
                200 => (200, "Employees.AddSuccessfully", result.Data),
                400 => (400, "Employees.InvalidData", null),
                404 => (404, "Employees.ReferenceNotFound", null),
                409 => (409, "Employees.Conflict", null),
                _ => (500, "Common.SystemError", null)
            };
        }

        public async Task<(int Code, string MessageKey)> EditAsync(
            long employeeId, EmployeeUpdateRequest request, long? userId)
        {
            if (employeeId <= 0 ||
                request.OrgId <= 0 ||
                request.EmployeeTypeId <= 0)
            {
                return (400, "Employees.InvalidData");
            }

            if (request.EndDate.HasValue &&
                request.HireDate.HasValue &&
                request.EndDate.Value.Date < request.HireDate.Value.Date)
            {
                return (400, "Employees.InvalidDateRange");
            }

            if (request.BaseSalary < 0 || request.HourlyRate < 0)
                return (400, "Employees.InvalidSalary");

            var code = await _repository.EditAsync(
                employeeId, request, ToSqlUserId(userId));

            return MapCode(code, "Edit");
        }

        public async Task<(int Code, string MessageKey)> DeleteAsync(
            long employeeId, long? userId)
        {
            if (employeeId <= 0)
                return (400, "Employees.InvalidData");

            var code = await _repository.DeleteAsync(
                employeeId, ToSqlUserId(userId));

            return MapCode(code, "Delete");
        }

        public async Task<(int Code, string MessageKey)> SetActiveAsync(
            long employeeId, bool isActive, long? userId)
        {
            if (employeeId <= 0)
                return (400, "Employees.InvalidData");

            var code = await _repository.SetActiveAsync(
                employeeId, isActive, ToSqlUserId(userId));

            return MapCode(code, "Active");
        }

        private static (int Code, string MessageKey) MapCode(
            int code, string operation)
        {
            return code switch
            {
                200 => (200, $"Employees.{operation}Successfully"),
                400 => (400, "Employees.InvalidData"),
                404 => (404, "Employees.NotFound"),
                409 => (409, "Employees.Conflict"),
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
