
using Dapper;
using System.Data;
using TowerApi.Models.Auth;
using TowerApi.Models.Common;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.SessionRepository
{
    public class UserSessionRepository : IUserSessionRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UserSessionRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<UserSessionEntity?> CreateAsync(
            UserSessionEntity session)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@SessionId",
                session.SessionId,
                DbType.Guid);

            parameters.Add(
                "@UserId",
                session.UserId,
                DbType.Int64);

            parameters.Add(
                "@ActiveRoleId",
                session.ActiveRoleId,
                DbType.Int64);

            parameters.Add(
                "@DeviceName",
                session.DeviceName,
                DbType.String);

            parameters.Add(
                "@UserAgent",
                session.UserAgent,
                DbType.String);

            parameters.Add(
                "@CreatedIp",
                session.CreatedIp,
                DbType.String);

            return await connection.QueryFirstOrDefaultAsync<UserSessionEntity>(
                "dbo.App_UserSessionCreate",
                parameters,
                commandType: CommandType.StoredProcedure);
        }


        public async Task<UserSessionEntity?> GetByIdAsync(
            Guid sessionId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@SessionId",
                sessionId,
                DbType.Guid);

            return await connection.QueryFirstOrDefaultAsync<UserSessionEntity>(
                "dbo.App_UserSessionGet",
                parameters,
                commandType: CommandType.StoredProcedure);
        }


        public async Task<bool> SetActiveRoleAsync(
            Guid sessionId,
            long userId,
            long roleId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@SessionId",
                sessionId,
                DbType.Guid);

            parameters.Add(
                "@UserId",
                userId,
                DbType.Int64);

            parameters.Add(
                "@RoleId",
                roleId,
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

            await connection.ExecuteAsync(
                "dbo.App_UserSessionSetActiveRole",
                parameters,
                commandType: CommandType.StoredProcedure);

            var resultCode =
                parameters.Get<int>("@ResultCode");

            return resultCode == 200;
        }


        public async Task UpdateLastSeenAsync(
            Guid sessionId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@SessionId",
                sessionId,
                DbType.Guid);

            await connection.ExecuteAsync(
                "dbo.App_UserSessionUpdateLastSeen",
                parameters,
                commandType: CommandType.StoredProcedure);
        }


        public async Task RevokeAsync(
            Guid sessionId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@SessionId",
                sessionId,
                DbType.Guid);

            await connection.ExecuteAsync(
                "dbo.App_UserSessionRevoke",
                parameters,
                commandType: CommandType.StoredProcedure);
        }


        public async Task RevokeAllAsync(
            long userId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@UserId",
                userId,
                DbType.Int64);

            await connection.ExecuteAsync(
                "dbo.App_UserSessionRevokeAll",
                parameters,
                commandType: CommandType.StoredProcedure);
        }


        public async Task<List<UserSessionEntity>> GetActiveAsync(
            long userId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@UserId",
                userId,
                DbType.Int64);

            var result =
                await connection.QueryAsync<UserSessionEntity>(
                    "dbo.App_UserSessionGetActive",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public async Task<ProcedureResult> ClearActiveRoleAsync(
    Guid sessionId,
    long userId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@SessionId",
                sessionId,
                DbType.Guid);

            parameters.Add(
                "@UserId",
                userId,
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

            await connection.ExecuteAsync(
                "dbo.App_UserSessionClearActiveRole",
                parameters,
                commandType: CommandType.StoredProcedure);

            return new ProcedureResult
            {
                ResultCode =
                    parameters.Get<int>(
                        "@ResultCode"),

                ResultMessage =
                    parameters.Get<string>(
                        "@ResultMessage") ?? string.Empty
            };
        }
        public async Task<SessionAuthorization?>
    GetAuthorizationAsync(
        Guid sessionId,
        long userId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters =
                new DynamicParameters();

            parameters.Add(
                "@SessionId",
                sessionId,
                DbType.Guid);

            parameters.Add(
                "@UserId",
                userId,
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

            var result =
                await connection.QueryFirstOrDefaultAsync<SessionAuthorization>(
                    "dbo.App_UserSessionAuthorizationGet",
                    parameters,
                    commandType:
                        CommandType.StoredProcedure);

            return result;
        }
    }

}
