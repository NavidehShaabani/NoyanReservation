using TowerApi.Models.Employees;

namespace TowerApi.Repositories.Employees
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeItem>> GetAsync(EmployeeQuery request);
        Task<EmployeeDetails?> GetByIdAsync(long employeeId);

        Task<(int Code, EmployeeCreateResult? Data)> AddAsync(
            EmployeeCreateRequest request, string? passwordHash, int? userId);

        Task<int> EditAsync(
            long employeeId, EmployeeUpdateRequest request, int? userId);

        Task<int> DeleteAsync(long employeeId, int? userId);

        Task<int> SetActiveAsync(long employeeId, bool isActive, int? userId);
    }
}
