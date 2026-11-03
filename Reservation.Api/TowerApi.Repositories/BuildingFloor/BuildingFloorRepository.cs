
using System.Data;
using Dapper;
using TowerApi.Models.BuildingFloor;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.BuildingFloor
{
    public class BuildingFloorRepository : IBuildingFloorRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BuildingFloorRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            BuildingFloorViewModel? Data)>
            AddAsync(
                BuildingFloorCreateRequest request,
                int? userCreater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@FloorNumber", request.FloorNumber);
            parameters.Add("@FloorCode", request.FloorCode);
            parameters.Add("@FloorName", request.FloorName);
            parameters.Add("@FloorNameEn", request.FloorNameEn);
            parameters.Add("@MaxUnits", request.MaxUnits);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@UserCreater", userCreater);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingFloorViewModel>(
                "dbo.BuildingFloorsAdd",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? string.Empty,
                data
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            BuildingFloorViewModel? Data)>
            EditAsync(
                long buildingFloorId,
                BuildingFloorUpdateRequest request,
                int? userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingFloorId", buildingFloorId);
            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@FloorNumber", request.FloorNumber);
            parameters.Add("@FloorCode", request.FloorCode);
            parameters.Add("@FloorName", request.FloorName);
            parameters.Add("@FloorNameEn", request.FloorNameEn);
            parameters.Add("@MaxUnits", request.MaxUnits);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@UserUpdater", userUpdater);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingFloorViewModel>(
                "dbo.BuildingFloorsEdit",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? string.Empty,
                data
            );
        }

        public async Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(
                long buildingFloorId,
                int? userUpdater)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingFloorId", buildingFloorId);
            parameters.Add("@UserUpdater", userUpdater);

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
                "dbo.BuildingFloorsDel",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? string.Empty
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            BuildingFloorViewModel? Data)>
            GetByIdAsync(long buildingFloorId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingFloorId", buildingFloorId);
            parameters.Add("@BuildingId", null);
            parameters.Add("@FloorNumber", null);
            parameters.Add("@Search", null);
            parameters.Add("@IsActive", null);
            parameters.Add("@PageNumber", 1);
            parameters.Add("@PageSize", 1);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingFloorViewModel>(
                "dbo.BuildingFloorsGet",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? string.Empty,
                data
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            List<BuildingFloorViewModel> Data)>
            GetListAsync(BuildingFloorQueryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingFloorId", null);
            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@FloorNumber", request.FloorNumber);
            parameters.Add("@Search", request.Search);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data = (await connection.QueryAsync<BuildingFloorViewModel>(
                "dbo.BuildingFloorsGet",
                parameters,
                commandType: CommandType.StoredProcedure)).ToList();

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage") ?? string.Empty,
                data
            );
        }

        public async Task<(int ResultCode, string? ResultMessage)>
            BulkSaveAsync(
                IEnumerable<BuildingFloorBulkItem> items,
                long currentUserId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var table = new DataTable();

            table.Columns.Add("BuildingFloorId", typeof(long));
            table.Columns.Add("BuildingId", typeof(long));
            table.Columns.Add("FloorNumber", typeof(int));
            table.Columns.Add("FloorCode", typeof(string));
            table.Columns.Add("FloorName", typeof(string));
            table.Columns.Add("FloorNameEn", typeof(string));
            table.Columns.Add("MaxUnits", typeof(int));
            table.Columns.Add("IsActive", typeof(bool));

            foreach (var item in items)
            {
                table.Rows.Add(
                    item.BuildingFloorId.HasValue &&
                    item.BuildingFloorId.Value > 0
                        ? item.BuildingFloorId.Value
                        : DBNull.Value,

                    item.BuildingId,
                    item.FloorNumber,
                    item.FloorCode,
                    item.FloorName,
                    (object?)item.FloorNameEn ?? DBNull.Value,
                    item.MaxUnits,
                    item.IsActive ?? true
                );
            }

            var parameters = new DynamicParameters();

            parameters.Add(
                "@Items",
                table.AsTableValuedParameter("dbo.BuildingFloorBulkSaveType"));

            parameters.Add("@CurrentUserId", currentUserId);

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
                "dbo.BuildingFloors_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage")
            );
        }
    }
}
