using Dapper;
using System.Data.SqlClient;
using TowerApi.Models.Booking.ClassSession;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Booking.ClassSession
{
    public sealed class ClassSessionRepository : IClassSessionRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ClassSessionRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<ClassSessionModel?> GetByIdAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<ClassSessionModel>(
                "dbo.Booking_ClassSession_GetById",
                new { ClassSessionId = id },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<ClassSessionModel?> GetWithClassInfoAsync(long id)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<ClassSessionModel>(
                "dbo.Booking_ClassSessions_GetById",
                new { ClassSessionId = id },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ClassSessionModel>> GetActiveListAsync(
            long? classSeriesId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryAsync<ClassSessionModel>(
                "dbo.Booking_ClassSession_GetActiveList",
                new { ClassSeriesId = classSeriesId },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<ClassSessionModel?> SaveAsync(
            ClassSessionSaveRequest model,
            int userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<ClassSessionModel>(
                "dbo.Booking_ClassSession_Save",
                new
                {
                    ClassSessionId = model.ClassSessionId is > 0
                        ? model.ClassSessionId
                        : null,
                    model.ClassSeriesId,
                    model.BookingId,
                    model.SessionTitle,
                    model.SessionTitleEn,
                    model.SessionStatus,
                    model.IsActive,
                    UserId = userId
                },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<(int Code, string MessageKey)> DeleteAsync(
            long id,
            long userId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                await connection.ExecuteAsync(
                    "dbo.Booking_ClassSessions_Delete",
                    new
                    {
                        ClassSessionId = id,
                        UserId = userId
                    },
                    commandType: System.Data.CommandType.StoredProcedure);

                return (200, "ClassSession.DeleteSuccessfully");
            }
            catch (SqlException ex) when (ex.Number == 50105)
            {
                return (409, "ClassSession.HasActiveEnrollments");
            }
            catch (SqlException ex) when (ex.Number == 50106)
            {
                return (404, "ClassSession.NotFound");
            }
        }
    }
}
