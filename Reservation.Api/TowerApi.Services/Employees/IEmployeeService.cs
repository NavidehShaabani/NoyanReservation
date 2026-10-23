using TowerApi.Models.Employees;

namespace TowerApi.Services.Employees
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeItem>> GetAsync(EmployeeQuery request);
        
        Task<EmployeeDetails?> GetByIdAsync(long employeeId);

        Task<(int Code, string MessageKey, object? Data)> AddAsync(
            EmployeeCreateRequest request, long? userId);

        Task<(int Code, string MessageKey)> EditAsync(
            long employeeId, EmployeeUpdateRequest request, long? userId);

        Task<(int Code, string MessageKey)> DeleteAsync(
            long employeeId, long? userId);

        Task<(int Code, string MessageKey)> SetActiveAsync(
            long employeeId, bool isActive, long? userId);
    }
}
