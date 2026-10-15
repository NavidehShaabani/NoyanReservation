using TowerApi.Models.EmployeeTypeRoles;

namespace TowerApi.Services.EmployeeTypeRoles
{
    public interface IEmployeeTypeRoleService
    {
        Task<IEnumerable<EmployeeTypeRoleItem>> GetAsync(
            EmployeeTypeRoleQuery request);

        Task<(int Code, string MessageKey)> AddAsync(
            EmployeeTypeRoleCreateRequest request, long? userId);
    }
}
