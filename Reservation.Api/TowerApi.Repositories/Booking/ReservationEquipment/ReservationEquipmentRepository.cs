using Dapper;
using System.Data;
using TowerApi.Models.Booking.ReservationEquipment;
using TowerApi.Repositories.DataBase;
using System.Data.SqlClient;

namespace TowerApi.Repositories.Booking.ReservationEquipment
{
    public class ReservationEquipmentRepository : IReservationEquipmentRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ReservationEquipmentRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(int ResultCode, string ResultMessage, ReservationEquipmentViewModel? Data)>
            GetByIdAsync(long reservationEquipmentId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var result =
                    await connection.QueryFirstOrDefaultAsync<ReservationEquipmentViewModel>(
                        "Booking_ReservationEquipment_GetById",
                        new
                        {
                            ReservationEquipmentId = reservationEquipmentId
                        },
                        commandType: CommandType.StoredProcedure);

                if (result == null)
                    return (404, "Booking.ReservationEquipment.NotFound", null);

                return (200, "Booking.ReservationEquipment.GetSuccessfully", result);
            }
            catch
            {
                return (500, "Common.SystemError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, IEnumerable<ReservationEquipmentViewModel>? Data)>
            GetListAsync(ReservationEquipmentQueryRequest request)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var result =
                    await connection.QueryAsync<ReservationEquipmentViewModel>(
                        "Booking_ReservationEquipment_GetList",
                        new
                        {
                            request.BookingId,
                            request.EquipmentId
                        },
                        commandType: CommandType.StoredProcedure);

                return (
                    200,
                    "Booking.ReservationEquipment.GetListSuccessfully",
                    result);
            }
            catch
            {
                return (500, "Common.SystemError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, ReservationEquipmentViewModel? Data)>
            SaveAsync(ReservationEquipmentSaveRequest request, int userId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();

                parameters.Add(
                    "@ReservationEquipmentId",
                    request.ReservationEquipmentId,
                    DbType.Int64);

                parameters.Add(
                    "@BookingId",
                    request.BookingId,
                    DbType.Int64);

                parameters.Add(
                    "@EquipmentId",
                    request.EquipmentId,
                    DbType.Int64);

                parameters.Add(
                    "@Quantity",
                    request.Quantity,
                    DbType.Int32);

                parameters.Add(
                    "@Notes",
                    request.Notes,
                    DbType.String,
                    size: 1000);

                parameters.Add(
                    "@NotesEn",
                    request.NotesEn,
                    DbType.String,
                    size: 1000);

                parameters.Add(
                    "@UserId",
                    userId,
                    DbType.Int32);

                var result =
                    await connection.QueryFirstOrDefaultAsync<ReservationEquipmentViewModel>(
                        "Booking_ReservationEquipment_Save",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                if (result == null)
                    return (500, "Common.SystemError", null);

                return (200, "Common.SavedSuccessfully", result);
            }
            catch (SqlException ex) when (ex.Number == 51401)
            {
                return (400, "Booking.ReservationEquipment.InvalidQuantity", null);
            }
            catch (SqlException ex) when (ex.Number == 51402)
            {
                return (404, "Booking.ReservationEquipment.NotFound", null);
            }
            catch (SqlException ex) when (ex.Number == 51403 ||
                                          ex.Number == 2601 ||
                                          ex.Number == 2627)
            {
                return (409, "Booking.ReservationEquipment.DuplicateEquipment", null);
            }
            catch (SqlException ex) when (ex.Number == 51404)
            {
                return (400, "Booking.ReservationEquipment.InsufficientOrInactive", null);
            }
            catch (SqlException ex) when (ex.Number == 51405 ||
                                          ex.Number == 51406)
            {
                return (400, "Booking.ReservationEquipment.InsufficientStock", null);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return (400, "Booking.ReservationEquipment.InvalidReference", null);
            }
            catch
            {
                return (500, "Common.SystemError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long reservationEquipmentId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                await connection.ExecuteAsync(
                    "Booking_ReservationEquipment_Delete",
                    new
                    {
                        ReservationEquipmentId = reservationEquipmentId
                    },
                    commandType: CommandType.StoredProcedure);

                return (200, "Common.DeletedSuccessfully", true);
            }
            catch (SqlException ex) when (ex.Number == 51407)
            {
                return (404, "Booking.ReservationEquipment.NotFound", false);
            }
            catch
            {
                return (500, "Common.SystemError", false);
            }
        }
    }
}
