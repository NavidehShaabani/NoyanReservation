using TowerApi.Models.Booking.Equipment;
using TowerApi.Repositories.Booking.Equipment;

namespace TowerApi.Services.Booking.Equipment
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _repository;
        private readonly ICurrentUser _currentUser;

        public EquipmentService(
            IEquipmentRepository repository,
            ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        public async Task<(int ResultCode, string ResultMessage, EquipmentViewModel? Data)>
            GetByIdAsync(long equipmentId)
        {
            if (equipmentId <= 0)
                return (400, "Booking.Equipment.InvalidRequest", null);

            return await _repository.GetByIdAsync(equipmentId);
        }

        public async Task<(int ResultCode, string ResultMessage, IEnumerable<EquipmentViewModel>? Data)>
            GetListAsync(EquipmentQueryRequest request)
        {
            if (request == null)
                return (400, "Booking.Equipment.InvalidRequest", null);

            if ((request.OrgId.HasValue && request.OrgId.Value <= 0) ||
                (request.BuildingId.HasValue && request.BuildingId.Value <= 0) ||
                (request.DefaultSpaceId.HasValue && request.DefaultSpaceId.Value <= 0))
            {
                return (400, "Booking.Equipment.InvalidRequest", null);
            }

            return await _repository.GetListAsync(request);
        }

        public async Task<(int ResultCode, string ResultMessage, EquipmentViewModel? Data)>
            SaveAsync(EquipmentSaveRequest request)
        {
            if (request == null ||
                request.OrgId <= 0 ||
                request.BuildingId <= 0 ||
                (request.EquipmentId.HasValue && request.EquipmentId.Value <= 0) ||
                (request.DefaultSpaceId.HasValue && request.DefaultSpaceId.Value <= 0) ||
                (request.OperatorEmployeeId.HasValue && request.OperatorEmployeeId.Value <= 0))
            {
                return (400, "Booking.Equipment.InvalidRequest", null);
            }

            if (string.IsNullOrWhiteSpace(request.EquipmentName))
                return (400, "Booking.Equipment.NameRequired", null);

            if (request.EquipmentName.Length > 200 ||
                request.EquipmentNameEn?.Length > 200 ||
                request.EquipmentCode?.Length > 50 ||
                request.EquipmentDescription?.Length > 1000 ||
                request.EquipmentDescriptionEn?.Length > 1000)
            {
                return (400, "Booking.Equipment.InvalidTextLength", null);
            }

            if (request.Quantity < 0 ||
                request.AvailableQuantity < 0 ||
                request.AvailableQuantity > request.Quantity)
            {
                return (400, "Booking.Equipment.InvalidQuantity", null);
            }

            if (!_currentUser.IsAuthenticated || !_currentUser.UserId.HasValue)
                return (401, "Common.Unauthorized", null);

            var currentUserId = _currentUser.UserId.Value;

            if (currentUserId <= 0 || currentUserId > int.MaxValue)
                return (400, "Common.InvalidUserId", null);

            return await _repository.SaveAsync(request, (int)currentUserId);
        }

        public async Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long equipmentId)
        {
            if (equipmentId <= 0)
                return (400, "Booking.Equipment.InvalidRequest", false);

            if (!_currentUser.IsAuthenticated || !_currentUser.UserId.HasValue)
                return (401, "Common.Unauthorized", false);

            var currentUserId = _currentUser.UserId.Value;

            if (currentUserId <= 0 || currentUserId > int.MaxValue)
                return (400, "Common.InvalidUserId", false);

            return await _repository.DeleteAsync(equipmentId, (int)currentUserId);
        }
    }
}
