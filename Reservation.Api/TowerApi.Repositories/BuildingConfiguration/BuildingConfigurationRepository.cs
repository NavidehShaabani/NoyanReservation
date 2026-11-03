using System.Data;
using Dapper;
using TowerApi.Models.BuildingConfiguration;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.BuildingConfiguration
{
    public class BuildingConfigurationRepository
        : IBuildingConfigurationRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BuildingConfigurationRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            BuildingConfigurationViewModel? Data)>
            AddAsync(
                BuildingConfigurationCreateRequest request,
                int? userCreater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            AddRequestParameters(parameters, request);

            parameters.Add("@UserCreater", userCreater);
            parameters.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);
            parameters.Add("@ResultMessage", dbType: DbType.String,
                size: 500, direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<
                BuildingConfigurationViewModel>(
                "dbo.BuildingConfigurationsAdd",
                parameters,
                commandType: CommandType.StoredProcedure);

            var code = parameters.Get<int>("@ResultCode");
            var message = parameters.Get<string>("@ResultMessage") ?? "";

            return (code, message, data);
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            BuildingConfigurationViewModel? Data)>
            EditAsync(
                long buildingConfigurationId,
                BuildingConfigurationUpdateRequest request,
                int? userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingConfigurationId",
                buildingConfigurationId);

            AddRequestParameters(parameters, request);

            parameters.Add("@UserUpdater", userUpdater);
            parameters.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);
            parameters.Add("@ResultMessage", dbType: DbType.String,
                size: 500, direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<
                BuildingConfigurationViewModel>(
                "dbo.BuildingConfigurationsEdit",
                parameters,
                commandType: CommandType.StoredProcedure);

            var code = parameters.Get<int>("@ResultCode");
            var message = parameters.Get<string>("@ResultMessage") ?? "";

            return (code, message, data);
        }

        public async Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long buildingConfigurationId, int? userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingConfigurationId",
                buildingConfigurationId);
            parameters.Add("@UserUpdater", userUpdater);
            parameters.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);
            parameters.Add("@ResultMessage", dbType: DbType.String,
                size: 500, direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.BuildingConfigurationsDel",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? ""
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            BuildingConfigurationViewModel? Data)>
            GetByIdAsync(long buildingConfigurationId, bool includeDeleted)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingConfigurationId",
                buildingConfigurationId);
            parameters.Add("@BuildingId", dbType: DbType.Int64);
            parameters.Add("@IsActive", dbType: DbType.Boolean);
            parameters.Add("@IncludeDeleted", includeDeleted);
            parameters.Add("@PageNumber", 1);
            parameters.Add("@PageSize", 1);

            parameters.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);
            parameters.Add("@ResultMessage", dbType: DbType.String,
                size: 500, direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<
                BuildingConfigurationViewModel>(
                "dbo.BuildingConfigurationsGet",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "",
                data
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            List<BuildingConfigurationViewModel> Data)>
            GetListAsync(BuildingConfigurationQueryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingConfigurationId",
                dbType: DbType.Int64);
            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@IncludeDeleted", request.IncludeDeleted);
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);

            parameters.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);
            parameters.Add("@ResultMessage", dbType: DbType.String,
                size: 500, direction: ParameterDirection.Output);

            var data = (await connection.QueryAsync<
                BuildingConfigurationViewModel>(
                "dbo.BuildingConfigurationsGet",
                parameters,
                commandType: CommandType.StoredProcedure)).ToList();

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? "",
                data
            );
        }

        public async Task<(int ResultCode, string? ResultMessage)>
            BulkSaveAsync(
                IEnumerable<BuildingConfigurationBulkItem> items,
                long currentUserId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var table = new DataTable();

            table.Columns.Add("BuildingConfigurationId", typeof(long));
            table.Columns.Add("BuildingId", typeof(long));
            table.Columns.Add("BasementFloorCount", typeof(int));
            table.Columns.Add("GroundFloorCount", typeof(int));
            table.Columns.Add("AboveGroundFloorCount", typeof(int));
            table.Columns.Add("StaircaseCount", typeof(int));
            table.Columns.Add("ElevatorCount", typeof(int));
            table.Columns.Add("DefaultUnitsPerFloor", typeof(int));
            table.Columns.Add("FloorNamingType", typeof(int));
            table.Columns.Add("FloorNumberStart", typeof(int));
            table.Columns.Add("UnitNamingType", typeof(int));
            table.Columns.Add("UnitNumberPattern", typeof(string));
            table.Columns.Add("UnitLetterStart", typeof(string));
            table.Columns.Add("UnitLetterEnd", typeof(string));
            table.Columns.Add("IsUnitNumberUnique", typeof(bool));
            table.Columns.Add("ResetUnitNumberPerFloor", typeof(bool));
            table.Columns.Add("AllowExceedFloorCapacity", typeof(bool));
            table.Columns.Add("IsActive", typeof(bool));

            foreach (var item in items)
            {
                table.Rows.Add(
                    item.BuildingConfigurationId ?? 0L,
                    item.BuildingId,
                    item.BasementFloorCount,
                    item.GroundFloorCount,
                    item.AboveGroundFloorCount,
                    item.StaircaseCount,
                    item.ElevatorCount,
                    item.DefaultUnitsPerFloor,
                    item.FloorNamingType,
                    item.FloorNumberStart,
                    item.UnitNamingType,
                    item.UnitNumberPattern,
                    (object?)item.UnitLetterStart ?? DBNull.Value,
                    (object?)item.UnitLetterEnd ?? DBNull.Value,
                    item.IsUnitNumberUnique,
                    item.ResetUnitNumberPerFloor,
                    item.AllowExceedFloorCapacity,
                    item.IsActive
                );
            }

            var parameters = new DynamicParameters();

            parameters.Add("@Items",
                table.AsTableValuedParameter(
                    "dbo.BuildingConfigurationBulkType"));

            parameters.Add("@CurrentUserId", currentUserId,
                DbType.Int64);

            parameters.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add("@ResultMessage", dbType: DbType.String,
                size: 500, direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.BuildingConfigurations_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage")
            );
        }

        private static void AddRequestParameters(
            DynamicParameters parameters,
            BuildingConfigurationCreateRequest request)
        {
            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@BasementFloorCount",
                request.BasementFloorCount);
            parameters.Add("@GroundFloorCount",
                request.GroundFloorCount);
            parameters.Add("@AboveGroundFloorCount",
                request.AboveGroundFloorCount);
            parameters.Add("@StaircaseCount", request.StaircaseCount);
            parameters.Add("@ElevatorCount", request.ElevatorCount);
            parameters.Add("@DefaultUnitsPerFloor",
                request.DefaultUnitsPerFloor);
            parameters.Add("@FloorNamingType", request.FloorNamingType);
            parameters.Add("@FloorNumberStart", request.FloorNumberStart);
            parameters.Add("@UnitNamingType", request.UnitNamingType);
            parameters.Add("@UnitNumberPattern", request.UnitNumberPattern);
            parameters.Add("@UnitLetterStart", request.UnitLetterStart);
            parameters.Add("@UnitLetterEnd", request.UnitLetterEnd);
            parameters.Add("@IsUnitNumberUnique",
                request.IsUnitNumberUnique);
            parameters.Add("@ResetUnitNumberPerFloor",
                request.ResetUnitNumberPerFloor);
            parameters.Add("@AllowExceedFloorCapacity",
                request.AllowExceedFloorCapacity);
            parameters.Add("@IsActive", request.IsActive);
        }
    }
}
