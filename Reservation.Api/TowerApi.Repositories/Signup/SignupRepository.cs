using System.Data;
using Dapper;
using TowerApi.Models.Signup;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Signup
{
    public class SignupRepository : ISignupRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public SignupRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<SignupDbResult<SignupWithPasswordData>>
            SignupWithPasswordAsync(
                string username,
                string passwordHash,
                string orgName,
                int orgType,
                string geoId,
                string? requestIp)
        {
            using var connection = _connectionFactory.CreateConnection();

            var p = new DynamicParameters();

            p.Add("@Username", username, DbType.String, size: 100);
            p.Add("@PasswordHash", passwordHash, DbType.String, size: 500);
            p.Add("@OrgName", orgName, DbType.String, size: 200);
            p.Add("@OrgType", orgType, DbType.Int32);
            p.Add("@GeoId", geoId, DbType.String, size: 10);
            p.Add("@RequestIp", requestIp, DbType.String, size: 50);

            p.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            p.Add("@ResultMessage", dbType: DbType.String,
                size: 500, direction: ParameterDirection.Output);

            p.Add("@UserId", dbType: DbType.Int64,
                direction: ParameterDirection.Output);

            p.Add("@OrgId", dbType: DbType.Int64,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<SignupWithPasswordData>(
                "dbo.App_UsersSignupWithPassword",
                p,
                commandType: CommandType.StoredProcedure);

            return new SignupDbResult<SignupWithPasswordData>
            {
                Code = p.Get<int>("@ResultCode"),
                Message = p.Get<string>("@ResultMessage") ?? string.Empty,
                UserId = p.Get<long?>("@UserId"),
                OrgId = p.Get<long?>("@OrgId"),
                Data = data
            };
        }

        public async Task<SignupDbResult<SignupStartOtpData>>
            StartOtpAsync(
                string mobile,
                string orgName,
                int orgType,
                string geoId,
                string? requestIp,
                string? userAgent)
        {
            using var connection = _connectionFactory.CreateConnection();

            var p = new DynamicParameters();

            p.Add("@Mobile", mobile, DbType.String, size: 30);
            p.Add("@OrgName", orgName, DbType.String, size: 200);
            p.Add("@OrgType", orgType, DbType.Int32);
            p.Add("@GeoId", geoId, DbType.String, size: 10);
            p.Add("@RequestIp", requestIp, DbType.String, size: 50);
            p.Add("@UserAgent", userAgent, DbType.String, size: 500);

            p.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            p.Add("@ResultMessage", dbType: DbType.String,
                size: 500, direction: ParameterDirection.Output);

            p.Add("@UserId", dbType: DbType.Int64,
                direction: ParameterDirection.Output);

            p.Add("@OtpRequestId", dbType: DbType.Int64,
                direction: ParameterDirection.Output);

            p.Add("@OtpExpiresAt", dbType: DbType.DateTime2,
                direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "dbo.App_UsersSignupStartOtp",
                p,
                commandType: CommandType.StoredProcedure);

            return new SignupDbResult<SignupStartOtpData>
            {
                Code = p.Get<int>("@ResultCode"),
                Message = p.Get<string>("@ResultMessage") ?? string.Empty,
                UserId = p.Get<long?>("@UserId"),
                OtpRequestId = p.Get<long?>("@OtpRequestId"),
                OtpExpiresAt = p.Get<DateTime?>("@OtpExpiresAt"),
                Data = new SignupStartOtpData
                {
                    UserId = p.Get<long?>("@UserId") ?? 0,
                    OtpRequestId = p.Get<long?>("@OtpRequestId") ?? 0,
                    OtpExpiresAt = p.Get<DateTime?>("@OtpExpiresAt") ?? default
                }
            };
        }

        public async Task<SignupDbResult<SignupVerifyOtpData>>
            VerifyOtpAsync(
                long userId,
                long otpRequestId,
                string otpCode)
        {
            using var connection = _connectionFactory.CreateConnection();

            var p = new DynamicParameters();

            p.Add("@UserId", userId, DbType.Int64);
            p.Add("@OtpRequestId", otpRequestId, DbType.Int64);
            p.Add("@OtpCode", otpCode, DbType.String, size: 10);

            p.Add("@ResultCode", dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            p.Add("@ResultMessage", dbType: DbType.String,
                size: 500, direction: ParameterDirection.Output);

            p.Add("@OrgId", dbType: DbType.Int64,
                direction: ParameterDirection.Output);

            var data = await connection.QueryFirstOrDefaultAsync<SignupVerifyOtpData>(
                "dbo.App_UsersSignupVerifyOtp",
                p,
                commandType: CommandType.StoredProcedure);

            return new SignupDbResult<SignupVerifyOtpData>
            {
                Code = p.Get<int>("@ResultCode"),
                Message = p.Get<string>("@ResultMessage") ?? string.Empty,
                UserId = data?.UserId ?? userId,
                OrgId = p.Get<long?>("@OrgId"),
                Data = data
            };
        }
    }
}
