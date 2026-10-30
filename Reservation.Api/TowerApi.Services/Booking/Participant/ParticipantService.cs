using System.Data.SqlClient;
using TowerApi.Models.Booking.Participant;
using TowerApi.Repositories.Booking.Participant;


namespace TowerApi.Services.Booking.Participant
{

    public sealed class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _repository;

        public ParticipantService(IParticipantRepository repository)
        {
            _repository = repository;
        }

        public Task<ParticipantModel?> GetByIdAsync(long id)
            => id > 0
                ? _repository.GetByIdAsync(id)
                : Task.FromResult<ParticipantModel?>(null);

        public Task<IEnumerable<ParticipantModel>> GetActiveListAsync(
            byte? participantType, long? userId)
            => _repository.GetActiveListAsync(
                participantType, userId is > 0 ? userId : null);

        public async Task<(int Code, string MessageKey, ParticipantModel? Data)>
            SaveAsync(ParticipantSaveRequest request, long? currentUserId)
        {
            if (currentUserId is null or <= 0 ||
                currentUserId > int.MaxValue)
                return (401, "Common.Unauthorized", null);

            if (request.ParticipantId < 0)
                return (400, "Participant.InvalidId", null);

            if (string.IsNullOrWhiteSpace(request.FullName))
                return (400, "Participant.FullNameRequired", null);

            if (request.FullName.Trim().Length > 200)
                return (400, "Participant.FullNameTooLong", null);

            if (request.MobileNumber?.Length > 20)
                return (400, "Participant.MobileTooLong", null);

            if (request.Email?.Length > 254)
                return (400, "Participant.EmailTooLong", null);

            if (request.UserId is <= 0)
                return (400, "Participant.InvalidUserId", null);

            try
            {
                var result = await _repository.SaveAsync(
                    request, (int)currentUserId.Value);

                return result is null
                    ? (500, "Common.OperationFailed", null)
                    : (200, "Participant.SaveSuccessfully", result);
            }
            catch (SqlException ex) when (ex.Number == 50030)
            {
                return (404, "Participant.NotFound", null);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return (400, "Participant.InvalidUserId", null);
            }
        }

        public async Task<(int Code, string MessageKey)> DeleteAsync(
            long id, long? currentUserId)
        {
            if (id <= 0)
                return (400, "Participant.InvalidId");

            if (currentUserId is null or <= 0)
                return (401, "Common.Unauthorized");

            return await _repository.DeleteAsync(id, currentUserId.Value);
        }
    }
}
