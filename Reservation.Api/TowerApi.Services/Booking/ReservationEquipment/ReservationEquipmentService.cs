using TowerApi.Models.Booking.ReservationEquipment;
using TowerApi.Repositories.Booking.ReservationEquipment;

namespace TowerApi.Services.Booking.ReservationEquipment
{
    public class ReservationEquipmentService : IReservationEquipmentService
    {
        private readonly IReservationEquipmentRepository _repository;
        private readonly ICurrentUser _currentUser;

        public ReservationEquipmentService(
            IReservationEquipmentRepository repository,
            ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        public async Task<(int ResultCode, string ResultMessage, ReservationEquipmentViewModel? Data)>
            GetByIdAsync(long reservationEquipmentId)
        {
            if (reservationEquipmentId <= 0)
                return (400, "Booking.ReservationEquipment.InvalidRequest", null);

            return await _repository.GetByIdAsync(reservationEquipmentId);
        }

        public async Task<(int ResultCode, string ResultMessage, IEnumerable<ReservationEquipmentViewModel>? Data)>
            GetListAsync(ReservationEquipmentQueryRequest request)
        {
            if (request == null)
                return (400, "Booking.ReservationEquipment.InvalidRequest", null);

            if (request.BookingId.HasValue && request.BookingId.Value <= 0)
                return (400, "Booking.ReservationEquipment.InvalidRequest", null);

            if (request.EquipmentId.HasValue && request.EquipmentId.Value <= 0)
                return (400, "Booking.ReservationEquipment.InvalidRequest", null);

            return await _repository.GetListAsync(request);
        }

        public async Task<(int ResultCode, string ResultMessage, ReservationEquipmentViewModel? Data)>
            SaveAsync(ReservationEquipmentSaveRequest request)
        {
            if (request == null ||
                request.BookingId <= 0 ||
                request.EquipmentId <= 0 ||
                request.Quantity <= 0 ||
                (request.ReservationEquipmentId.HasValue &&
                 request.ReservationEquipmentId.Value <= 0))
            {
                return (400, "Booking.ReservationEquipment.InvalidRequest", null);
            }

            if (request.Notes?.Length > 500 ||
                request.NotesEn?.Length > 500)
            {
                return (400, "Booking.ReservationEquipment.InvalidTextLength", null);
            }

            if (!_currentUser.IsAuthenticated || !_currentUser.UserId.HasValue)
                return (401, "Common.Unauthorized", null);

            var currentUserId = _currentUser.UserId.Value;

            if (currentUserId <= 0 || currentUserId > int.MaxValue)
                return (400, "Common.InvalidUserId", null);

            return await _repository.SaveAsync(request, (int)currentUserId);
        }

        public async Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long reservationEquipmentId)
        {
            if (reservationEquipmentId <= 0)
                return (400, "Booking.ReservationEquipment.InvalidRequest", false);

            return await _repository.DeleteAsync(reservationEquipmentId);
        }
    }
}
