using TowerApi.Models.EmployeeTypeRoles;
using TowerApi.Repositories.EmployeeTypeRoles;

namespace TowerApi.Services.EmployeeTypeRoles
{
    public class EmployeeTypeRoleService : IEmployeeTypeRoleService
    {
        private readonly IEmployeeTypeRoleRepository _repository;

        public EmployeeTypeRoleService(IEmployeeTypeRoleRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<EmployeeTypeRoleItem>> GetAsync(
            EmployeeTypeRoleQuery request)
        {
            return _repository.GetAsync(request);
        }

        public async Task<(int Code, string MessageKey)> AddAsync(
            EmployeeTypeRoleCreateRequest request, long? userId)
        {
            if (request.EmployeeTypeId <= 0 || request.RoleId <= 0)
                return (400, "EmployeeTypeRoles.InvalidData");

            int? sqlUserId = null;

            if (userId.HasValue)
            {
                if (userId.Value < 0 || userId.Value > int.MaxValue)
                    throw new InvalidOperationException(
                        "شناسه کاربر جاری در محدوده INT دیتابیس نیست.");

                sqlUserId = (int)userId.Value;
            }

            var code = await _repository.AddAsync(request, sqlUserId);

            return code switch
            {
                200 => (200, "EmployeeTypeRoles.AddSuccessfully"),
                400 => (400, "EmployeeTypeRoles.InvalidData"),
                404 => (404, "EmployeeTypeRoles.NotFound"),
                409 => (409, "EmployeeTypeRoles.Conflict"),
                _ => (500, "Common.SystemError")
            };
        }
    }
}
