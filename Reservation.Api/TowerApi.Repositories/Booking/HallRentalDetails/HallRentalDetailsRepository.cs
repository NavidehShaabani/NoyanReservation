using System.Data;
using System.Data.SqlClient;
using Dapper;
using TowerApi.Models.Booking.HallRentalDetails;
using TowerApi.Repositories.DataBase;


namespace TowerApi.Repositories.Booking.HallRentalDetails
{
    public sealed class HallRentalDetailsRepository
    : IHallRentalDetailsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public HallRentalDetailsRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            HallRentalDetailsViewModel? Data
        )> GetByIdAsync(long bookingId)
        {
            using var connection = _connectionFactory.CreateConnection();

            var data =
                await connection.QueryFirstOrDefaultAsync<HallRentalDetailsViewModel>(
                    "dbo.Booking_HallRentalDetails_GetById",
                    new { BookingId = bookingId },
                    commandType: CommandType.StoredProcedure);

            return data is null
                ? (404, "Common.NotFound", null)
                : (200, "Common.GetSuccessfully", data);
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            List<HallRentalDetailsViewModel> Data
        )> GetListAsync(HallRentalDetailsQueryRequest request)
        {
            using var connection = _connectionFactory.CreateConnection();

            var data = (await connection.QueryAsync<HallRentalDetailsViewModel>(
                "dbo.Booking_HallRentalDetails_GetList",
                new
                {
                    request.RenterParticipantId,
                    request.OrgId,
                    request.From,
                    request.To
                },
                commandType: CommandType.StoredProcedure)).AsList();

            return (200, "Common.GetSuccessfully", data);
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            HallRentalDetailsViewModel? Data
        )> SaveAsync(
            HallRentalDetailsSaveRequest request,
            int? userId)
        {
            using var connection = _connectionFactory.CreateConnection();

            try
            {
                var data =
                    await connection.QueryFirstOrDefaultAsync<HallRentalDetailsViewModel>(
                        "dbo.Booking_HallRentalDetails_Save",
                        new
                        {
                            request.BookingId,
                            request.RenterParticipantId,
                            request.RentalPurpose,
                            request.RentalPurposeEn,
                            request.ExpectedAttendeeCount,
                            request.SetupNotes,
                            request.SetupNotesEn,
                            request.AgreedAmount,
                            request.DepositAmount,
                            request.FinalAmount,
                            request.RentalTerms,
                            request.RentalTermsEn,
                            UserId = userId
                        },
                        commandType: CommandType.StoredProcedure);

                return data is null
                    ? (500, "Common.SystemError", null)
                    : (200, "Common.SavedSuccessfully", data);
            }
            catch (SqlException ex)
            {
                return ex.Number switch
                {
                    51001 => (400, "Booking.HallRental.InvalidAmountOrCount",
                        (HallRentalDetailsViewModel?)null),

                    547 => (400, "Booking.HallRental.InvalidReference",
                        (HallRentalDetailsViewModel?)null),

                    _ => (500, "Common.SystemError",
                        (HallRentalDetailsViewModel?)null)
                };
            }
        }

        public async Task<(int ResultCode, string ResultMessage)> DeleteAsync(
            long bookingId)
        {
            using var connection = _connectionFactory.CreateConnection();

            await connection.ExecuteAsync(
                "dbo.Booking_HallRentalDetails_Delete",
                new { BookingId = bookingId },
                commandType: CommandType.StoredProcedure);

            return (200, "Common.DeletedSuccessfully");
        }
    }
}
