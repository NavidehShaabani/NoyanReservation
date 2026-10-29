using System.Data;
using System.Data.SqlClient;
using Dapper;
using TowerApi.Models.Booking.SpaceBooking;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Booking.SpaceBooking
{
    public class SpaceBookingRepository : ISpaceBookingRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public SpaceBookingRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            List<SpaceBookingViewModel> Data)>
            GetListAsync(SpaceBookingQueryRequest request)
        {
            try
            {
                using var connection =
                    _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();

                parameters.Add("@SpaceId", request.SpaceId, DbType.Int64);
                parameters.Add("@OrgId", request.OrgId, DbType.Int64);
                parameters.Add("@StartFrom", request.StartFrom, DbType.DateTime2);
                parameters.Add("@StartTo", request.StartTo, DbType.DateTime2);
                parameters.Add("@BookingStatus", request.BookingStatus, DbType.Byte);
                parameters.Add("@BookingType", request.BookingType, DbType.Byte);
                parameters.Add("@OnlyActive", request.OnlyActive, DbType.Boolean);

                var data = (await connection.QueryAsync<SpaceBookingViewModel>(
                    "dbo.Booking_Space_GetList",
                    parameters,
                    commandType: CommandType.StoredProcedure)).ToList();

                return (200, "اطلاعات رزروها دریافت شد.", data);
            }
            catch (SqlException ex)
            {
                return (500, ex.Message, new List<SpaceBookingViewModel>());
            }
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            SpaceBookingViewModel? Data)>
            GetByIdAsync(long bookingId)
        {
            try
            {
                using var connection =
                    _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("@BookingId", bookingId, DbType.Int64);

                var data =
                    await connection.QueryFirstOrDefaultAsync<SpaceBookingViewModel>(
                        "dbo.Booking_Space_GetById",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                if (data == null)
                    return (404, "رزرو موردنظر پیدا نشد.", null);

                return (200, "اطلاعات رزرو دریافت شد.", data);
            }
            catch (SqlException ex)
            {
                return (500, ex.Message, null);
            }
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            SpaceBookingViewModel? Data)>
            AddAsync(SpaceBookingCreateRequest request, int? userCreater)
        {
            try
            {
                using var connection =
                    _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();

                parameters.Add("@BookingId", null, DbType.Int64);
                parameters.Add("@OrgId", request.OrgId, DbType.Int64);
                parameters.Add("@BuildingId", request.BuildingId, DbType.Int64);
                parameters.Add("@SpaceId", request.SpaceId, DbType.Int64);
                parameters.Add("@BookingType", request.BookingType, DbType.Byte);
                parameters.Add("@StartAt", request.StartAt, DbType.DateTime2);
                parameters.Add("@EndAt", request.EndAt, DbType.DateTime2);
                parameters.Add("@BookingStatus", request.BookingStatus, DbType.Byte);
                parameters.Add(
                    "@RequestedByParticipantId",
                    request.RequestedByParticipantId,
                    DbType.Int64);
                parameters.Add(
                    "@ApprovedByUserId",
                    null,
                    DbType.Int64);
                parameters.Add("@ApprovedAt", null, DbType.DateTime2);
                parameters.Add("@BookingTitle", request.BookingTitle, DbType.String);
                parameters.Add(
                    "@BookingDescription",
                    request.BookingDescription,
                    DbType.String);
                parameters.Add(
                    "@BookingDescriptionEn",
                    request.BookingDescriptionEn,
                    DbType.String);
                parameters.Add("@UserId", userCreater, DbType.Int32);

                var data =
                    await connection.QueryFirstOrDefaultAsync<SpaceBookingViewModel>(
                        "dbo.Booking_Space_Save",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                if (data == null)
                    return (500, "اطلاعات رزرو از پایگاه داده دریافت نشد.", null);

                return (200, "رزرو با موفقیت ثبت شد.", data);
            }
            catch (SqlException ex)
            {
                return (MapSqlError(ex.Number), ex.Message, null);
            }
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            SpaceBookingViewModel? Data)>
            EditAsync(
                long bookingId,
                SpaceBookingUpdateRequest request,
                int? userUpdater)
        {
            try
            {
                using var connection =
                    _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();

                parameters.Add("@BookingId", bookingId, DbType.Int64);
                parameters.Add("@OrgId", request.OrgId, DbType.Int64);
                parameters.Add("@BuildingId", request.BuildingId, DbType.Int64);
                parameters.Add("@SpaceId", request.SpaceId, DbType.Int64);
                parameters.Add("@BookingType", request.BookingType, DbType.Byte);
                parameters.Add("@StartAt", request.StartAt, DbType.DateTime2);
                parameters.Add("@EndAt", request.EndAt, DbType.DateTime2);
                parameters.Add("@BookingStatus", request.BookingStatus, DbType.Byte);
                parameters.Add(
                    "@RequestedByParticipantId",
                    request.RequestedByParticipantId,
                    DbType.Int64);
                parameters.Add("@ApprovedByUserId", null, DbType.Int64);
                parameters.Add("@ApprovedAt", null, DbType.DateTime2);
                parameters.Add("@BookingTitle", request.BookingTitle, DbType.String);
                parameters.Add(
                    "@BookingDescription",
                    request.BookingDescription,
                    DbType.String);
                parameters.Add(
                    "@BookingDescriptionEn",
                    request.BookingDescriptionEn,
                    DbType.String);
                parameters.Add("@UserId", userUpdater, DbType.Int32);

                var data =
                    await connection.QueryFirstOrDefaultAsync<SpaceBookingViewModel>(
                        "dbo.Booking_Space_Save",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                if (data == null)
                    return (404, "رزرو موردنظر پیدا نشد.", null);

                return (200, "رزرو با موفقیت ویرایش شد.", data);
            }
            catch (SqlException ex)
            {
                return (MapSqlError(ex.Number), ex.Message, null);
            }
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            SpaceBookingConflictViewModel? Data)>
            CheckConflictAsync(SpaceBookingConflictRequest request)
        {
            try
            {
                using var connection =
                    _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();

                parameters.Add("@SpaceId", request.SpaceId, DbType.Int64);
                parameters.Add("@StartAt", request.StartAt, DbType.DateTime2);
                parameters.Add("@EndAt", request.EndAt, DbType.DateTime2);
                parameters.Add(
                    "@ExcludeBookingId",
                    request.ExcludeBookingId,
                    DbType.Int64);
                parameters.Add(
                    "@BlockingStatuses",
                    "1,2,3",
                    DbType.String);

                var data =
                    await connection.QueryFirstOrDefaultAsync<SpaceBookingConflictViewModel>(
                        "dbo.Booking_Space_CheckConflict",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                if (data == null)
                    return (500, "نتیجه بررسی تداخل دریافت نشد.", null);

                return data.HasConflict
                    ? (409, "در بازه زمانی انتخاب‌شده تداخل رزرو وجود دارد.", data)
                    : (200, "در بازه زمانی انتخاب‌شده تداخلی وجود ندارد.", data);
            }
            catch (SqlException ex)
            {
                return (MapSqlError(ex.Number), ex.Message, null);
            }
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            SpaceBookingViewModel? Data)>
            ApproveAsync(long bookingId, int userId)
        {
            try
            {
                using var connection =
                    _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();

                parameters.Add("@BookingId", bookingId, DbType.Int64);
                parameters.Add("@ApprovedStatus", (byte)2, DbType.Byte);
                parameters.Add("@PendingStatus", (byte)1, DbType.Byte);
                parameters.Add("@UserId", userId, DbType.Int32);

                var data =
                    await connection.QueryFirstOrDefaultAsync<SpaceBookingViewModel>(
                        "dbo.Booking_Space_Approve",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                if (data == null)
                    return (404, "رزرو موردنظر پیدا نشد.", null);

                return (200, "رزرو با موفقیت تأیید شد.", data);
            }
            catch (SqlException ex)
            {
                return (MapSqlError(ex.Number), ex.Message, null);
            }
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            SpaceBookingViewModel? Data)>
            CancelAsync(long bookingId, int userId)
        {
            try
            {
                using var connection =
                    _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();

                parameters.Add("@BookingId", bookingId, DbType.Int64);
                parameters.Add("@CancelledStatus", (byte)6, DbType.Byte);
                parameters.Add("@UserId", userId, DbType.Int32);

                var data =
                    await connection.QueryFirstOrDefaultAsync<SpaceBookingViewModel>(
                        "dbo.Booking_Space_Cancel",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                if (data == null)
                    return (404, "رزرو موردنظر پیدا نشد.", null);

                return (200, "رزرو با موفقیت لغو شد.", data);
            }
            catch (SqlException ex)
            {
                return (MapSqlError(ex.Number), ex.Message, null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long bookingId, int userId)
        {
            try
            {
                using var connection =
                    _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();

                parameters.Add("@BookingId", bookingId, DbType.Int64);
                parameters.Add("@UserId", userId, DbType.Int32);

                await connection.ExecuteAsync(
                    "dbo.Booking_Space_Delete",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return (200, "رزرو با موفقیت حذف شد.");
            }
            catch (SqlException ex)
            {
                return (MapSqlError(ex.Number), ex.Message);
            }
        }

        private static int MapSqlError(int errorNumber)
        {
            return errorNumber switch
            {
                50001 => 400,
                50002 => 404,
                50003 => 404,
                51601 => 400,
                51701 => 404,
                51702 => 400,
                51703 => 400,
                51704 => 409,
                51705 => 404,
                _ => 500
            };
        }
    }
}
