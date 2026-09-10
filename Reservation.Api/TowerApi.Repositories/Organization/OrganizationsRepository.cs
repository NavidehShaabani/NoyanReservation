using System.Data;
using Dapper;
using TowerApi.Models.Organization;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Organization
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public OrganizationRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<
            (int ResultCode,
             string ResultMessage,
             OrganizationViewModel? Data)>
            AddAsync(
                OrganizationCreateRequest request,
                int? userCreater)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@OrgName",
                request.OrgName,
                DbType.String);

            parameters.Add(
                "@OrgType",
                request.OrgType,
                DbType.Byte);

            parameters.Add(
                "@GeoId",
                request.GeoId,
                DbType.Int64);

            parameters.Add(
                "@OrgDesc",
                request.OrgDesc,
                DbType.String);

            parameters.Add(
                "@IsActive",
                request.IsActive,
                DbType.Boolean);

            parameters.Add(
                "@UserCreater",
                userCreater,
                DbType.Int32);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data =
                await connection.QueryFirstOrDefaultAsync<OrganizationViewModel>(
                    "dbo.OrganizationsAdd",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            var resultCode =
                parameters.Get<int>("@ResultCode");

            var resultMessage =
                parameters.Get<string>("@ResultMessage")
                ?? string.Empty;

            return (
                resultCode,
                resultMessage,
                data);
        }

        public async Task<
            (int ResultCode,
             string ResultMessage,
             OrganizationViewModel? Data)>
            EditAsync(
                long orgId,
                OrganizationUpdateRequest request,
                int? userUpdater)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@OrgId",
                orgId,
                DbType.Int64);

            parameters.Add(
                "@OrgName",
                request.OrgName,
                DbType.String);

            parameters.Add(
                "@OrgType",
                request.OrgType,
                DbType.Byte);

            parameters.Add(
                "@GeoId",
                request.GeoId,
                DbType.Int64);

            parameters.Add(
                "@OrgDesc",
                request.OrgDesc,
                DbType.String);

            parameters.Add(
                "@IsActive",
                request.IsActive,
                DbType.Boolean);

            parameters.Add(
                "@UserUpdater",
                userUpdater,
                DbType.Int32);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data =
                await connection.QueryFirstOrDefaultAsync<OrganizationViewModel>(
                    "dbo.OrganizationsEdit",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            var resultCode =
                parameters.Get<int>("@ResultCode");

            var resultMessage =
                parameters.Get<string>("@ResultMessage")
                ?? string.Empty;

            return (
                resultCode,
                resultMessage,
                data);
        }

        public async Task<
            (int ResultCode,
             string ResultMessage)>
            DeleteAsync(
                long orgId,
                int? userUpdater)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@OrgId",
                orgId,
                DbType.Int64);

            parameters.Add(
                "@UserUpdater",
                userUpdater,
                DbType.Int32);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.OrganizationsDel",
                parameters,
                commandType: CommandType.StoredProcedure);

            var resultCode =
                parameters.Get<int>("@ResultCode");

            var resultMessage =
                parameters.Get<string>("@ResultMessage")
                ?? string.Empty;

            return (
                resultCode,
                resultMessage);
        }

        public async Task<
            (int ResultCode,
             string ResultMessage,
             OrganizationViewModel? Data)>
            GetByIdAsync(
                long orgId,
                bool includeDeleted)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@OrgId",
                orgId,
                DbType.Int64);

            parameters.Add(
                "@IncludeDeleted",
                includeDeleted,
                DbType.Boolean);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data =
                await connection.QueryFirstOrDefaultAsync<OrganizationViewModel>(
                    "dbo.OrganizationsGet",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            var resultCode =
                parameters.Get<int>("@ResultCode");

            var resultMessage =
                parameters.Get<string>("@ResultMessage")
                ?? string.Empty;

            return (
                resultCode,
                resultMessage,
                data);
        }

        public async Task<
            (int ResultCode,
             string ResultMessage,
             List<OrganizationViewModel> Data)>
            GetListAsync(
                OrganizationQueryRequest request)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@Search",
                request.Search,
                DbType.String);

            parameters.Add(
                "@OrgType",
                request.OrgType,
                DbType.Byte);

            parameters.Add(
                "@GeoId",
                request.GeoId,
                DbType.Int64);

            parameters.Add(
                "@PageNumber",
                request.PageNumber,
                DbType.Int32);

            parameters.Add(
                "@PageSize",
                request.PageSize,
                DbType.Int32);

            parameters.Add(
                "@IncludeDeleted",
                request.IncludeDeleted,
                DbType.Boolean);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data =
                (await connection.QueryAsync<OrganizationViewModel>(
                    "dbo.OrganizationsGet",
                    parameters,
                    commandType: CommandType.StoredProcedure))
                .ToList();

            var resultCode =
                parameters.Get<int>("@ResultCode");

            var resultMessage =
                parameters.Get<string>("@ResultMessage")
                ?? string.Empty;

            return (
                resultCode,
                resultMessage,
                data);
        }
    }
}