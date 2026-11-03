
using System.Data;
using Dapper;
using TowerApi.Models.BuildingStaircase;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.BuildingStaircase
{
    public class BuildingStaircaseRepository : IBuildingStaircaseRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BuildingStaircaseRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(int ResultCode, string ResultMessage, BuildingStaircaseViewModel? Data)>
            AddAsync(BuildingStaircaseCreateRequest request, int? userCreater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateParameters(request);
            parameters.Add("@UserCreater", userCreater, DbType.Int32);
            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingStaircaseViewModel>(
                "dbo.BuildingStaircasesAdd",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError",
                data
            );
        }

        public async Task<(int ResultCode, string ResultMessage, BuildingStaircaseViewModel? Data)>
            EditAsync(long buildingStaircaseId, BuildingStaircaseUpdateRequest request, int? userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateParameters(request);
            parameters.Add("@BuildingStaircaseId", buildingStaircaseId, DbType.Int64);
            parameters.Add("@UserUpdater", userUpdater, DbType.Int32);
            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingStaircaseViewModel>(
                "dbo.BuildingStaircasesEdit",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError",
                data
            );
        }

        public async Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long buildingStaircaseId, int? userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@BuildingStaircaseId", buildingStaircaseId, DbType.Int64);
            parameters.Add("@UserUpdater", userUpdater, DbType.Int32);
            AddOutputParameters(parameters);

            await connection.ExecuteAsync(
                "dbo.BuildingStaircasesDel",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError"
            );
        }

        public async Task<(int ResultCode, string ResultMessage, BuildingStaircaseViewModel? Data)>
            GetByIdAsync(long buildingStaircaseId, bool includeDeleted)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@BuildingStaircaseId", buildingStaircaseId, DbType.Int64);
            parameters.Add("@BuildingId", null, DbType.Int64);
            parameters.Add("@Search", null, DbType.String);
            parameters.Add("@StaircaseType", null, DbType.Byte);
            parameters.Add("@IsEmergency", null, DbType.Boolean);
            parameters.Add("@IsActive", null, DbType.Boolean);
            parameters.Add("@IncludeDeleted", includeDeleted, DbType.Boolean);
            parameters.Add("@PageNumber", 1, DbType.Int32);
            parameters.Add("@PageSize", 1, DbType.Int32);
            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingStaircaseViewModel>(
                "dbo.BuildingStaircasesGet",
                parameters,
                commandType: CommandType.StoredProcedure);

            var code = parameters.Get<int>("@ResultCode");
            var message = parameters.Get<string>("@ResultMessage") ?? "Common.SystemError";

            if (code == 200 && data == null)
                return (404, "BuildingStaircases.NotFound", null);

            return (code, message, data);
        }

        public async Task<(int ResultCode, string ResultMessage, List<BuildingStaircaseViewModel> Data)>
            GetListAsync(BuildingStaircaseQueryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@BuildingStaircaseId", null, DbType.Int64);
            parameters.Add("@BuildingId", request.BuildingId, DbType.Int64);
            parameters.Add("@Search", request.Search, DbType.String);
            parameters.Add("@StaircaseType", request.StaircaseType, DbType.Byte);
            parameters.Add("@IsEmergency", request.IsEmergency, DbType.Boolean);
            parameters.Add("@IsActive", request.IsActive, DbType.Boolean);
            parameters.Add("@IncludeDeleted", request.IncludeDeleted, DbType.Boolean);
            parameters.Add("@PageNumber", request.PageNumber, DbType.Int32);
            parameters.Add("@PageSize", request.PageSize, DbType.Int32);
            AddOutputParameters(parameters);

            var data = (await connection.QueryAsync<BuildingStaircaseViewModel>(
                "dbo.BuildingStaircasesGet",
                parameters,
                commandType: CommandType.StoredProcedure)).ToList();

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError",
                data
            );
        }

        public async Task<(int ResultCode, string? ResultMessage)>
            BulkSaveAsync(IEnumerable<BuildingStaircaseBulkItem> items, long currentUserId)
        {
            if (currentUserId <= 0 || currentUserId > int.MaxValue)
                return (400, "Common.InvalidUserId");

            using var connection = _connectionFactory.CreateConnection();

            var table = CreateBulkDataTable(items);

            var parameters = new DynamicParameters();
            parameters.Add(
                "@Items",
                table.AsTableValuedParameter("dbo.BuildingStaircaseBulkSaveType"));

            parameters.Add("@CurrentUserId", currentUserId, DbType.Int64);
            AddOutputParameters(parameters);

            await connection.ExecuteAsync(
                "dbo.BuildingStaircases_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError"
            );
        }

        private static DynamicParameters CreateParameters(
            BuildingStaircaseCreateRequest request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@BuildingId", request.BuildingId, DbType.Int64);
            parameters.Add("@StaircaseCode", request.StaircaseCode, DbType.String, size: 60);
            parameters.Add("@StaircaseName", request.StaircaseName, DbType.String, size: 200);
            parameters.Add("@StaircaseNameEn", request.StaircaseNameEn, DbType.String, size: 200);
            parameters.Add("@StaircaseType", request.StaircaseType, DbType.Byte);
            parameters.Add("@IsEmergency", request.IsEmergency, DbType.Boolean);
            parameters.Add("@Description", request.Description, DbType.String, size: 1000);
            parameters.Add("@DisplayOrder", request.DisplayOrder, DbType.Int32);
            parameters.Add("@IsActive", request.IsActive, DbType.Boolean);

            return parameters;
        }

        private static void AddOutputParameters(DynamicParameters parameters)
        {
            parameters.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add("@ResultMessage", dbType: DbType.String,
                size: 500, direction: ParameterDirection.Output);
        }

        private static DataTable CreateBulkDataTable(
            IEnumerable<BuildingStaircaseBulkItem> items)
        {
            var table = new DataTable();

            table.Columns.Add("BuildingStaircaseId", typeof(long));
            table.Columns.Add("BuildingId", typeof(long));
            table.Columns.Add("StaircaseCode", typeof(string));
            table.Columns.Add("StaircaseName", typeof(string));
            table.Columns.Add("StaircaseNameEn", typeof(string));
            table.Columns.Add("StaircaseType", typeof(byte));
            table.Columns.Add("IsEmergency", typeof(bool));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("DisplayOrder", typeof(int));
            table.Columns.Add("IsActive", typeof(bool));

            foreach (var item in items)
            {
                table.Rows.Add(
                    item.BuildingStaircaseId.HasValue && item.BuildingStaircaseId.Value > 0
                        ? item.BuildingStaircaseId.Value : DBNull.Value,
                    item.BuildingId,
                    item.StaircaseCode,
                    item.StaircaseName,
                    (object?)item.StaircaseNameEn ?? DBNull.Value,
                    item.StaircaseType,
                    item.IsEmergency,
                    (object?)item.Description ?? DBNull.Value,
                    item.DisplayOrder,
                    item.IsActive ?? true
                );
            }

            return table;
        }
    }
}
