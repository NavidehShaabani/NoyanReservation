using System.Data;
using Dapper;
using TowerApi.Models.BuildingFloorElevator;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.BuildingFloorElevator
{
    public class BuildingFloorElevatorRepository : IBuildingFloorElevatorRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BuildingFloorElevatorRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(
            int ResultCode,
            BuildingFloorElevatorViewModel? Data)> AddAsync(
            BuildingFloorElevatorCreateRequest request,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@BuildingFloorId", request.BuildingFloorId);
            parameters.Add("@BuildingElevatorId", request.BuildingElevatorId);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@UserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingFloorElevatorViewModel>(
                "dbo.BuildingFloorElevators_Insert",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                data);
        }

        public async Task<(
            int ResultCode,
            BuildingFloorElevatorViewModel? Data)> EditAsync(
            long id,
            long buildingId,
            bool isActive,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingFloorElevatorId", id);
            parameters.Add("@BuildingId", buildingId);
            parameters.Add("@IsActive", isActive);
            parameters.Add("@UserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingFloorElevatorViewModel>(
                "dbo.BuildingFloorElevators_Update",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                data);
        }

        public async Task<int> DeleteAsync(
            long id,
            long buildingId,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingFloorElevatorId", id);
            parameters.Add("@BuildingId", buildingId);
            parameters.Add("@UserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.BuildingFloorElevators_Delete",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@ResultCode");
        }

        public async Task<(
            int ResultCode,
            BuildingFloorElevatorViewModel? Data)> GetByIdAsync(
            long id,
            long buildingId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingFloorElevatorId", id);
            parameters.Add("@BuildingId", buildingId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingFloorElevatorViewModel>(
                "dbo.BuildingFloorElevators_GetById",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                data);
        }

        public async Task<(
            int ResultCode,
            List<BuildingFloorElevatorViewModel> Data)> GetListAsync(
            BuildingFloorElevatorQueryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@BuildingFloorId", request.BuildingFloorId);
            parameters.Add("@BuildingElevatorId", request.BuildingElevatorId);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            var rows = await connection.QueryAsync<BuildingFloorElevatorViewModel>(
                "dbo.BuildingFloorElevators_Get",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                rows.ToList());
        }

        public async Task<int> SetActiveAsync(
            long id,
            long buildingId,
            bool isActive,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingFloorElevatorId", id);
            parameters.Add("@BuildingId", buildingId);
            parameters.Add("@IsActive", isActive);
            parameters.Add("@UserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.BuildingFloorElevators_Active",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@ResultCode");
        }

        public async Task<int> BulkSaveAsync(
            IEnumerable<BuildingFloorElevatorBulkItem> items,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var table = CreateBulkTable(items);

            var parameters = new DynamicParameters();

            parameters.Add(
                "@Items",
                table.AsTableValuedParameter(
                    "dbo.BuildingFloorElevatorBulkType"));

            parameters.Add("@CurrentUserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.BuildingFloorElevators_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@ResultCode");
        }

        private static DataTable CreateBulkTable(
            IEnumerable<BuildingFloorElevatorBulkItem> items)
        {
            var table = new DataTable();

            table.Columns.Add("BuildingFloorElevatorId", typeof(long));
            table.Columns.Add("BuildingId", typeof(long));
            table.Columns.Add("BuildingFloorId", typeof(long));
            table.Columns.Add("BuildingElevatorId", typeof(long));
            table.Columns.Add("IsActive", typeof(bool));

            foreach (var item in items)
            {
                table.Rows.Add(
                    item.BuildingFloorElevatorId.HasValue
                        ? item.BuildingFloorElevatorId.Value
                        : DBNull.Value,
                    item.BuildingId,
                    item.BuildingFloorId,
                    item.BuildingElevatorId,
                    item.IsActive);
            }

            return table;
        }
    }
}
