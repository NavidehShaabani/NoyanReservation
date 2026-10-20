using System.Data;
using Dapper;
using TowerApi.Models.Building;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Building
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BuildingRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            BuildingViewModel? Data)> AddAsync(
                BuildingCreateRequest request,
                int? userCreater)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@BuildingName",
                request.BuildingName);

            parameters.Add(
                "@BuildingAddress",
                request.BuildingAddress);

            parameters.Add(
                "@BuildingDescription",
                request.BuildingDescription);

            parameters.Add(
                "@IsActive",
                request.IsActive);

            parameters.Add(
                "@OrgId",
                request.OrgId);

            parameters.Add(
                "@UserCreater",
                userCreater);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingViewModel>(
                "dbo.BuildingsAdd",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage"),
                data
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            BuildingViewModel? Data)> EditAsync(
                long buildingId,
                BuildingUpdateRequest request,
                int? userUpdater)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@BuildingId",
                buildingId);

            parameters.Add(
                "@BuildingName",
                request.BuildingName);

            parameters.Add(
                "@BuildingAddress",
                request.BuildingAddress);

            parameters.Add(
                "@BuildingDescription",
                request.BuildingDescription);

            parameters.Add(
                "@IsActive",
                request.IsActive);

            parameters.Add(
                "@OrgId",
                request.OrgId);

            parameters.Add(
                "@UserUpdater",
                userUpdater);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingViewModel>(
                "dbo.BuildingsEdit",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage"),
                data
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage)> DeleteAsync(
                long buildingId,
                int? userUpdater)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@BuildingId",
                buildingId);

            parameters.Add(
                "@UserUpdater",
                userUpdater);

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
                "dbo.BuildingsDel",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage")
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            BuildingViewModel? Data)> GetByIdAsync(
                long buildingId,
                bool includeDeleted)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@BuildingId",
                buildingId);

            parameters.Add(
                "@Search",
                null);

            parameters.Add(
                "@PageNumber",
                1);

            parameters.Add(
                "@PageSize",
                1);

            parameters.Add(
                "@IncludeDeleted",
                includeDeleted);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingViewModel>(
                "dbo.BuildingsGet",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage"),
                data
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            List<BuildingViewModel> Data)> GetListAsync(
                BuildingQueryRequest request)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@BuildingId",
                null);

            parameters.Add(
                "@Search",
                request.Search);

            parameters.Add(
                "@PageNumber",
                request.PageNumber);

            parameters.Add(
                "@PageSize",
                request.PageSize);

            parameters.Add(
                "@IncludeDeleted",
                request.IncludeDeleted);

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
                (await connection.QueryAsync<BuildingViewModel>(
                    "dbo.BuildingsGet",
                    parameters,
                    commandType: CommandType.StoredProcedure))
                .AsList();

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage"),
                data
            );
        }
        public async Task<(int ResultCode, string? ResultMessage)>
           BulkSaveAsync(
               IEnumerable<BuildingBulkItem> buildings,
               long currentUserId)
        {
            var table = new DataTable();

            // ترتیب و نوع ستون‌ها باید با dbo.BuildingBulkType
            // در SQL Server یکسان باشد.
            table.Columns.Add("BuildingId", typeof(long));
            table.Columns.Add("BuildingName", typeof(string));
            table.Columns.Add("BuildingAddress", typeof(string));
            table.Columns.Add("BuildingDescription", typeof(string));
            table.Columns.Add("IsActive", typeof(bool));
            table.Columns.Add("OrgId", typeof(long));

            foreach (var building in buildings)
            {
                table.Rows.Add(
                    building.BuildingId.HasValue
                        ? building.BuildingId.Value
                        : DBNull.Value,

                    (object?)building.BuildingName ?? DBNull.Value,

                    (object?)building.BuildingAddress ?? DBNull.Value,

                    (object?)building.BuildingDescription ?? DBNull.Value,

                    building.IsActive.HasValue
                        ? building.IsActive.Value
                        : DBNull.Value,

                    building.OrgId.HasValue
                        ? building.OrgId.Value
                        : DBNull.Value
                );
            }

            var parameters = new DynamicParameters();

            parameters.Add(
                "@Buildings",
                table.AsTableValuedParameter("dbo.BuildingBulkType"));

            parameters.Add(
                "@CurrentUserId",
                currentUserId,
                DbType.Int64);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                "dbo.Buildings_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string?>("@ResultMessage")
            );
        }

        public async Task<(
            int ResultCode,
            string? ResultMessage,
            List<BuildingByOrgResponse> Data
        )> GetByOrgIdAsync(long orgId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@OrgId", orgId, DbType.Int64);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            using var connection = _connectionFactory.CreateConnection();

            var result = (await connection.QueryAsync<BuildingByOrgResponse>(
                "dbo.Buildings_GetByOrgId",
                parameters,
                commandType: CommandType.StoredProcedure
            )).ToList();

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string?>("@ResultMessage"),
                result
            );
        }
    }
}