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

        public async Task<(int ResultCode, BuildingElevatorViewModel? Data)> AddAsync(
            BuildingElevatorCreateRequest request,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@ElevatorCode", request.ElevatorCode);
            parameters.Add("@ElevatorName", request.ElevatorName);
            parameters.Add("@ElevatorNameEn", request.ElevatorNameEn);
            parameters.Add("@ElevatorType", request.ElevatorType);
            parameters.Add("@Capacity", request.Capacity);
            parameters.Add("@MaxWeight", request.MaxWeight);
            parameters.Add("@IsService", request.IsService);
            parameters.Add("@IsEmergency", request.IsEmergency);
            parameters.Add("@Description", request.Description);
            parameters.Add("@DisplayOrder", request.DisplayOrder);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@UserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingElevatorViewModel>(
                "dbo.BuildingElevators_Insert",
                parameters,
                commandType: CommandType.StoredProcedure);

            var resultCode = parameters.Get<int>("@ResultCode");

            return (resultCode, data);
        }

        public async Task<(int ResultCode, BuildingElevatorViewModel? Data)> EditAsync(
            long id,
            BuildingElevatorUpdateRequest request,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingElevatorId", id);
            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@ElevatorCode", request.ElevatorCode);
            parameters.Add("@ElevatorName", request.ElevatorName);
            parameters.Add("@ElevatorNameEn", request.ElevatorNameEn);
            parameters.Add("@ElevatorType", request.ElevatorType);
            parameters.Add("@Capacity", request.Capacity);
            parameters.Add("@MaxWeight", request.MaxWeight);
            parameters.Add("@IsService", request.IsService);
            parameters.Add("@IsEmergency", request.IsEmergency);
            parameters.Add("@Description", request.Description);
            parameters.Add("@DisplayOrder", request.DisplayOrder);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@UserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingElevatorViewModel>(
                "dbo.BuildingElevators_Update",
                parameters,
                commandType: CommandType.StoredProcedure);

            var resultCode = parameters.Get<int>("@ResultCode");

            return (resultCode, data);
        }

        public async Task<int> DeleteAsync(
            long id,
            long buildingId,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingElevatorId", id);
            parameters.Add("@BuildingId", buildingId);
            parameters.Add("@UserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.BuildingElevators_Delete",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@ResultCode");
        }

        public async Task<(int ResultCode, BuildingElevatorViewModel? Data)> GetByIdAsync(
            long id,
            long buildingId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingElevatorId", id);
            parameters.Add("@BuildingId", buildingId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingElevatorViewModel>(
                "dbo.BuildingElevators_GetById",
                parameters,
                commandType: CommandType.StoredProcedure);

            var resultCode = parameters.Get<int>("@ResultCode");

            return (resultCode, data);
        }

        public async Task<(int ResultCode, List<BuildingElevatorViewModel> Data)> GetListAsync(
            BuildingElevatorQueryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@Search", request.Search);
            parameters.Add("@ElevatorType", request.ElevatorType);
            parameters.Add("@IsService", request.IsService);
            parameters.Add("@IsEmergency", request.IsEmergency);
            parameters.Add("@IsActive", request.IsActive);
            parameters.Add("@IncludeDeleted", request.IncludeDeleted);
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            var rows = await connection.QueryAsync<BuildingElevatorViewModel>(
                "dbo.BuildingElevators_Get",
                parameters,
                commandType: CommandType.StoredProcedure);

            var resultCode = parameters.Get<int>("@ResultCode");

            return (resultCode, rows.ToList());
        }

        public async Task<int> SetActiveAsync(
            long id,
            long buildingId,
            bool isActive,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingElevatorId", id);
            parameters.Add("@BuildingId", buildingId);
            parameters.Add("@IsActive", isActive);
            parameters.Add("@UserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.BuildingElevators_Active",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@ResultCode");
        }

        public async Task<int> BulkSaveAsync(
            IEnumerable<BuildingElevatorBulkItem> items,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var table = CreateBulkTable(items);

            var parameters = new DynamicParameters();

            parameters.Add(
                "@Items",
                table.AsTableValuedParameter("dbo.BuildingElevatorBulkType"));

            parameters.Add("@CurrentUserId", userId);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.BuildingElevators_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@ResultCode");
        }

        private static DataTable CreateBulkTable(
            IEnumerable<BuildingElevatorBulkItem> items)
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
                    item.BuildingElevatorId.HasValue
                        ? item.BuildingElevatorId.Value
                        : DBNull.Value,
                    item.BuildingId,
                    item.ElevatorCode,
                    item.ElevatorName,
                    item.ElevatorNameEn is null
                        ? DBNull.Value
                        : item.ElevatorNameEn,
                    item.ElevatorType,
                    item.Capacity.HasValue
                        ? item.Capacity.Value
                        : DBNull.Value,
                    item.MaxWeight.HasValue
                        ? item.MaxWeight.Value
                        : DBNull.Value,
                    item.IsService,
                    item.IsEmergency,
                    item.Description is null
                        ? DBNull.Value
                        : item.Description,
                    item.DisplayOrder,
                    item.IsActive);
            }

            return table;
        }
    }
}
