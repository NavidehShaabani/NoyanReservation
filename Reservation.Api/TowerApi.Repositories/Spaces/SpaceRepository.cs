using System.Data;
using Dapper;
using TowerApi.Models.Spaces;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Spaces
{
    public sealed class SpaceRepository : ISpaceRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public SpaceRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<SpaceOperationResult<IReadOnlyList<SpaceQueryResult>>> GetAsync(
            SpaceQueryRequest filter,
            CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@OrgId", filter.OrgId, DbType.Int64);
            parameters.Add("@BuildingId", filter.BuildingId, DbType.Int64);
            parameters.Add("@SpaceType", filter.SpaceType, DbType.Int32);
            parameters.Add("@IsActive", filter.IsActive, DbType.Boolean);

            AddOutputParameters(parameters);

            var command = new CommandDefinition(
                "dbo.Spaces_Get",
                parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken);

            var rows = (await connection.QueryAsync<SpaceQueryResult>(command)).AsList();

            return new SpaceOperationResult<IReadOnlyList<SpaceQueryResult>>
            {
                ResultCode = parameters.Get<int>("@ResultCode"),
                ResultMessage = parameters.Get<string>("@ResultMessage") ?? string.Empty,
                Data = rows
            };
        }

        public async Task<SpaceOperationResult<SpaceQueryResult>> GetByIdAsync(
            long spaceId,
            CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@SpaceId", spaceId, DbType.Int64);

            AddOutputParameters(parameters);

            var command = new CommandDefinition(
                "dbo.Spaces_GetById",
                parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken);

            using var grid = await connection.QueryMultipleAsync(command);

            var item = await grid.ReadFirstOrDefaultAsync<SpaceQueryResult>();

            return new SpaceOperationResult<SpaceQueryResult>
            {
                ResultCode = parameters.Get<int>("@ResultCode"),
                ResultMessage = parameters.Get<string>("@ResultMessage") ?? string.Empty,
                Data = item
            };
        }

        public async Task<SpaceOperationResult<long>> InsertAsync(
            SpaceSave model,
            long? currentUserId,
            CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            AddSpaceParameters(parameters, model);

            parameters.Add("@CurrentUserId", currentUserId, DbType.Int64);
            parameters.Add("@SpaceId", dbType: DbType.Int64, direction: ParameterDirection.Output);

            AddOutputParameters(parameters);

            var command = new CommandDefinition(
                "dbo.Spaces_Insert",
                parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken);

            await connection.ExecuteAsync(command);

            return new SpaceOperationResult<long>
            {
                ResultCode = parameters.Get<int>("@ResultCode"),
                ResultMessage = parameters.Get<string>("@ResultMessage") ?? string.Empty,
                Data = parameters.Get<long?>("@SpaceId") ?? 0
            };
        }

        public async Task<SpaceOperationResult<bool>> UpdateAsync(
            long spaceId,
            SpaceSave model,
            long? currentUserId,
            CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@SpaceId", spaceId, DbType.Int64);
            AddSpaceParameters(parameters, model);

            parameters.Add("@CurrentUserId", currentUserId, DbType.Int64);
            AddOutputParameters(parameters);

            var command = new CommandDefinition(
                "dbo.Spaces_Update",
                parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken);

            await connection.ExecuteAsync(command);

            return new SpaceOperationResult<bool>
            {
                ResultCode = parameters.Get<int>("@ResultCode"),
                ResultMessage = parameters.Get<string>("@ResultMessage") ?? string.Empty,
                Data = parameters.Get<int>("@ResultCode") == 200
            };
        }

        public async Task<SpaceOperationResult<bool>> BulkSaveAsync(
            SpaceBulkSave model,
            long? currentUserId,
            CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            var table = CreateBulkDataTable(model.Spaces);

            var parameters = new DynamicParameters();

            parameters.Add(
                "@Spaces",
                table.AsTableValuedParameter("dbo.SpaceBulkType"));

            parameters.Add("@CurrentUserId", currentUserId, DbType.Int64);
            AddOutputParameters(parameters);

            var command = new CommandDefinition(
                "dbo.Spaces_BulkSave",
                parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken);

            await connection.ExecuteAsync(command);

            return new SpaceOperationResult<bool>
            {
                ResultCode = parameters.Get<int>("@ResultCode"),
                ResultMessage = parameters.Get<string>("@ResultMessage") ?? string.Empty,
                Data = parameters.Get<int>("@ResultCode") == 200
            };
        }

        public async Task<SpaceOperationResult<bool>> DeleteAsync(
            long spaceId,
            long? currentUserId,
            CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@SpaceId", spaceId, DbType.Int64);
            parameters.Add("@CurrentUserId", currentUserId, DbType.Int64);

            AddOutputParameters(parameters);

            var command = new CommandDefinition(
                "dbo.Spaces_Delete",
                parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken);

            await connection.ExecuteAsync(command);

            return new SpaceOperationResult<bool>
            {
                ResultCode = parameters.Get<int>("@ResultCode"),
                ResultMessage = parameters.Get<string>("@ResultMessage") ?? string.Empty,
                Data = parameters.Get<int>("@ResultCode") == 200
            };
        }

        public async Task<SpaceOperationResult<bool>> SetActiveAsync(
            long spaceId,
            bool isActive,
            long? currentUserId,
            CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@SpaceId", spaceId, DbType.Int64);
            parameters.Add("@IsActive", isActive, DbType.Boolean);
            parameters.Add("@CurrentUserId", currentUserId, DbType.Int64);

            AddOutputParameters(parameters);

            var command = new CommandDefinition(
                "dbo.Spaces_SetActive",
                parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken);

            await connection.ExecuteAsync(command);

            return new SpaceOperationResult<bool>
            {
                ResultCode = parameters.Get<int>("@ResultCode"),
                ResultMessage = parameters.Get<string>("@ResultMessage") ?? string.Empty,
                Data = parameters.Get<int>("@ResultCode") == 200
            };
        }

        private static void AddOutputParameters(DynamicParameters parameters)
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

        private static void AddSpaceParameters(
            DynamicParameters parameters,
            SpaceSave model)
        {
            parameters.Add("@OrgId", model.OrgId, DbType.Int64);
            parameters.Add("@BuildingId", model.BuildingId, DbType.Int64);
            parameters.Add("@ParentSpaceId", model.ParentSpaceId, DbType.Int64);

            parameters.Add("@SpaceName", model.SpaceName.Trim(), DbType.String);
            parameters.Add(
                "@SpaceNameEn",
                string.IsNullOrWhiteSpace(model.SpaceNameEn)
                    ? null
                    : model.SpaceNameEn.Trim(),
                DbType.String);

            parameters.Add("@SpaceType", model.SpaceType, DbType.Int32);
            parameters.Add("@Capacity", model.Capacity, DbType.Int32);
            parameters.Add("@Area", model.Area, DbType.Decimal);

            parameters.Add("@SpaceDesc", model.SpaceDesc, DbType.String);
            parameters.Add("@SpaceDescEn", model.SpaceDescEn, DbType.String);

            parameters.Add("@IsReservable", model.IsReservable, DbType.Boolean);
            parameters.Add("@IsActive", model.IsActive, DbType.Boolean);
        }

        private static DataTable CreateBulkDataTable(
            IReadOnlyCollection<SpaceBulkItem> spaces)
        {
            var table = new DataTable();

            // ترتیب و نوع ستون‌ها باید با dbo.SpaceBulkType یکسان باشد.
            table.Columns.Add("SpaceId", typeof(long));
            table.Columns.Add("OrgId", typeof(long));
            table.Columns.Add("BuildingId", typeof(long));
            table.Columns.Add("ParentSpaceId", typeof(long));
            table.Columns.Add("SpaceName", typeof(string));
            table.Columns.Add("SpaceNameEn", typeof(string));
            table.Columns.Add("SpaceType", typeof(int));
            table.Columns.Add("Capacity", typeof(int));
            table.Columns.Add("Area", typeof(decimal));
            table.Columns.Add("SpaceDesc", typeof(string));
            table.Columns.Add("SpaceDescEn", typeof(string));
            table.Columns.Add("IsReservable", typeof(bool));
            table.Columns.Add("IsActive", typeof(bool));

            foreach (var item in spaces)
            {
                table.Rows.Add(
                    DbValue(item.SpaceId.GetValueOrDefault() <= 0
                        ? null
                        : item.SpaceId),
                    DbValue(item.OrgId),
                    DbValue(item.BuildingId),
                    DbValue(item.ParentSpaceId),
                    item.SpaceName.Trim(),
                    DbValue(NullIfWhiteSpace(item.SpaceNameEn)),
                    DbValue(item.SpaceType),
                    DbValue(item.Capacity),
                    DbValue(item.Area),
                    DbValue(item.SpaceDesc),
                    DbValue(item.SpaceDescEn),
                    DbValue(item.IsReservable),
                    DbValue(item.IsActive));
            }

            return table;
        }

        private static object DbValue(object? value) => value ?? DBNull.Value;

        private static string? NullIfWhiteSpace(string? value) =>
            string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }
}
