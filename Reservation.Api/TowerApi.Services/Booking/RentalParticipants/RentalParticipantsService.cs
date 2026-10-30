using TowerApi.Models.Booking.RentalParticipants;
using TowerApi.Repositories.Booking.RentalParticipants;

namespace TowerApi.Services.Booking.RentalParticipants
{
    public class RentalParticipantsService : IRentalParticipantsService
    {
        private readonly IRentalParticipantsRepository _repository;
        private readonly ICurrentUser _currentUser;

        public RentalParticipantsService(
            IRentalParticipantsRepository repository,
            ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        public async Task<(int ResultCode, string ResultMessage, RentalParticipantViewModel? Data)>
            GetByIdAsync(long rentalParticipantId)
        {
            if (rentalParticipantId <= 0)
                return (400, "Booking.RentalParticipant.InvalidRequest", null);

            return await _repository.GetByIdAsync(rentalParticipantId);
        }

        public async Task<(int ResultCode, string ResultMessage, IEnumerable<RentalParticipantViewModel>? Data)>
            GetListAsync(RentalParticipantQueryRequest request)
        {
            if (request.BookingId.HasValue && request.BookingId.Value <= 0)
                return (400, "Booking.RentalParticipant.InvalidRequest", null);

            if (request.ParticipantId.HasValue && request.ParticipantId.Value <= 0)
                return (400, "Booking.RentalParticipant.InvalidRequest", null);

            return await _repository.GetListAsync(request);
        }

        public async Task<(int ResultCode, string ResultMessage, RentalParticipantViewModel? Data)>
            SaveAsync(RentalParticipantSaveRequest request)
        {
            if (request == null ||
                request.BookingId <= 0 ||
                request.ParticipantId <= 0 ||
                (request.RentalParticipantId.HasValue && request.RentalParticipantId.Value <= 0))
            {
                return (400, "Booking.RentalParticipant.InvalidRequest", null);
            }

            if (request.Notes?.Length > 500 ||
                request.NotesEn?.Length > 500)
            {
                return (400, "Booking.RentalParticipant.InvalidTextLength", null);
            }

            if (!_currentUser.IsAuthenticated || !_currentUser.UserId.HasValue)
                return (401, "Common.Unauthorized", null);

            var currentUserId = _currentUser.UserId.Value;

            if (currentUserId <= 0 || currentUserId > int.MaxValue)
                return (400, "Common.InvalidUserId", null);

            return await _repository.SaveAsync(request, (int)currentUserId);
        }

        public async Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long rentalParticipantId)
        {
            if (rentalParticipantId <= 0)
                return (400, "Booking.RentalParticipant.InvalidRequest", false);

            return await _repository.DeleteAsync(rentalParticipantId);
        }
    }
}
