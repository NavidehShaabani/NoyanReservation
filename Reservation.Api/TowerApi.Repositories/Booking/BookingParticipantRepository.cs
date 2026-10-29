using System.Data;
using System.Data.SqlClient;
using Dapper;
using TowerApi.Models.Booking;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Booking
{
    public sealed class BookingParticipantRepository
     : IBookingParticipantRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BookingParticipantRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            BookingParticipantViewModel? Data
        )> GetByIdAsync(long participantId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var data =
                await connection.QueryFirstOrDefaultAsync<BookingParticipantViewModel>(
                    "dbo.Booking_Participant_GetById",
                    new { ParticipantId = participantId },
                    commandType: CommandType.StoredProcedure);

            return data is null
                ? (404, "Common.NotFound", null)
                : (200, "Common.GetSuccessfully", data);
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            List<BookingParticipantViewModel> Data
        )> GetActiveListAsync(byte? participantType, long? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var data = (await connection.QueryAsync<BookingParticipantViewModel>(
                "dbo.Booking_Participant_GetActiveList",
                new
                {
                    ParticipantType = participantType,
                    UserId = userId
                },
                commandType: CommandType.StoredProcedure)).AsList();

            return (200, "Common.GetSuccessfully", data);
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            BookingParticipantViewModel? Data
        )> SaveAsync(
            BookingParticipantSaveRequest request,
            long? ownerUserId,
            int? auditUserId)
        {
            using var connection = _connectionFactory.CreateConnection();

            try
            {
                var data =
                    await connection.QueryFirstOrDefaultAsync<BookingParticipantViewModel>(
                        "dbo.Booking_Participant_Save",
                        new
                        {
                            request.ParticipantId,
                            UserId = ownerUserId,
                            request.FullName,
                            request.MobileNumber,
                            request.Email,
                            request.ParticipantType,
                            request.IsActive,
                            AuditUserId = auditUserId
                        },
                        commandType: CommandType.StoredProcedure);

                return data is null
                    ? (500, "Common.SystemError", null)
                    : (
                        200,
                        request.ParticipantId.HasValue
                            ? "Common.UpdatedSuccessfully"
                            : "Common.CreatedSuccessfully",
                        data
                    );
            }
            catch (SqlException ex)
            {
                return ex.Number switch
                {
                    50030 => (404, "Common.NotFound",
                        (BookingParticipantViewModel?)null),

                    _ => (500, "Common.SystemError",
                        (BookingParticipantViewModel?)null)
                };
            }
        }

        public async Task<(int ResultCode, string ResultMessage)> DeleteAsync(
            long participantId,
            int? auditUserId)
        {
            using var connection = _connectionFactory.CreateConnection();

            try
            {
                await connection.ExecuteAsync(
                    "dbo.Booking_Participant_Delete",
                    new
                    {
                        ParticipantId = participantId,
                        AuditUserId = auditUserId
                    },
                    commandType: CommandType.StoredProcedure);

                return (200, "Common.DeletedSuccessfully");
            }
            catch (SqlException ex)
            {
                return ex.Number switch
                {
                    50031 => (404, "Common.NotFound"),
                    _ => (500, "Common.SystemError")
                };
            }
        }
    }
}
