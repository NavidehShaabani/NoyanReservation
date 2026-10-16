using System.Data;
using Dapper;
using TowerApi.Models.Registration;
using TowerApi.Models.Registration.TowerApi.Models.Registration;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Registration
{
    public class RegistrationRepository: IRegistrationRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public RegistrationRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<RegistrationResult> SignupAsync(
            MobileSignupRequest request,
            string? passwordHash,
            string? requestIp,
            string? userAgent)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@Mobile",
                request.Mobile,
                DbType.String,
                size: 30);

            parameters.Add(
                "@Username",
                request is UsernameSignupRequest usernameRequest
                    ? usernameRequest.Username
                    : null,
                DbType.String,
                size: 100);

            parameters.Add(
                "@PasswordHash",
                passwordHash,
                DbType.String,
                size: 500);

            parameters.Add(
                "@FirstName",
                request.FirstName,
                DbType.String,
                size: 100);

            parameters.Add(
                "@LastName",
                request.LastName,
                DbType.String,
                size: 100);

            parameters.Add(
                "@Gender",
                request.Gender,
                DbType.Int32);

            parameters.Add(
                "@Email",
                request.Email,
                DbType.String,
                size: 150);

            parameters.Add(
                "@NationalId",
                request.NationalId,
                DbType.String,
                size: 10);

            parameters.Add(
                "@BirthDate",
                request.BirthDate,
                DbType.DateTime);

            // نقش از کلاینت دریافت نمی‌شود.
            parameters.Add(
                "@RoleId",
                null,
                DbType.Int64);

            parameters.Add(
                "@RequestIp",
                requestIp,
                DbType.String,
                size: 50);

            parameters.Add(
                "@UserAgent",
                userAgent,
                DbType.String,
                size: 500);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@UserId",
                dbType: DbType.Int64,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@OtpRequestId",
                dbType: DbType.Int64,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@OtpCode",
                dbType: DbType.AnsiString,
                size: 6,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@OrgName",
                request.OrgName,
                DbType.String,
                size: 200);

            parameters.Add(
                "@OrgType",
                request.OrgType,
                DbType.Int32);

            parameters.Add(
                "@GeoId",
                request.GeoId,
                DbType.String,
                size: 10);

            DateTime? otpExpiresAt = null;

            // پروسیجر علاوه بر OUTPUT یک result set هم برمی‌گرداند.
            using (var multi = await connection.QueryMultipleAsync(
                "dbo.App_UsersSignup",
                parameters,
                commandType: CommandType.StoredProcedure))
            {
                var row = await multi.ReadFirstOrDefaultAsync<OtpSignupRow>();

                otpExpiresAt = row?.OtpExpiresAt;
            }

            // پارامترهای OUTPUT پس از بسته‌شدن DataReader خوانده می‌شوند.
            return new RegistrationResult
            {
                ResultCode =
                    parameters.Get<int>("@ResultCode"),

                ResultMessage =
                    parameters.Get<string>("@ResultMessage")
                    ?? string.Empty,

                UserId =
                    parameters.Get<long?>("@UserId"),

                OtpRequestId =
                    parameters.Get<long?>("@OtpRequestId"),

                OtpCode =
                    parameters.Get<string>("@OtpCode"),

                OtpExpiresAt = otpExpiresAt
            };
        }

        private sealed class OtpSignupRow
        {
            public long? UserId { get; set; }

            public long? OtpRequestId { get; set; }

            public string? OtpCode { get; set; }

            public DateTime? OtpExpiresAt { get; set; }
        }
    }
}
