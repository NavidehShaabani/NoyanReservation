using System.Data;
using Dapper;
using TowerApi.Models.BuildingElevators;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.BuildingElevators
{
    public class BuildingElevatorRepository : IBuildingElevatorRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BuildingElevatorRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        private static DynamicParameters CreateParameters(
            BuildingElevatorCreateRequest request,
            int? userId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@BuildingId", request.BuildingId, DbType.Int64);
            parameters.Add("@ElevatorCode", request.ElevatorCode, DbType.String, size: 60);
            parameters.Add("@ElevatorName", request.ElevatorName, DbType.String, size: 200);
            parameters.Add("@ElevatorNameEn", request.ElevatorNameEn, DbType.String, size: 200);
            parameters.Add("@ElevatorType", request.ElevatorType, DbType.Byte);
            parameters.Add("@Capacity", request.Capacity, DbType.Int32);
            parameters.Add("@MaxWeight", request.MaxWeight, DbType.Decimal);
            parameters.Add("@IsService", request.IsService, DbType.Boolean);
            parameters.Add("@IsEmergency", request.IsEmergency, DbType.Boolean);
            parameters.Add("@Description", request.Description, DbType.String, size: 1000);
            parameters.Add("@DisplayOrder", request.DisplayOrder, DbType.Int32);
            parameters.Add("@IsActive", request.IsActive, DbType.Boolean);
            parameters.Add("@UserId", userId, DbType.Int32);

            return parameters;
        }

        private static void AddOutputParameters(DynamicParameters parameters)
        {
            parameters.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add("@ResultMessage", dbType: DbType.String,
                size: 500, direction: ParameterDirection.Output);
        }

        public async Task<(int ResultCode, string ResultMessage, BuildingElevatorViewModel? Data)>
            AddAsync(BuildingElevatorCreateRequest request, int? userCreater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateParameters(request, userCreater);
            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingElevatorViewModel>(
                "dbo.BuildingElevatorsAdd",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? string.Empty,
                data
            );
        }

        public async Task<(int ResultCode, string ResultMessage, BuildingElevatorViewModel? Data)>
            EditAsync(long buildingElevatorId, BuildingElevatorUpdateRequest request, int? userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateParameters(request, userUpdater);
            parameters.Add("@BuildingElevatorId", buildingElevatorId, DbType.Int64);
            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingElevatorViewModel>(
                "dbo.BuildingElevatorsEdit",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? string.Empty,
                data
            );
        }

        public async Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long buildingElevatorId, int? userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@BuildingElevatorId", buildingElevatorId, DbType.Int64);
            parameters.Add("@UserUpdater", userUpdater, DbType.Int32);
            AddOutputParameters(parameters);

            await connection.ExecuteAsync(
                "dbo.BuildingElevatorsDel",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? string.Empty
            );
        }

        public async Task<(int ResultCode, string ResultMessage, BuildingElevatorViewModel? Data)>
            GetByIdAsync(long buildingElevatorId, bool includeDeleted)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@BuildingElevatorId", buildingElevatorId, DbType.Int64);
            parameters.Add("@BuildingId", null, DbType.Int64);
            parameters.Add("@Search", null, DbType.String);
            parameters.Add("@ElevatorType", null, DbType.Byte);
            parameters.Add("@IsService", null, DbType.Boolean);
            parameters.Add("@IsEmergency", null, DbType.Boolean);
            parameters.Add("@IsActive", null, DbType.Boolean);
            parameters.Add("@IncludeDeleted", includeDeleted, DbType.Boolean);
            parameters.Add("@PageNumber", 1, DbType.Int32);
            parameters.Add("@PageSize", 1, DbType.Int32);
            AddOutputParameters(parameters);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingElevatorViewModel>(
                "dbo.BuildingElevatorsGet",
                parameters,
                commandType: CommandType.StoredProcedure);

            var code = parameters.Get<int>("@ResultCode");
            var message = parameters.Get<string>("@ResultMessage") ?? string.Empty;

            if (code == 200 && data == null)
                return (404, "BuildingElevator.NotFound", null);

            return (code, message, data);
        }

        public async Task<(int ResultCode, string ResultMessage, List<BuildingElevatorViewModel> Data)>
            GetListAsync(BuildingElevatorQueryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@BuildingElevatorId", null, DbType.Int64);
            parameters.Add("@BuildingId", request.BuildingId, DbType.Int64);
            parameters.Add("@Search", request.Search, DbType.String, size: 200);
            parameters.Add("@ElevatorType", request.ElevatorType, DbType.Byte);
            parameters.Add("@IsService", request.IsService, DbType.Boolean);
            parameters.Add("@IsEmergency", request.IsEmergency, DbType.Boolean);
            parameters.Add("@IsActive", request.IsActive, DbType.Boolean);
            parameters.Add("@IncludeDeleted", request.IncludeDeleted, DbType.Boolean);
            parameters.Add("@PageNumber", request.PageNumber, DbType.Int32);
            parameters.Add("@PageSize", request.PageSize, DbType.Int32);
            AddOutputParameters(parameters);

            var data = (await connection.QueryAsync<BuildingElevatorViewModel>(
                "dbo.BuildingElevatorsGet",
                parameters,
                commandType: CommandType.StoredProcedure)).ToList();

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? string.Empty,
                data
            );
        }

        private static DataTable CreateBulkDataTable(IEnumerable<BuildingElevatorBulkItem> items)
        {
            var table = new DataTable();

            table.Columns.Add("BuildingElevatorId", typeof(long));
            table.Columns.Add("BuildingId", typeof(long));
            table.Columns.Add("ElevatorCode", typeof(string));
            table.Columns.Add("ElevatorName", typeof(string));
            table.Columns.Add("ElevatorNameEn", typeof(string));
            table.Columns.Add("ElevatorType", typeof(byte));
            table.Columns.Add("Capacity", typeof(int));
            table.Columns.Add("MaxWeight", typeof(decimal));
            table.Columns.Add("IsService", typeof(bool));
            table.Columns.Add("IsEmergency", typeof(bool));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("DisplayOrder", typeof(int));
            table.Columns.Add("IsActive", typeof(bool));

            foreach (var item in items)
            {
                table.Rows.Add(
                    item.BuildingElevatorId.HasValue ? item.BuildingElevatorId.Value : DBNull.Value,
                    item.BuildingId,
                    item.ElevatorCode,
                    item.ElevatorName,
                    (object?)item.ElevatorNameEn ?? DBNull.Value,
                    item.ElevatorType,
                    item.Capacity.HasValue ? item.Capacity.Value : DBNull.Value,
                    item.MaxWeight.HasValue ? item.MaxWeight.Value : DBNull.Value,
                    item.IsService,
                    item.IsEmergency,
                    (object?)item.Description ?? DBNull.Value,
                    item.DisplayOrder,
                    item.IsActive
                );
            }

            return table;
        }

        public async Task<(int ResultCode, string? ResultMessage)>
            BulkSaveAsync(IEnumerable<BuildingElevatorBulkItem> items, long currentUserId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add(
                "@Items",
                CreateBulkDataTable(items).AsTableValuedParameter("dbo.BuildingElevatorBulkType"));

            parameters.Add("@CurrentUserId", currentUserId, DbType.Int64);

            AddOutputParameters(parameters);

            await connection.ExecuteAsync(
                "dbo.BuildingElevators_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage")
            );
        }
    }
}
