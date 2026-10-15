using System.Data;
using Dapper;
using TowerApi.Models.EmployeeTypes;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.EmployeeTypes
{
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public EmployeeTypeRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<EmployeeTypeItem>> GetAsync(
            EmployeeTypeQuery request)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<EmployeeTypeItem>(
                "dbo.EmployeeTypesGet",
                new
                {
                    request.Search,
                    request.IsActive,
                    request.PageNumber,
                    request.PageSize
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<EmployeeTypeDetails?> GetByIdAsync(int employeeTypeId)
        {
            using var connection = _connectionFactory.CreateConnection();

            using var result = await connection.QueryMultipleAsync(
                "dbo.EmployeeTypesGetById",
                new { EmployeeTypeId = employeeTypeId },
                commandType: CommandType.StoredProcedure);

            var item = await result.ReadFirstOrDefaultAsync<EmployeeTypeDetails>();

            if (item == null)
                return null;

            item.Roles = (await result.ReadAsync<EmployeeTypeRoleItem>()).ToList();

            return item;
        }

        public async Task<(int Code, int? Id)> AddAsync(
            EmployeeTypeCreateRequest request, int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@EmployeeTypeName", request.EmployeeTypeName);
            parameters.Add("@EmployeeTypeDesc", request.EmployeeTypeDesc);
            parameters.Add("@UserCreater", userId);

            parameters.Add("@EmployeeTypeId",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add("@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add("@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.EmployeeTypesAdd",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<int?>("@EmployeeTypeId")
            );
        }

        public async Task<int> EditAsync(
            int employeeTypeId,
            EmployeeTypeUpdateRequest request,
            int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateResultParameters();

            parameters.Add("@EmployeeTypeId", employeeTypeId);
            parameters.Add("@EmployeeTypeName", request.EmployeeTypeName);
            parameters.Add("@EmployeeTypeDesc", request.EmployeeTypeDesc);
            parameters.Add("@UserUpdater", userId);

            await connection.ExecuteAsync(
                "dbo.EmployeeTypesEdit",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@ResultCode");
        }

        public async Task<int> DeleteAsync(int employeeTypeId, int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateResultParameters();

            parameters.Add("@EmployeeTypeId", employeeTypeId);
            parameters.Add("@UserUpdater", userId);

            await connection.ExecuteAsync(
                "dbo.EmployeeTypesDel",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@ResultCode");
        }

        public async Task<int> SetActiveAsync(
            int employeeTypeId, bool isActive, int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateResultParameters();

            parameters.Add("@EmployeeTypeId", employeeTypeId);
            parameters.Add("@IsActive", isActive);
            parameters.Add("@UserUpdater", userId);

            await connection.ExecuteAsync(
                "dbo.EmployeeTypesActive",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@ResultCode");
        }

        private static DynamicParameters CreateResultParameters()
        {
            var parameters = new DynamicParameters();

            parameters.Add("@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add("@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            return parameters;
        }
    }
}
