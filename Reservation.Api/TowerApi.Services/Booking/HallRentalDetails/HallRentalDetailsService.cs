using TowerApi.Models.Booking.HallRentalDetails;
using TowerApi.Repositories.Booking.HallRentalDetails;

namespace TowerApi.Services.Booking.HallRentalDetails
{
    public sealed class HallRentalDetailsService : IHallRentalDetailsService
    {
        private readonly IHallRentalDetailsRepository _repository;

        public HallRentalDetailsService(
            IHallRentalDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            object? Data
        )> GetByIdAsync(long bookingId)
        {
            if (bookingId <= 0)
                return (400, "Booking.HallRental.InvalidRequest", null);

            var result = await _repository.GetByIdAsync(bookingId);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            object? Data
        )> GetListAsync(HallRentalDetailsQueryRequest request)
        {
            if (request is null)
                return (400, "Booking.HallRental.InvalidRequest", null);

            if (request.RenterParticipantId.HasValue &&
                request.RenterParticipantId.Value <= 0)
            {
                return (400, "Booking.HallRental.InvalidRequest", null);
            }

            if (request.OrgId.HasValue && request.OrgId.Value <= 0)
                return (400, "Booking.HallRental.InvalidRequest", null);

            if (request.From.HasValue &&
                request.To.HasValue &&
                request.To.Value < request.From.Value)
            {
                return (400, "Booking.HallRental.InvalidDateRange", null);
            }

            var result = await _repository.GetListAsync(request);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            object? Data
        )> SaveAsync(
            HallRentalDetailsSaveRequest request,
            long? userId)
        {
            if (request is null ||
                request.BookingId <= 0 ||
                request.RenterParticipantId <= 0 ||
                request.ExpectedAttendeeCount < 0 ||
                request.DepositAmount < 0 ||
                request.AgreedAmount < 0 ||
                request.FinalAmount < 0 ||
                request.RentalPurpose?.Length > 500 ||
                request.RentalPurposeEn?.Length > 500 ||
                request.SetupNotes?.Length > 1000 ||
                request.SetupNotesEn?.Length > 1000 ||
                request.RentalTerms?.Length > 2000 ||
                request.RentalTermsEn?.Length > 2000)
            {
                return (400, "Booking.HallRental.InvalidRequest", null);
            }

            if (userId.HasValue &&
                (userId.Value <= 0 || userId.Value > int.MaxValue))
            {
                return (400, "Common.InvalidUserId", null);
            }

            return await _repository.SaveAsync(
                request,
                userId.HasValue ? (int)userId.Value : null);
        }

        public async Task<(int ResultCode, string ResultMessage)> DeleteAsync(
            long bookingId)
        {
            if (bookingId <= 0)
                return (400, "Booking.HallRental.InvalidRequest");

            return await _repository.DeleteAsync(bookingId);
        }
    }
}
