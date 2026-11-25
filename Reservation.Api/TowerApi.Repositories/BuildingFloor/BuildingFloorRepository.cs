using System.Data;
using Dapper;
using TowerApi.Models.BuildingFloor;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.BuildingFloor
{
    public class BuildingFloorsRepository : IBuildingFloorsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BuildingFloorsRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        private static DynamicParameters CreateOutputParameters()
        {
            var parameters = new DynamicParameters();

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            return parameters;
        }

        private static (int Code, string? Message) ReadOutput(
            DynamicParameters parameters)
        {
            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string?>("@ResultMessage")
            );
        }

        public async Task<(
            int ResultCode,
            string? ResultMessage,
            IReadOnlyList<BuildingFloorModel> Data
        )> Get(long? buildingId, bool? isActive)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateOutputParameters();

            parameters.Add("@BuildingId", buildingId);
            parameters.Add("@IsActive", isActive);

            var rows = (await connection.QueryAsync<BuildingFloorModel>(
                "BuildingFloors_Get",
                parameters,
                commandType: CommandType.StoredProcedure
            )).ToList();

            var output = ReadOutput(parameters);

            return (output.Code, output.Message, rows);
        }

        public async Task<(
            int ResultCode,
            string? ResultMessage,
            BuildingFloorModel? Data
        )> GetById(long buildingFloorId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateOutputParameters();

            parameters.Add("@BuildingFloorId", buildingFloorId);

            var rows = (await connection.QueryAsync<BuildingFloorModel>(
                "BuildingFloors_GetById",
                parameters,
                commandType: CommandType.StoredProcedure
            )).ToList();

            var output = ReadOutput(parameters);

            return (output.Code, output.Message, rows.FirstOrDefault());
        }

        public async Task<(
            int ResultCode,
            string? ResultMessage,
            BuildingFloorModel? Data
        )> Insert(
            BuildingFloorInsertRequest request,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateOutputParameters();

            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@FloorNumber", request.FloorNumber);
            parameters.Add("@FloorType", request.FloorType);
            parameters.Add("@FloorCode", request.FloorCode);
            parameters.Add("@FloorName", request.FloorName);
            parameters.Add("@FloorNameEn", request.FloorNameEn);
            parameters.Add("@MaxUnits", request.MaxUnits);
            parameters.Add("@UserId", userId);

            var rows = (await connection.QueryAsync<BuildingFloorModel>(
                "BuildingFloors_Insert",
                parameters,
                commandType: CommandType.StoredProcedure
            )).ToList();

            var output = ReadOutput(parameters);

            return (output.Code, output.Message, rows.FirstOrDefault());
        }

        public async Task<(
            int ResultCode,
            string? ResultMessage,
            BuildingFloorModel? Data
        )> Update(
            long buildingFloorId,
            BuildingFloorUpdateRequest request,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateOutputParameters();

            parameters.Add("@BuildingFloorId", buildingFloorId);
            parameters.Add("@FloorType", request.FloorType);
            parameters.Add("@FloorNumber", request.FloorNumber);
            parameters.Add("@FloorCode", request.FloorCode);
            parameters.Add("@FloorName", request.FloorName);
            parameters.Add("@FloorNameEn", request.FloorNameEn);
            parameters.Add("@MaxUnits", request.MaxUnits);
            parameters.Add("@UserId", userId);

            var rows = (await connection.QueryAsync<BuildingFloorModel>(
                "BuildingFloors_Update",
                parameters,
                commandType: CommandType.StoredProcedure
            )).ToList();

            var output = ReadOutput(parameters);

            return (output.Code, output.Message, rows.FirstOrDefault());
        }

        public async Task<(
            int ResultCode,
            string? ResultMessage,
            IReadOnlyList<BuildingFloorModel> Data
        )> BulkSave(
            BuildingFloorBulkSaveRequest request,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateOutputParameters();

            var table = CreateBulkSaveDataTable(request.Items);

            parameters.Add(
                "@Items",
                table.AsTableValuedParameter(
                    "dbo.BuildingFloorBulkSaveType"));

            parameters.Add("@UserId", userId);

            var rows = (await connection.QueryAsync<BuildingFloorModel>(
                "BuildingFloors_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure
            )).ToList();

            var output = ReadOutput(parameters);

            return (output.Code, output.Message, rows);
        }

        private static DataTable CreateBulkSaveDataTable(
            IEnumerable<BuildingFloorBulkSaveItem> items)
        {
            var table = new DataTable();

            // نوع و ترتیب ستون‌ها باید با CREATE TYPE واقعی دیتابیس تطبیق داده شود.
            table.Columns.Add("BuildingFloorId", typeof(long));
            table.Columns.Add("BuildingId", typeof(long));
            table.Columns.Add("FloorNumber", typeof(int));
            table.Columns.Add("FloorCode", typeof(string));
            table.Columns.Add("FloorType", typeof(int));
            table.Columns.Add("FloorName", typeof(string));
            table.Columns.Add("FloorNameEn", typeof(string));
            table.Columns.Add("MaxUnits", typeof(int));
            table.Columns.Add("IsActive", typeof(bool));

            foreach (var item in items)
            {
                table.Rows.Add(
                    item.BuildingFloorId,
                    item.BuildingId,
                    item.FloorNumber,
                    item.FloorCode,
                    item.FloorType,
                    item.FloorName,
                    item.FloorNameEn is null
                        ? DBNull.Value
                        : item.FloorNameEn,
                    item.MaxUnits,
                    item.IsActive
                );
            }

            return table;
        }

        public async Task<(
            int ResultCode,
            string? ResultMessage
        )> Delete(long buildingFloorId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateOutputParameters();

            parameters.Add("@BuildingFloorId", buildingFloorId);

            await connection.ExecuteAsync(
                "BuildingFloors_Delete",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            var output = ReadOutput(parameters);

            return (output.Code, output.Message);
        }

        public async Task<(
            int ResultCode,
            string? ResultMessage
        )> SetActive(
            long buildingFloorId,
            bool isActive,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = CreateOutputParameters();

            parameters.Add("@BuildingFloorId", buildingFloorId);
            parameters.Add("@IsActive", isActive);
            parameters.Add("@UserId", userId);

            await connection.ExecuteAsync(
                "BuildingFloors_SetActive",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            var output = ReadOutput(parameters);

            return (output.Code, output.Message);
        }
    }
}
