using Dapper;
using System.Data.SqlClient;
using System.Data;
using TowerApi.Models.Booking.Equipment;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Booking.Equipment
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public EquipmentRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(int ResultCode, string ResultMessage, EquipmentViewModel? Data)>
            GetByIdAsync(long equipmentId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var result = await connection.QueryFirstOrDefaultAsync<EquipmentViewModel>(
                    "Booking_Equipment_GetById",
                    new { EquipmentId = equipmentId },
                    commandType: CommandType.StoredProcedure);

                if (result == null)
                    return (404, "Booking.Equipment.NotFound", null);

                return (200, "Booking.Equipment.GetSuccessfully", result);
            }
            catch
            {
                return (500, "Common.SystemError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, IEnumerable<EquipmentViewModel>? Data)>
            GetListAsync(EquipmentQueryRequest request)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var result = await connection.QueryAsync<EquipmentViewModel>(
                    "Booking_Equipment_GetList",
                    new
                    {
                        request.OrgId,
                        request.BuildingId,
                        request.DefaultSpaceId,
                        request.OnlyAvailable
                    },
                    commandType: CommandType.StoredProcedure);

                return (200, "Booking.Equipment.GetListSuccessfully", result);
            }
            catch
            {
                return (500, "Common.SystemError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, EquipmentViewModel? Data)>
            SaveAsync(EquipmentSaveRequest request, int userId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();

                parameters.Add("@EquipmentId", request.EquipmentId, DbType.Int64);
                parameters.Add("@OrgId", request.OrgId, DbType.Int64);
                parameters.Add("@BuildingId", request.BuildingId, DbType.Int64);
                parameters.Add("@DefaultSpaceId", request.DefaultSpaceId, DbType.Int64);

                parameters.Add("@EquipmentName", request.EquipmentName, DbType.String, size: 200);
                parameters.Add("@EquipmentNameEn", request.EquipmentNameEn, DbType.String, size: 200);
                parameters.Add("@EquipmentCode", request.EquipmentCode, DbType.String, size: 100);

                parameters.Add("@EquipmentDescription", request.EquipmentDescription, DbType.String, size: 2000);
                parameters.Add("@EquipmentDescriptionEn", request.EquipmentDescriptionEn, DbType.String, size: 2000);

                parameters.Add("@Quantity", request.Quantity, DbType.Int32);
                parameters.Add("@AvailableQuantity", request.AvailableQuantity, DbType.Int32);

                parameters.Add("@OperatorEmployeeId", request.OperatorEmployeeId, DbType.Int64);
                parameters.Add("@EquipmentStatus", request.EquipmentStatus, DbType.Byte);
                parameters.Add("@IsActive", request.IsActive, DbType.Boolean);
                parameters.Add("@UserId", userId, DbType.Int32);

                var result = await connection.QueryFirstOrDefaultAsync<EquipmentViewModel>(
                    "Booking_Equipment_Save",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                if (result == null)
                    return (500, "Common.SystemError", null);

                return (200, "Common.SavedSuccessfully", result);
            }
            catch (SqlException ex) when (ex.Number == 51310)
            {
                return (400, "Booking.Equipment.InvalidQuantity", null);
            }
            catch (SqlException ex) when (ex.Number == 51311)
            {
                return (404, "Booking.Equipment.NotFound", null);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return (400, "Booking.Equipment.InvalidReference", null);
            }
            catch
            {
                return (500, "Common.SystemError", null);
            }
        }

        public async Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long equipmentId, int userId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                await connection.ExecuteAsync(
                    "Booking_Equipment_Delete",
                    new
                    {
                        EquipmentId = equipmentId,
                        UserId = userId
                    },
                    commandType: CommandType.StoredProcedure);

                return (200, "Common.DeletedSuccessfully", true);
            }
            catch (SqlException ex) when (ex.Number == 51312)
            {
                return (404, "Booking.Equipment.NotFound", false);
            }
            catch
            {
                return (500, "Common.SystemError", false);
            }
        }
    }
}
