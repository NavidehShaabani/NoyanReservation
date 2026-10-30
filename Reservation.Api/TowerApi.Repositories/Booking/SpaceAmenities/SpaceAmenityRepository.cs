using System.Data;
using Dapper;
using System.Data.SqlClient;
using TowerApi.Models.Booking.SpaceAmenities;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Booking.SpaceAmenities
{
    public class SpaceAmenityRepository : ISpaceAmenityRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public SpaceAmenityRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(int ResultCode, string ResultMessage, SpaceAmenityModel? Data)>
            GetByIdAsync(long spaceAmenityId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var data = await connection.QueryFirstOrDefaultAsync<SpaceAmenityModel>(
                    "dbo.Booking_SpaceAmenities_GetById",
                    new { SpaceAmenityId = spaceAmenityId },
                    commandType: CommandType.StoredProcedure);

                return data is null
                    ? (404, "SpaceAmenity.NotFound", null)
                    : (200, "SpaceAmenity.GetById.Success", data);
            }
            catch (Exception)
            {
                return (500, "Common.InternalServerError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, IEnumerable<SpaceAmenityModel>? Data)>
            GetListAsync(SpaceAmenityListRequest request)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var data = await connection.QueryAsync<SpaceAmenityModel>(
                    "dbo.Booking_SpaceAmenities_GetList",
                    new
                    {
                        request.SpaceId,
                        request.OnlyAvailable
                    },
                    commandType: CommandType.StoredProcedure);

                return (200, "SpaceAmenity.GetList.Success", data);
            }
            catch (Exception)
            {
                return (500, "Common.InternalServerError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, SpaceAmenityModel? Data)>
            SaveAsync(SpaceAmenityModel model, int userId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var data = await connection.QueryFirstOrDefaultAsync<SpaceAmenityModel>(
                    "dbo.Booking_SpaceAmenities_Save",
                    new
                    {
                        SpaceAmenityId = model.SpaceAmenityId == 0
                            ? (long?)null
                            : model.SpaceAmenityId,

                        model.SpaceId,
                        model.AmenityName,
                        model.AmenityNameEn,
                        model.AmenityDescription,
                        model.AmenityDescriptionEn,
                        model.IsAvailable,
                        UserId = userId
                    },
                    commandType: CommandType.StoredProcedure);

                return data is null
                    ? (500, "Common.InternalServerError", null)
                    : (200, "SpaceAmenity.Save.Success", data);
            }
            catch (SqlException ex) when (ex.Number == 51301)
            {
                return (404, "SpaceAmenity.NotFound", null);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return (400, "SpaceAmenity.InvalidSpace", null);
            }
            catch (SqlException)
            {
                return (500, "Common.InternalServerError", null);
            }
            catch (Exception)
            {
                return (500, "Common.InternalServerError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long spaceAmenityId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                await connection.ExecuteAsync(
                    "dbo.Booking_SpaceAmenities_Delete",
                    new { SpaceAmenityId = spaceAmenityId },
                    commandType: CommandType.StoredProcedure);

                return (200, "SpaceAmenity.Delete.Success", true);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return (400, "SpaceAmenity.Delete.ConstraintError", false);
            }
            catch (Exception)
            {
                return (500, "Common.InternalServerError", false);
            }
        }
    }
}
