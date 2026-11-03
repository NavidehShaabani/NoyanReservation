using System.Data;
using Dapper;
using TowerApi.Models.Unit;
using TowerApi.Repositories.DataBase;


namespace TowerApi.Repositories.Unit
{
    public class UnitRepository : IUnitRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UnitRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(int ResultCode, string ResultMessage, UnitViewModel? Data)>
            AddAsync(UnitCreateRequest request, int? userCreater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateParameters(request);
            parameters.Add("@UserCreater", userCreater, DbType.Int32);
            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<UnitViewModel>(
                "dbo.UnitsAdd",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError",
                data
            );
        }

        public async Task<(int ResultCode, string ResultMessage, UnitViewModel? Data)>
            EditAsync(long unitId, UnitUpdateRequest request, int? userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateParameters(request);
            parameters.Add("@UnitId", unitId, DbType.Int64);
            parameters.Add("@UserUpdater", userUpdater, DbType.Int32);
            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<UnitViewModel>(
                "dbo.UnitsEdit",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError",
                data
            );
        }

        public async Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long unitId, int? userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@UnitId", unitId, DbType.Int64);
            parameters.Add("@UserUpdater", userUpdater, DbType.Int32);
            AddOutputParameters(parameters);

            await connection.ExecuteAsync(
                "dbo.UnitsDel",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError"
            );
        }

        public async Task<(int ResultCode, string ResultMessage, UnitViewModel? Data)>
            GetByIdAsync(long unitId, bool includeDeleted)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@UnitId", unitId, DbType.Int64);
            parameters.Add("@BuildingId", null, DbType.Int64);
            parameters.Add("@BuildingFloorId", null, DbType.Int64);
            parameters.Add("@Search", null, DbType.String);
            parameters.Add("@FloorNumber", null, DbType.Int32);
            parameters.Add("@IsActive", null, DbType.Boolean);
            parameters.Add("@PageNumber", 1, DbType.Int32);
            parameters.Add("@PageSize", 1, DbType.Int32);
            parameters.Add("@IncludeDeleted", includeDeleted, DbType.Boolean);
            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<UnitViewModel>(
                "dbo.UnitsGet",
                parameters,
                commandType: CommandType.StoredProcedure);

            var code = parameters.Get<int>("@ResultCode");
            var message = parameters.Get<string>("@ResultMessage")
                          ?? "Common.SystemError";

            if (code == 200 && data == null)
                return (404, "Units.NotFound", null);

            return (code, message, data);
        }

        public async Task<(int ResultCode, string ResultMessage, List<UnitViewModel> Data)>
            GetListAsync(UnitQueryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@UnitId", null, DbType.Int64);
            parameters.Add("@BuildingId", request.BuildingId, DbType.Int64);
            parameters.Add("@BuildingFloorId", request.BuildingFloorId, DbType.Int64);
            parameters.Add("@Search", request.Search, DbType.String);
            parameters.Add("@FloorNumber", request.FloorNumber, DbType.Int32);
            parameters.Add("@IsActive", request.IsActive, DbType.Boolean);
            parameters.Add("@PageNumber", request.PageNumber, DbType.Int32);
            parameters.Add("@PageSize", request.PageSize, DbType.Int32);
            parameters.Add("@IncludeDeleted", request.IncludeDeleted, DbType.Boolean);
            AddOutputParameters(parameters);

            var data = (await connection.QueryAsync<UnitViewModel>(
                "dbo.UnitsGet",
                parameters,
                commandType: CommandType.StoredProcedure)).ToList();

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError",
                data
            );
        }

        public async Task<(int ResultCode, string? ResultMessage)>
            BulkSaveAsync(IEnumerable<UnitBulkItem> units, long currentUserId)
        {
            if (currentUserId <= 0 || currentUserId > int.MaxValue)
                return (400, "Common.InvalidUserId");

            using var connection = _connectionFactory.CreateConnection();

            var table = CreateBulkDataTable(units);

            var parameters = new DynamicParameters();
            parameters.Add(
                "@Items",
                table.AsTableValuedParameter("dbo.UnitBulkSaveType"));

            parameters.Add("@CurrentUserId", currentUserId, DbType.Int64);
            AddOutputParameters(parameters);

            await connection.ExecuteAsync(
                "dbo.Units_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "Common.SystemError"
            );
        }

        private static DynamicParameters CreateParameters(UnitCreateRequest request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@BuildingId", request.BuildingId, DbType.Int64);
            parameters.Add("@BuildingFloorId", request.BuildingFloorId, DbType.Int64);
            parameters.Add("@UnitNumber", request.UnitNumber, DbType.String, size: 100);
            parameters.Add("@FloorNumber", request.FloorNumber, DbType.Int32);
            parameters.Add("@Area", request.Area, DbType.Decimal);
            parameters.Add("@Bedrooms", request.Bedrooms, DbType.Byte);
            parameters.Add("@UnitDescription", request.UnitDescription,
                DbType.String, size: 2000);
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

        private static DataTable CreateBulkDataTable(IEnumerable<UnitBulkItem> units)
        {
            var table = new DataTable();

            table.Columns.Add("UnitId", typeof(long));
            table.Columns.Add("BuildingId", typeof(long));
            table.Columns.Add("BuildingFloorId", typeof(long));
            table.Columns.Add("UnitNumber", typeof(string));
            table.Columns.Add("FloorNumber", typeof(int));
            table.Columns.Add("Area", typeof(decimal));
            table.Columns.Add("Bedrooms", typeof(byte));
            table.Columns.Add("UnitDescription", typeof(string));
            table.Columns.Add("IsActive", typeof(bool));

            foreach (var item in units)
            {
                table.Rows.Add(
                    item.UnitId.HasValue && item.UnitId.Value > 0
                        ? item.UnitId.Value : DBNull.Value,
                    item.BuildingId,
                    (object?)item.BuildingFloorId ?? DBNull.Value,
                    item.UnitNumber,
                    (object?)item.FloorNumber ?? DBNull.Value,
                    (object?)item.Area ?? DBNull.Value,
                    (object?)item.Bedrooms ?? DBNull.Value,
                    (object?)item.UnitDescription ?? DBNull.Value,
                    item.IsActive ?? true
                );
            }

            return table;
        }
    }
}