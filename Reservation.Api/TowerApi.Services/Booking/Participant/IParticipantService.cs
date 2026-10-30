using TowerApi.Models.Booking.Participant;

namespace TowerApi.Services.Booking.Participant
{
    public interface IParticipantService
    {
        Task<ParticipantModel?> GetByIdAsync(long id);
        Task<IEnumerable<ParticipantModel>> GetActiveListAsync(
            byte? participantType, long? userId);
        Task<(int Code, string MessageKey, ParticipantModel? Data)> SaveAsync(
            ParticipantSaveRequest request, long? currentUserId);
        Task<(int Code, string MessageKey)> DeleteAsync(
            long id, long? currentUserId);
    }
}
