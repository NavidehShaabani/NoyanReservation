using TowerApi.Models.EmployeeTypes;

namespace TowerApi.Services.EmployeeTypes
{
    public interface IEmployeeTypeService
    {
        Task<IEnumerable<EmployeeTypeItem>> GetAsync(EmployeeTypeQuery request);
        Task<EmployeeTypeDetails?> GetByIdAsync(int employeeTypeId);

        Task<(int Code, string MessageKey, object? Data)> AddAsync(
            EmployeeTypeCreateRequest request, long? userId);

        Task<(int Code, string MessageKey)> EditAsync(
            int employeeTypeId, EmployeeTypeUpdateRequest request, long? userId);

        Task<(int Code, string MessageKey)> DeleteAsync(
            int employeeTypeId, long? userId);

        Task<(int Code, string MessageKey)> SetActiveAsync(
            int employeeTypeId, bool isActive, long? userId);
    }
}
