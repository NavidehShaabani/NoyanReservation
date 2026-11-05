using System.Data;
using Dapper;
using TowerApi.Models.BuildingStaircaseElevators;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.BuildingStaircaseElevators
{
    public class BuildingStaircaseElevatorRepository
    : IBuildingStaircaseElevatorRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BuildingStaircaseElevatorRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(
            int ResultCode,
            BuildingStaircaseElevatorViewModel? Data)> AddAsync(
            BuildingStaircaseElevatorCreateRequest request,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@BuildingStaircaseId", request.BuildingStaircaseId);
            parameters.Add("@BuildingElevatorId", request.BuildingElevatorId);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@UserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            var data =
                await connection.QueryFirstOrDefaultAsync<BuildingStaircaseElevatorViewModel>(
                    "dbo.BuildingStaircaseElevators_Insert",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                data);
        }

        public async Task<(
            int ResultCode,
            BuildingStaircaseElevatorViewModel? Data)> EditAsync(
            long id,
            long buildingId,
            bool isActive,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingStaircaseElevatorId", id);
            parameters.Add("@BuildingId", buildingId);
            parameters.Add("@IsActive", isActive);
            parameters.Add("@UserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            var data =
                await connection.QueryFirstOrDefaultAsync<BuildingStaircaseElevatorViewModel>(
                    "dbo.BuildingStaircaseElevators_Update",
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

            parameters.Add("@BuildingStaircaseElevatorId", id);
            parameters.Add("@BuildingId", buildingId);
            parameters.Add("@UserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.BuildingStaircaseElevators_Delete",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@ResultCode");
        }

        public async Task<(
            int ResultCode,
            BuildingStaircaseElevatorViewModel? Data)> GetByIdAsync(
            long id,
            long buildingId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingStaircaseElevatorId", id);
            parameters.Add("@BuildingId", buildingId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            var data =
                await connection.QueryFirstOrDefaultAsync<BuildingStaircaseElevatorViewModel>(
                    "dbo.BuildingStaircaseElevators_GetById",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                data);
        }

        public async Task<(
            int ResultCode,
            List<BuildingStaircaseElevatorViewModel> Data)> GetListAsync(
            BuildingStaircaseElevatorQueryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@BuildingStaircaseId", request.BuildingStaircaseId);
            parameters.Add("@BuildingElevatorId", request.BuildingElevatorId);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            var rows =
                await connection.QueryAsync<BuildingStaircaseElevatorViewModel>(
                    "dbo.BuildingStaircaseElevators_Get",
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

            parameters.Add("@BuildingStaircaseElevatorId", id);
            parameters.Add("@BuildingId", buildingId);
            parameters.Add("@IsActive", isActive);
            parameters.Add("@UserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.BuildingStaircaseElevators_Active",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@ResultCode");
        }

        public async Task<int> BulkSaveAsync(
            IEnumerable<BuildingStaircaseElevatorBulkItem> items,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var table = CreateBulkTable(items);

            var parameters = new DynamicParameters();

            parameters.Add(
                "@Items",
                table.AsTableValuedParameter(
                    "dbo.BuildingStaircaseElevatorBulkType"));

            parameters.Add("@CurrentUserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.BuildingStaircaseElevators_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@ResultCode");
        }

        private static DataTable CreateBulkTable(
            IEnumerable<BuildingStaircaseElevatorBulkItem> items)
        {
            var table = new DataTable();

            table.Columns.Add("BuildingStaircaseElevatorId", typeof(long));
            table.Columns.Add("BuildingId", typeof(long));
            table.Columns.Add("BuildingStaircaseId", typeof(long));
            table.Columns.Add("BuildingElevatorId", typeof(long));
            table.Columns.Add("IsActive", typeof(bool));

            foreach (var item in items)
            {
                table.Rows.Add(
                    item.BuildingStaircaseElevatorId.HasValue
                        ? item.BuildingStaircaseElevatorId.Value
                        : DBNull.Value,
                    item.BuildingId,
                    item.BuildingStaircaseId,
                    item.BuildingElevatorId,
                    item.IsActive);
            }

            return table;
        }
    }
}
