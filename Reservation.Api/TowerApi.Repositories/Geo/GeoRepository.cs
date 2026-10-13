using Dapper;
using System.Data;
using TowerApi.Models.Geo;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Geo
{
    public class GeoRepository : IGeoRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public GeoRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            List<GeoItemResponse> Data
        )> GetChildrenAsync(
            GeoChildrenQueryRequest request)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@GeoType",
                request.GeoType,
                DbType.Byte);

            parameters.Add(
                "@ParentGeoId",
                request.ParentGeoId,
                DbType.String,
                size: 10);

            parameters.Add(
                "@Search",
                request.Search,
                DbType.String,
                size: 300);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data = (
                await connection.QueryAsync<GeoItemResponse>(
                    "dbo.Base_GeoGetChildren",
                    parameters,
                    commandType: CommandType.StoredProcedure)
            ).ToList();

            var resultCode =
                parameters.Get<int>("@ResultCode");

            var resultMessage =
                parameters.Get<string>("@ResultMessage")
                ?? string.Empty;

            return (
                resultCode,
                resultMessage,
                data);
        }
    }
}
