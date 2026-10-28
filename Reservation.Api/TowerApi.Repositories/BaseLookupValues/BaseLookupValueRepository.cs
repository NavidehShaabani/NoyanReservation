using System.Data;
using Dapper;
using TowerApi.Models.BaseLookupValues;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.BaseLookupValues
{
    public sealed class BaseLookupValueRepository
        : IBaseLookupValueRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BaseLookupValueRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<BaseLookupValueResult<IEnumerable<dynamic>>>
            GetAsync(CancellationToken cancellationToken = default)
        {
            using var connection = _connectionFactory.CreateConnection();

            var command = new CommandDefinition(
                commandText: "dbo.Base_LookupValues_Get",
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken);

            var rows = await connection.QueryAsync(command);

            return new BaseLookupValueResult<IEnumerable<dynamic>>
            {
                ResultCode = 200,
                ResultMessage = "Common.GetSuccessfully",
                Data = rows
            };
        }

        public async Task<BaseLookupValueResult<dynamic>>
            GetByIdAsync(
                int lookupValueId,
                CancellationToken cancellationToken = default)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@LookupValueId",
                lookupValueId,
                DbType.Int32,
                ParameterDirection.Input);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var command = new CommandDefinition(
                commandText: "dbo.Base_LookupValues_GetById",
                parameters: parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken);

            // ابتدا نتیجه Query خوانده می‌شود تا پروسیجر کامل اجرا شود.
            var item = await connection.QueryFirstOrDefaultAsync(
                command);

            var resultCode = parameters.Get<int>("@ResultCode");
            var resultMessage =
                parameters.Get<string>("@ResultMessage") ?? string.Empty;

            return new BaseLookupValueResult<dynamic>
            {
                ResultCode = resultCode,
                ResultMessage = resultMessage,
                Data = resultCode == 200 ? item : null
            };
        }
    }
}
