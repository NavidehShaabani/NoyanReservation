using TowerApi.Models.BuildingFloorStaircase;
using TowerApi.Repositories.DataBase;
using System.Data;
using Dapper;

namespace TowerApi.Repositories.BuildingFloorStaircase
{
    public class BuildingFloorStaircaseRepository
        : IBuildingFloorStaircaseRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BuildingFloorStaircaseRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(int ResultCode, string ResultMessage,
            BuildingFloorStaircaseViewModel? Data)>
            AddAsync(BuildingFloorStaircaseCreateRequest request, int? userCreater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateParameters(request);
            parameters.Add("@UserCreater", userCreater, DbType.Int32);
            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingFloorStaircaseViewModel>(
                "dbo.BuildingFloorStaircasesAdd",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError",
                data
            );
        }

        public async Task<(int ResultCode, string ResultMessage,
            BuildingFloorStaircaseViewModel? Data)>
            EditAsync(long id, BuildingFloorStaircaseUpdateRequest request,
                int? userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateParameters(request);
            parameters.Add("@BuildingFloorStaircaseId", id, DbType.Int64);
            parameters.Add("@UserUpdater", userUpdater, DbType.Int32);
            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingFloorStaircaseViewModel>(
                "dbo.BuildingFloorStaircasesEdit",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError",
                data
            );
        }

        public async Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long id, int? userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@BuildingFloorStaircaseId", id, DbType.Int64);
            parameters.Add("@UserUpdater", userUpdater, DbType.Int32);
            AddOutputParameters(parameters);

            await connection.ExecuteAsync(
                "dbo.BuildingFloorStaircasesDel",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError"
            );
        }

        public async Task<(int ResultCode, string ResultMessage,
            BuildingFloorStaircaseViewModel? Data)>
            GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@BuildingFloorStaircaseId", id, DbType.Int64);
            parameters.Add("@BuildingId", null, DbType.Int64);
            parameters.Add("@BuildingFloorId", null, DbType.Int64);
            parameters.Add("@BuildingStaircaseId", null, DbType.Int64);
            parameters.Add("@IsActive", null, DbType.Boolean);
            parameters.Add("@PageNumber", 1, DbType.Int32);
            parameters.Add("@PageSize", 1, DbType.Int32);
            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingFloorStaircaseViewModel>(
                "dbo.BuildingFloorStaircasesGet",
                parameters,
                commandType: CommandType.StoredProcedure);

            var code = parameters.Get<int>("@ResultCode");
            var message = parameters.Get<string>("@ResultMessage")
                          ?? "Common.SystemError";

            if (code == 200 && data == null)
                return (404, "BuildingFloorStaircases.NotFound", null);

            return (code, message, data);
        }

        public async Task<(int ResultCode, string ResultMessage,
            List<BuildingFloorStaircaseViewModel> Data)>
            GetListAsync(BuildingFloorStaircaseQueryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@BuildingFloorStaircaseId", null, DbType.Int64);
            parameters.Add("@BuildingId", request.BuildingId, DbType.Int64);
            parameters.Add("@BuildingFloorId", request.BuildingFloorId, DbType.Int64);
            parameters.Add("@BuildingStaircaseId", request.BuildingStaircaseId, DbType.Int64);
            parameters.Add("@IsActive", request.IsActive, DbType.Boolean);
            parameters.Add("@PageNumber", request.PageNumber, DbType.Int32);
            parameters.Add("@PageSize", request.PageSize, DbType.Int32);
            AddOutputParameters(parameters);

            var data = (await connection.QueryAsync<BuildingFloorStaircaseViewModel>(
                "dbo.BuildingFloorStaircasesGet",
                parameters,
                commandType: CommandType.StoredProcedure)).ToList();

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError",
                data
            );
        }

        public async Task<(int ResultCode, string? ResultMessage)>
            BulkSaveAsync(IEnumerable<BuildingFloorStaircaseBulkItem> items,
                long currentUserId)
        {
            if (currentUserId <= 0 || currentUserId > int.MaxValue)
                return (400, "Common.InvalidUserId");

            using var connection = _connectionFactory.CreateConnection();

            var table = CreateBulkDataTable(items);

            var parameters = new DynamicParameters();
            parameters.Add(
                "@Items", 
                table.AsTableValuedParameter("dbo.BuildingFloorStaircaseBulkSaveType"));

            parameters.Add("@CurrentUserId", currentUserId, DbType.Int64);
            AddOutputParameters(parameters);

            await connection.ExecuteAsync(
                "dbo.BuildingFloorStaircases_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError"
            );
        }

        private static DynamicParameters CreateParameters(
            BuildingFloorStaircaseCreateRequest request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@BuildingId", request.BuildingId, DbType.Int64);
            parameters.Add("@BuildingFloorId", request.BuildingFloorId, DbType.Int64);
            parameters.Add("@BuildingStaircaseId", request.BuildingStaircaseId, DbType.Int64);
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
            IEnumerable<BuildingFloorStaircaseBulkItem> items)
        {
            var table = new DataTable();

            table.Columns.Add("BuildingFloorStaircaseId", typeof(long));
            table.Columns.Add("BuildingId", typeof(long));
            table.Columns.Add("BuildingFloorId", typeof(long));
            table.Columns.Add("BuildingStaircaseId", typeof(long));
            table.Columns.Add("IsActive", typeof(bool));

            foreach (var item in items)
            {
                table.Rows.Add(
                    item.BuildingFloorStaircaseId.HasValue &&
                    item.BuildingFloorStaircaseId.Value > 0
                        ? item.BuildingFloorStaircaseId.Value
                        : DBNull.Value,
                    item.BuildingId,
                    item.BuildingFloorId,
                    item.BuildingStaircaseId,
                    item.IsActive ?? true
                );
            }

            return table;
        }
    }
}
