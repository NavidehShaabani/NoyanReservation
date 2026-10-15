using System.Data;
using Dapper;
using TowerApi.Models.EmployeeTypeRoles;
using TowerApi.Repositories.DataBase;


namespace TowerApi.Repositories.EmployeeTypeRoles
{
    public class EmployeeTypeRoleRepository : IEmployeeTypeRoleRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public EmployeeTypeRoleRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<EmployeeTypeRoleItem>> GetAsync(
            EmployeeTypeRoleQuery request)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<EmployeeTypeRoleItem>(
                "dbo.EmployeeTypeRolesGet",
                new
                {
                    request.EmployeeTypeId,
                    request.RoleId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AddAsync(
            EmployeeTypeRoleCreateRequest request, int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var p = new DynamicParameters();
            p.Add("@EmployeeTypeId", request.EmployeeTypeId);
            p.Add("@RoleId", request.RoleId);
            p.Add("@UserId", userId);

            p.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);
            p.Add("@ResultMessage", dbType: DbType.String, size: 500,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.EmployeeTypeRolesAdd",
                p,
                commandType: CommandType.StoredProcedure);

            return p.Get<int>("@ResultCode");
        }
    }
}
