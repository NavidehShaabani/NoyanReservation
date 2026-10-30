using System.Data;
using Dapper;
using System.Data.SqlClient;
using TowerApi.Models.Booking.Participant;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Booking.Participant
{

    public sealed class ParticipantRepository : IParticipantRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ParticipantRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<ParticipantModel?> GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<ParticipantModel>(
                "dbo.Booking_Participants_GetById",
                new { ParticipantId = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ParticipantModel>> GetActiveListAsync(
            byte? participantType, long? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<ParticipantModel>(
                "dbo.Booking_Participant_GetActiveList",
                new
                {
                    ParticipantType = participantType,
                    UserId = userId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<ParticipantModel?> SaveAsync(
            ParticipantSaveRequest request, int auditUserId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<ParticipantModel>(
                "dbo.Booking_Participant_Save",
                new
                {
                    ParticipantId = request.ParticipantId is > 0
                        ? request.ParticipantId
                        : null,
                    request.UserId,
                    request.FullName,
                    request.MobileNumber,
                    request.Email,
                    request.ParticipantType,
                    request.IsActive,
                    AuditUserId = auditUserId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<(int Code, string MessageKey)> DeleteAsync(
            long participantId, long operatorUserId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                await connection.ExecuteAsync(
                    "dbo.Booking_Participants_Delete",
                    new
                    {
                        ParticipantId = participantId,
                        OperatorUserId = operatorUserId
                    },
                    commandType: CommandType.StoredProcedure);

                return (200, "Participant.DeleteSuccessfully");
            }
            catch (SqlException ex) when (ex.Number == 50203)
            {
                return (409, "Participant.HasClassEnrollment");
            }
            catch (SqlException ex) when (ex.Number == 50204)
            {
                return (409, "Participant.UsedInHallRental");
            }
            catch (SqlException ex) when (ex.Number == 50205)
            {
                return (404, "Participant.NotFound");
            }
        }
    }
}
