using System.Data;
using Dapper;
using TowerApi.Models.Building;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Building
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BuildingRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            BuildingViewModel? Data)> AddAsync(
                BuildingCreateRequest request,
                int? userCreater)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@BuildingName",
                request.BuildingName);

            parameters.Add(
                "@BuildingAddress",
                request.BuildingAddress);

            parameters.Add(
                "@BuildingDescription",
                request.BuildingDescription);

            parameters.Add(
                "@IsActive",
                request.IsActive);

            parameters.Add(
                "@OrgId",
                request.OrgId);

            parameters.Add(
                "@UserCreater",
                userCreater);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingViewModel>(
                "dbo.BuildingsAdd",
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
            BuildingViewModel? Data)> EditAsync(
                long buildingId,
                BuildingUpdateRequest request,
                int? userUpdater)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@BuildingId",
                buildingId);

            parameters.Add(
                "@BuildingName",
                request.BuildingName);

            parameters.Add(
                "@BuildingAddress",
                request.BuildingAddress);

            parameters.Add(
                "@BuildingDescription",
                request.BuildingDescription);

            parameters.Add(
                "@IsActive",
                request.IsActive);

            parameters.Add(
                "@OrgId",
                request.OrgId);

            parameters.Add(
                "@UserUpdater",
                userUpdater);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingViewModel>(
                "dbo.BuildingsEdit",
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
                long buildingId,
                int? userUpdater)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@BuildingId",
                buildingId);

            parameters.Add(
                "@UserUpdater",
                userUpdater);

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
                "dbo.BuildingsDel",
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
            BuildingViewModel? Data)> GetByIdAsync(
                long buildingId,
                bool includeDeleted)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@BuildingId",
                buildingId);

            parameters.Add(
                "@Search",
                null);

            parameters.Add(
                "@PageNumber",
                1);

            parameters.Add(
                "@PageSize",
                1);

            parameters.Add(
                "@IncludeDeleted",
                includeDeleted);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<BuildingViewModel>(
                "dbo.BuildingsGet",
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
            List<BuildingViewModel> Data)> GetListAsync(
                BuildingQueryRequest request)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@BuildingId",
                null);

            parameters.Add(
                "@Search",
                request.Search);

            parameters.Add(
                "@PageNumber",
                request.PageNumber);

            parameters.Add(
                "@PageSize",
                request.PageSize);

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
                (await connection.QueryAsync<BuildingViewModel>(
                    "dbo.BuildingsGet",
                    parameters,
                    commandType: CommandType.StoredProcedure))
                .AsList();

            return (
                parameters.Get<int>("@ResultCode"),
                parameters.Get<string>("@ResultMessage"),
                data
            );
        }
    }
}