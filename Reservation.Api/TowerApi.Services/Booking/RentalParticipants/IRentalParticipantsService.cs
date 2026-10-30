
using TowerApi.Models.Booking.RentalParticipants;

namespace TowerApi.Services.Booking.RentalParticipants
{
    public interface IRentalParticipantsService
    {
        Task<(int ResultCode, string ResultMessage, RentalParticipantViewModel? Data)>
            GetByIdAsync(long rentalParticipantId);

        Task<(int ResultCode, string ResultMessage, IEnumerable<RentalParticipantViewModel>? Data)>
            GetListAsync(RentalParticipantQueryRequest request);

        Task<(int ResultCode, string ResultMessage, RentalParticipantViewModel? Data)>
            SaveAsync(RentalParticipantSaveRequest request);

        Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long rentalParticipantId);
    }
}
