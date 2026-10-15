using TowerApi.Models.EmployeeTypes;

namespace TowerApi.Repositories.EmployeeTypes
{
    public interface IEmployeeTypeRepository
    {
        Task<IEnumerable<EmployeeTypeItem>> GetAsync(EmployeeTypeQuery request);
        Task<EmployeeTypeDetails?> GetByIdAsync(int employeeTypeId);

        Task<(int Code, int? Id)> AddAsync(
            EmployeeTypeCreateRequest request, int? userId);

        Task<int> EditAsync(
            int employeeTypeId,
            EmployeeTypeUpdateRequest request,
            int? userId);

        Task<int> DeleteAsync(int employeeTypeId, int? userId);

        Task<int> SetActiveAsync(
            int employeeTypeId, bool isActive, int? userId);
    }
}
