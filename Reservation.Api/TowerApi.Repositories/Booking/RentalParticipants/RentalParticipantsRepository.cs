using Dapper;
using System.Data;
using System.Data.SqlClient;
using TowerApi.Models.Booking.RentalParticipants;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Booking.RentalParticipants
{
    public class RentalParticipantsRepository : IRentalParticipantsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public RentalParticipantsRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(int ResultCode, string ResultMessage, RentalParticipantViewModel? Data)>
            GetByIdAsync(long rentalParticipantId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var result = await connection.QueryFirstOrDefaultAsync<RentalParticipantViewModel>(
                    "Booking_RentalParticipants_GetById",
                    new { RentalParticipantId = rentalParticipantId },
                    commandType: CommandType.StoredProcedure);

                if (result == null)
                    return (404, "Booking.RentalParticipant.NotFound", null);

                return (200, "Booking.RentalParticipant.GetSuccessfully", result);
            }
            catch
            {
                return (500, "Common.SystemError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, IEnumerable<RentalParticipantViewModel>? Data)>
            GetListAsync(RentalParticipantQueryRequest request)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var result = await connection.QueryAsync<RentalParticipantViewModel>(
                    "Booking_RentalParticipants_GetList",
                    new
                    {
                        request.BookingId,
                        request.ParticipantId
                    },
                    commandType: CommandType.StoredProcedure);

                return (200, "Booking.RentalParticipant.GetListSuccessfully", result);
            }
            catch
            {
                return (500, "Common.SystemError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, RentalParticipantViewModel? Data)>
            SaveAsync(RentalParticipantSaveRequest request, int userId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();

                parameters.Add("@RentalParticipantId", request.RentalParticipantId, DbType.Int64);
                parameters.Add("@BookingId", request.BookingId, DbType.Int64);
                parameters.Add("@ParticipantId", request.ParticipantId, DbType.Int64);
                parameters.Add("@ParticipantRole", request.ParticipantRole, DbType.Byte);
                parameters.Add("@Notes", request.Notes, DbType.String, size: 500);
                parameters.Add("@NotesEn", request.NotesEn, DbType.String, size: 500);
                parameters.Add("@UserId", userId, DbType.Int32);

                var result = await connection.QueryFirstOrDefaultAsync<RentalParticipantViewModel>(
                    "Booking_RentalParticipants_Save",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                if (result == null)
                    return (500, "Common.SystemError", null);

                return (200, "Common.SavedSuccessfully", result);
            }
            catch (SqlException ex) when (ex.Number == 51002)
            {
                return (404, "Booking.RentalParticipant.NotFound", null);
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                return (409, "Booking.RentalParticipant.DuplicateParticipant", null);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return (400, "Booking.RentalParticipant.InvalidReference", null);
            }
            catch
            {
                return (500, "Common.SystemError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long rentalParticipantId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                await connection.ExecuteAsync(
                    "Booking_RentalParticipants_Delete",
                    new { RentalParticipantId = rentalParticipantId },
                    commandType: CommandType.StoredProcedure);

                return (200, "Common.DeletedSuccessfully", true);
            }
            catch
            {
                return (500, "Common.SystemError", false);
            }
        }
    }
}
