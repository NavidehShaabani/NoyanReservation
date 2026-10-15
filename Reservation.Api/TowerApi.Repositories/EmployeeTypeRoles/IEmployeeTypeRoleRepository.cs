using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerApi.Models.EmployeeTypeRoles;

namespace TowerApi.Repositories.EmployeeTypeRoles
{
    public interface IEmployeeTypeRoleRepository
    {
        Task<IEnumerable<EmployeeTypeRoleItem>> GetAsync(
            EmployeeTypeRoleQuery request);

        Task<int> AddAsync(
            EmployeeTypeRoleCreateRequest request, int? userId);
    }
}
