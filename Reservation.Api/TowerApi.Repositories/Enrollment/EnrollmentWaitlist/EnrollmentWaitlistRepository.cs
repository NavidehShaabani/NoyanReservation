using Dapper;
using System.Data;
using TowerApi.Models.Enrollment.EnrollmentWaitlist;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Enrollment.EnrollmentWaitlist
{
    public class EnrollmentWaitlistRepository
       : IEnrollmentWaitlistRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public EnrollmentWaitlistRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // دریافت یک مورد از لیست انتظار
        public async Task<EnrollmentWaitlistItem?> GetById(
            long waitlistId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<EnrollmentWaitlistItem>(
                "dbo.Enrollment_Waitlist_GetById",
                new
                {
                    WaitlistId = waitlistId
                },
                commandType: CommandType.StoredProcedure);
        }

        // دریافت فهرست انتظار
        public async Task<IReadOnlyList<EnrollmentWaitlistItem>> GetList(
            EnrollmentWaitlistQuery query)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var result = await connection.QueryAsync<EnrollmentWaitlistItem>(
                "dbo.Enrollment_Waitlist_GetList",
                new
                {
                    query.ClassSessionId,
                    query.ParticipantId,
                    query.WaitlistStatus
                },
                commandType: CommandType.StoredProcedure);

            return result.AsList();
        }

        // عضویت در لیست انتظار
        public async Task<EnrollmentWaitlistItem?> Join(
            EnrollmentWaitlistJoinRequest request,
            int? currentUserId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "ClassSessionId",
                request.ClassSessionId,
                DbType.Int64);

            parameters.Add(
                "ParticipantId",
                request.ParticipantId,
                DbType.Int64);

            parameters.Add(
                "UserId",
                currentUserId,
                DbType.Int32);

            parameters.Add(
                "WaitlistId",
                dbType: DbType.Int64,
                direction: ParameterDirection.Output);

            return await connection.QueryFirstOrDefaultAsync<EnrollmentWaitlistItem>(
                "dbo.Enrollment_Waitlist_Join",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        // تغییر وضعیت عضو لیست انتظار
        public async Task<EnrollmentWaitlistItem?> UpdateStatus(
            long waitlistId,
            EnrollmentWaitlistUpdateStatusRequest request,
            int? currentUserId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<EnrollmentWaitlistItem>(
                "dbo.Enrollment_Waitlist_UpdateStatus",
                new
                {
                    WaitlistId = waitlistId,
                    request.WaitlistStatus,
                    request.OfferedAt,
                    request.ExpiresAt,
                    UserId = currentUserId
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
