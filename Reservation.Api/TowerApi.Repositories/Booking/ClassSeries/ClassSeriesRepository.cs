using System.Data;
using Dapper;
using System.Data.SqlClient;
using TowerApi.Models.Booking;
using TowerApi.Repositories.DataBase;
using TowerApi.Models.Booking.ClassSeries;

namespace TowerApi.Repositories.Booking.ClassSeries
{
    public class ClassSeriesRepository : IClassSeriesRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ClassSeriesRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(int ResultCode, string ResultMessage, ClassSeriesModel? Data)>
            GetByIdAsync(long classSeriesId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var data = await connection.QueryFirstOrDefaultAsync<ClassSeriesModel>(
                    "dbo.Booking_ClassSeries_GetById",
                    new { ClassSeriesId = classSeriesId },
                    commandType: CommandType.StoredProcedure);

                return data is null
                    ? (404, "ClassSeries.NotFound", null)
                    : (200, "ClassSeries.GetById.Success", data);
            }
            catch (Exception)
            {
                return (500, "Common.InternalServerError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage,
            IEnumerable<ClassSeriesModel>? Data)> GetActiveListAsync(long? orgId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var data = await connection.QueryAsync<ClassSeriesModel>(
                    "dbo.Booking_ClassSeries_GetActiveList",
                    new { OrgId = orgId },
                    commandType: CommandType.StoredProcedure);

                return (200, "ClassSeries.GetActiveList.Success", data);
            }
            catch (Exception)
            {
                return (500, "Common.InternalServerError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, ClassSeriesModel? Data)>
            SaveAsync(ClassSeriesModel model, int userId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var data = await connection.QueryFirstOrDefaultAsync<ClassSeriesModel>(
                    "dbo.Booking_ClassSeries_Save",
                    new
                    {
                        ClassSeriesId = model.ClassSeriesId == 0
                            ? (long?)null
                            : model.ClassSeriesId,

                        model.OrgId,
                        model.ClassName,
                        model.ClassNameEn,
                        model.ClassDescription,
                        model.ClassDescriptionEn,
                        model.CoachEmployeeId,
                        model.ExternalCoachName,
                        model.ExternalCoachMobile,
                        model.Capacity,
                        model.IsRegistrationOpen,
                        model.RegistrationStartAt,
                        model.RegistrationEndAt,
                        model.IsActive,
                        UserId = userId
                    },
                    commandType: CommandType.StoredProcedure);

                return data is null
                    ? (500, "Common.InternalServerError", null)
                    : (200, "ClassSeries.Save.Success", data);
            }
            catch (SqlException ex) when (ex.Number == 50010)
            {
                return (400, "ClassSeries.InvalidCapacity", null);
            }
            catch (SqlException ex) when (ex.Number == 50011)
            {
                return (400, "ClassSeries.InvalidRegistrationDates", null);
            }
            catch (SqlException ex) when (ex.Number == 50012)
            {
                return (404, "ClassSeries.NotFound", null);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return (400, "ClassSeries.InvalidReference", null);
            }
            catch (Exception)
            {
                return (500, "Common.InternalServerError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long classSeriesId, long userId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                await connection.ExecuteAsync(
                    "dbo.Booking_ClassSeries_Delete",
                    new
                    {
                        ClassSeriesId = classSeriesId,
                        UserId = userId
                    },
                    commandType: CommandType.StoredProcedure);

                return (200, "ClassSeries.Delete.Success", true);
            }
            catch (SqlException ex) when (ex.Number == 50004)
            {
                return (409, "ClassSeries.HasSessions", false);
            }
            catch (SqlException ex) when (ex.Number == 50005)
            {
                return (404, "ClassSeries.NotFound", false);
            }
            catch (Exception)
            {
                return (500, "Common.InternalServerError", false);
            }
        }
    }
}
