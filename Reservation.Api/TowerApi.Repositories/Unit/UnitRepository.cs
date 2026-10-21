using System.Data;
using Dapper;
using TowerApi.Models.Unit;
using TowerApi.Repositories.DataBase;


namespace TowerApi.Repositories.Unit
{
    public class UnitRepository : IUnitRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UnitRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            UnitViewModel? Data)> AddAsync(
                UnitCreateRequest request,
                int? userCreater)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@UnitNumber", request.UnitNumber);
            parameters.Add("@FloorNumber", request.FloorNumber);
            parameters.Add("@Area", request.Area);
            parameters.Add("@Bedrooms", request.Bedrooms);
            parameters.Add(
                "@UnitDescription",
                request.UnitDescription);
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

            var data =
                await connection.QueryFirstOrDefaultAsync<UnitViewModel>(
                    "dbo.UnitsAdd",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage"),
                data
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            UnitViewModel? Data)> EditAsync(
                long unitId,
                UnitUpdateRequest request,
                int? userUpdater)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@UnitId", unitId);
            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@UnitNumber", request.UnitNumber);
            parameters.Add("@FloorNumber", request.FloorNumber);
            parameters.Add("@Area", request.Area);
            parameters.Add("@Bedrooms", request.Bedrooms);
            parameters.Add(
                "@UnitDescription",
                request.UnitDescription);
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

            var data =
                await connection.QueryFirstOrDefaultAsync<UnitViewModel>(
                    "dbo.UnitsEdit",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage"),
                data
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage)> DeleteAsync(
                long unitId,
                int? userUpdater)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@UnitId", unitId);
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
                "dbo.UnitsDel",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage")
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            UnitViewModel? Data)> GetByIdAsync(
                long unitId,
                bool includeDeleted)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@UnitId", unitId);
            parameters.Add("@BuildingId", null);
            parameters.Add("@Search", null);
            parameters.Add("@FloorNumber", null);
            parameters.Add("@PageNumber", 1);
            parameters.Add("@PageSize", 1);
            parameters.Add("@IncludeDeleted", includeDeleted);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data =
                await connection.QueryFirstOrDefaultAsync<UnitViewModel>(
                    "dbo.UnitsGet",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage"),
                data
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            List<UnitViewModel> Data)> GetListAsync(
                UnitQueryRequest request)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@UnitId", null);
            parameters.Add("@BuildingId", request.BuildingId);
            parameters.Add("@Search", request.Search);
            parameters.Add("@FloorNumber", request.FloorNumber);
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            parameters.Add(
                "@IncludeDeleted",
                request.IncludeDeleted);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data =
                (await connection.QueryAsync<UnitViewModel>(
                    "dbo.UnitsGet",
                    parameters,
                    commandType: CommandType.StoredProcedure))
                .AsList();

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage"),
                data
            );
        }
        public async Task<(int ResultCode, string? ResultMessage)>
           BulkSaveAsync(
               IEnumerable<UnitBulkItem> units,
               long currentUserId)
        {
            var table = new DataTable();

            // ترتیب و نوع ستون‌ها باید با dbo.UnitBulkType یکسان باشد.
            table.Columns.Add("UnitId", typeof(long));
            table.Columns.Add("BuildingId", typeof(long));
            table.Columns.Add("UnitNumber", typeof(string));
            table.Columns.Add("FloorNumber", typeof(int));
            table.Columns.Add("Area", typeof(decimal));
            table.Columns.Add("Bedrooms", typeof(byte));
            table.Columns.Add("UnitDescription", typeof(string));
            table.Columns.Add("IsActive", typeof(bool));

            foreach (var unit in units)
            {
                table.Rows.Add(
                    unit.UnitId.HasValue
                        ? unit.UnitId.Value
                        : DBNull.Value,

                    unit.BuildingId.HasValue
                        ? unit.BuildingId.Value
                        : DBNull.Value,

                    (object?)unit.UnitNumber ?? DBNull.Value,

                    unit.FloorNumber.HasValue
                        ? unit.FloorNumber.Value
                        : DBNull.Value,

                    unit.Area.HasValue
                        ? unit.Area.Value
                        : DBNull.Value,

                    unit.Bedrooms.HasValue
                        ? unit.Bedrooms.Value
                        : DBNull.Value,

                    (object?)unit.UnitDescription ?? DBNull.Value,

                    unit.IsActive.HasValue
                        ? unit.IsActive.Value
                        : DBNull.Value
                );
            }

            var parameters = new DynamicParameters();

            parameters.Add(
                "@Units",
                table.AsTableValuedParameter("dbo.UnitBulkType"));

            parameters.Add(
                "@CurrentUserId",
                currentUserId,
                DbType.Int64);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                "dbo.Units_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure);

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string?>("@ResultMessage")
            );
        }
    }
}