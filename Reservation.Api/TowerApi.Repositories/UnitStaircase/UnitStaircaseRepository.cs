using System.Data;
using Dapper;
using TowerApi.Models.UnitStaircase;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.UnitStaircase
{
    public class UnitStaircaseRepository : IUnitStaircaseRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UnitStaircaseRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            UnitStaircaseViewModel? Data)>
            AddAsync(UnitStaircaseCreateRequest request, int? userCreater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateParameters(request);

            parameters.Add("@UserCreater", userCreater, DbType.Int32);
            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<UnitStaircaseViewModel>(
                "dbo.UnitStaircasesAdd",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage")
                    ?? "Common.SystemError",
                data
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            UnitStaircaseViewModel? Data)>
            EditAsync(
                long unitStaircaseId,
                UnitStaircaseUpdateRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateParameters(request);

            parameters.Add(
                "@UnitStaircaseId",
                unitStaircaseId,
                DbType.Int64);

            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<UnitStaircaseViewModel>(
                "dbo.UnitStaircasesEdit",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage")
                    ?? "Common.SystemError",
                data
            );
        }

        public async Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long unitStaircaseId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@UnitStaircaseId",
                unitStaircaseId,
                DbType.Int64);

            AddOutputParameters(parameters);

            await connection.ExecuteAsync(
                "dbo.UnitStaircasesDel",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage")
                    ?? "Common.SystemError"
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            UnitStaircaseViewModel? Data)>
            GetByIdAsync(long unitStaircaseId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@UnitStaircaseId",
                unitStaircaseId,
                DbType.Int64);

            parameters.Add("@UnitId", null, DbType.Int64);
            parameters.Add("@BuildingFloorId", null, DbType.Int64);
            parameters.Add("@BuildingStaircaseId", null, DbType.Int64);
            parameters.Add("@IsPrimary", null, DbType.Boolean);
            parameters.Add("@IsActive", null, DbType.Boolean);
            parameters.Add("@PageNumber", 1, DbType.Int32);
            parameters.Add("@PageSize", 1, DbType.Int32);

            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<UnitStaircaseViewModel>(
                "dbo.UnitStaircasesGet",
                parameters,
                commandType: CommandType.StoredProcedure);

            var code = parameters.Get<int>("@ResultCode");
            var message = parameters.Get<string>("@ResultMessage")
                          ?? "Common.SystemError";

            if (code == 200 && data == null)
                return (404, "UnitStaircases.NotFound", null);

            return (code, message, data);
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            List<UnitStaircaseViewModel> Data)>
            GetListAsync(UnitStaircaseQueryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@UnitStaircaseId", null, DbType.Int64);
            parameters.Add("@UnitId", request.UnitId, DbType.Int64);
            parameters.Add(
                "@BuildingFloorId",
                request.BuildingFloorId,
                DbType.Int64);

            parameters.Add(
                "@BuildingStaircaseId",
                request.BuildingStaircaseId,
                DbType.Int64);

            parameters.Add("@IsPrimary", request.IsPrimary, DbType.Boolean);
            parameters.Add("@IsActive", request.IsActive, DbType.Boolean);
            parameters.Add("@PageNumber", request.PageNumber, DbType.Int32);
            parameters.Add("@PageSize", request.PageSize, DbType.Int32);

            AddOutputParameters(parameters);

            var data = (await connection.QueryAsync<UnitStaircaseViewModel>(
                "dbo.UnitStaircasesGet",
                parameters,
                commandType: CommandType.StoredProcedure)).ToList();

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage")
                    ?? "Common.SystemError",
                data
            );
        }

        public async Task<(int ResultCode, string? ResultMessage)>
            BulkSaveAsync(
                IEnumerable<UnitStaircaseBulkItem> items,
                long currentUserId)
        {
            if (currentUserId <= 0 || currentUserId > int.MaxValue)
                return (400, "Common.InvalidUserId");

            using var connection = _connectionFactory.CreateConnection();

            var table = CreateBulkDataTable(items);

            var parameters = new DynamicParameters();

            parameters.Add(
                "@Items",
                table.AsTableValuedParameter(
                    "dbo.UnitStaircaseBulkSaveType"));

            parameters.Add(
                "@CurrentUserId",
                currentUserId,
                DbType.Int64);

            AddOutputParameters(parameters);

            await connection.ExecuteAsync(
                "dbo.UnitStaircases_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage")
                    ?? "Common.SystemError"
            );
        }

        private static DynamicParameters CreateParameters(
            UnitStaircaseCreateRequest request)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@UnitId", request.UnitId, DbType.Int64);
            parameters.Add(
                "@BuildingFloorId",
                request.BuildingFloorId,
                DbType.Int64);

            parameters.Add(
                "@BuildingStaircaseId",
                request.BuildingStaircaseId,
                DbType.Int64);

            parameters.Add("@IsPrimary", request.IsPrimary, DbType.Boolean);
            parameters.Add("@IsActive", request.IsActive, DbType.Boolean);

            return parameters;
        }

        private static void AddOutputParameters(
            DynamicParameters parameters)
        {
            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);
        }

        private static DataTable CreateBulkDataTable(
            IEnumerable<UnitStaircaseBulkItem> items)
        {
            var table = new DataTable();

            table.Columns.Add("UnitStaircaseId", typeof(long));
            table.Columns.Add("UnitId", typeof(long));
            table.Columns.Add("BuildingFloorId", typeof(long));
            table.Columns.Add("BuildingStaircaseId", typeof(long));
            table.Columns.Add("IsPrimary", typeof(bool));
            table.Columns.Add("IsActive", typeof(bool));

            foreach (var item in items)
            {
                table.Rows.Add(
                    item.UnitStaircaseId.HasValue &&
                    item.UnitStaircaseId.Value > 0
                        ? item.UnitStaircaseId.Value
                        : DBNull.Value,

                    item.UnitId,
                    item.BuildingFloorId,
                    item.BuildingStaircaseId,
                    item.IsPrimary ?? false,
                    item.IsActive ?? true
                );
            }

            return table;
        }
    }
}
