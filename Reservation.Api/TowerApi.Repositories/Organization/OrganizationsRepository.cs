using Dapper;
using System.Data;
using TowerApi.Repositories.DataBase;
using TowerApi.Models.Organization;

namespace TowerApi.Repositories.Organization
{
    public class OrganizationsRepository : IOrganizationsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public OrganizationsRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // =========================================================
        // ADD
        // =========================================================

        public async Task<OrganizationResult> AddAsync(
            OrganizationCreateRequest request,
            int userCreater)
        {
            using var connection = _connectionFactory.CreateConnection();

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

            // از JWT
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

            var organization =
                await connection.QuerySingleOrDefaultAsync<Organizations>(
                    "dbo.OrganizationsAdd",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            return new OrganizationResult
            {
                ResultCode =
                    parameters.Get<int>("@ResultCode"),

                ResultMessage =
                    parameters.Get<string>("@ResultMessage"),

                Organization = organization
            };
        }


        // =========================================================
        // EDIT
        // =========================================================

        public async Task<OrganizationResult> EditAsync(
            long orgId,
            OrganizationUpdateRequest request,
            int userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

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

            // از JWT
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

            var organization =
                await connection.QuerySingleOrDefaultAsync<Organizations>(
                    "dbo.OrganizationsEdit",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            return new OrganizationResult
            {
                ResultCode =
                    parameters.Get<int>("@ResultCode"),

                ResultMessage =
                    parameters.Get<string>("@ResultMessage"),

                Organization = organization
            };
        }


        // =========================================================
        // DELETE
        // =========================================================

        public async Task<OrganizationResult> DeleteAsync(
            long orgId,
            int userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@OrgId",
                orgId,
                DbType.Int64);

            // از JWT
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

            return new OrganizationResult
            {
                ResultCode =
                    parameters.Get<int>("@ResultCode"),

                ResultMessage =
                    parameters.Get<string>("@ResultMessage")
            };
        }


        // =========================================================
        // GET
        // =========================================================

        public async Task<OrganizationResult> GetAsync(
            long? orgId,
            OrganizationQueryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@OrgId",
                orgId,
                DbType.Int64);

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

            var organizations =
                (await connection.QueryAsync<Organizations>(
                    "dbo.OrganizationsGet",
                    parameters,
                    commandType: CommandType.StoredProcedure))
                .ToList();

            var resultCode =
                parameters.Get<int>("@ResultCode");

            var resultMessage =
                parameters.Get<string>("@ResultMessage");

            return new OrganizationResult
            {
                ResultCode = resultCode,

                ResultMessage = resultMessage,

                Organization =
                    orgId.HasValue
                        ? organizations.FirstOrDefault()
                        : null,

                Organizations =
                    orgId.HasValue
                        ? new List<Organizations>()
                        : organizations
            };
        }
    }
}