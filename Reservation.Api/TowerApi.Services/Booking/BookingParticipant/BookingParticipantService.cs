using TowerApi.Models.Booking.BookingParticipant;
using TowerApi.Repositories.Booking.BookingParticipant;

namespace TowerApi.Services.Booking.BookingParticipant
{
    public sealed class BookingParticipantService : IBookingParticipantService
    {
        private readonly IBookingParticipantRepository _repository;

        public BookingParticipantService(
            IBookingParticipantRepository repository)
        {
            _repository = repository;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            object? Data
        )> GetByIdAsync(long participantId)
        {
            if (participantId <= 0)
                return (400, "Booking.Participant.InvalidRequest", null);

            var result = await _repository.GetByIdAsync(participantId);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            object? Data
        )> GetActiveListAsync(byte? participantType, long? userId)
        {
            if (participantType.HasValue && participantType.Value == 0)
                return (400, "Booking.Participant.InvalidRequest", null);

            var result = await _repository.GetActiveListAsync(
                participantType,
                userId);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            object? Data
        )> SaveAsync(
            BookingParticipantSaveRequest request,
            long? ownerUserId,
            long? auditUserId)
        {
            if (request is null ||
                string.IsNullOrWhiteSpace(request.FullName) ||
                request.FullName.Trim().Length > 200 ||
                request.MobileNumber?.Length > 20 ||
                request.Email?.Length > 254 ||
                request.ParticipantType == 0 ||
                (request.ParticipantId.HasValue &&
                 request.ParticipantId.Value <= 0) ||
                (ownerUserId.HasValue && ownerUserId.Value <= 0))
            {
                return (400, "Booking.Participant.InvalidRequest", null);
            }

            if (auditUserId.HasValue &&
                (auditUserId.Value <= 0 ||
                 auditUserId.Value > int.MaxValue))
            {
                return (400, "Common.InvalidUserId", null);
            }

            return await _repository.SaveAsync(
                request,
                ownerUserId,
                auditUserId.HasValue ? (int)auditUserId.Value : null);
        }

        public async Task<(int ResultCode, string ResultMessage)> DeleteAsync(
            long participantId,
            long? auditUserId)
        {
            if (participantId <= 0)
                return (400, "Booking.Participant.InvalidRequest");

            if (auditUserId.HasValue &&
                (auditUserId.Value <= 0 ||
                 auditUserId.Value > int.MaxValue))
            {
                return (400, "Common.InvalidUserId");
            }

            return await _repository.DeleteAsync(
                participantId,
                auditUserId.HasValue ? (int)auditUserId.Value : null);
        }
    }
}
