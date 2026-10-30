
using TowerApi.Models.Booking.Participant;

namespace TowerApi.Repositories.Booking.Participant
{
    public interface IParticipantRepository
    {
        Task<ParticipantModel?> GetByIdAsync(long id);
        Task<IEnumerable<ParticipantModel>> GetActiveListAsync(
            byte? participantType, long? userId);
        Task<ParticipantModel?> SaveAsync(
            ParticipantSaveRequest request, int auditUserId);
        Task<(int Code, string MessageKey)> DeleteAsync(
            long participantId, long operatorUserId);
    }

}
