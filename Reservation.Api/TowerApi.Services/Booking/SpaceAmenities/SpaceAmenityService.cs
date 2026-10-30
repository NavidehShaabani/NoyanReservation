using TowerApi.Models.Booking.SpaceAmenities;
using TowerApi.Repositories.Booking.SpaceAmenities;

namespace TowerApi.Services.Booking.SpaceAmenities
{

    public class SpaceAmenityService : ISpaceAmenityService
    {
        private readonly ISpaceAmenityRepository _repository;
        private readonly ICurrentUser _currentUser;

        public SpaceAmenityService(
            ISpaceAmenityRepository repository,
            ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        public Task<(int ResultCode, string ResultMessage, SpaceAmenityModel? Data)>
            GetByIdAsync(long spaceAmenityId)
        {
            if (spaceAmenityId <= 0)
                return Task.FromResult<(int, string, SpaceAmenityModel?)>(
                    (400, "Common.InvalidId", null));

            return _repository.GetByIdAsync(spaceAmenityId);
        }

        public Task<(int ResultCode, string ResultMessage, IEnumerable<SpaceAmenityModel>? Data)>
            GetListAsync(SpaceAmenityListRequest request)
        {
            if (request.SpaceId.HasValue && request.SpaceId.Value <= 0)
            {
                return Task.FromResult<(int, string, IEnumerable<SpaceAmenityModel>?)>(
                    (400, "Common.InvalidId", null));
            }

            return _repository.GetListAsync(request);
        }

        public async Task<(int ResultCode, string ResultMessage, SpaceAmenityModel? Data)>
            SaveAsync(SpaceAmenityModel model)
        {
            if (model.SpaceId <= 0)
                return (400, "Common.InvalidId", null);

            if (model.SpaceAmenityId < 0)
                return (400, "Common.InvalidId", null);

            if (string.IsNullOrWhiteSpace(model.AmenityName))
                return (400, "SpaceAmenity.NameRequired", null);

            if (model.AmenityName.Length > 200 ||
                (model.AmenityNameEn?.Length > 200))
                return (400, "SpaceAmenity.NameMaxLength", null);

            if (model.AmenityDescription?.Length > 1000 ||
                model.AmenityDescriptionEn?.Length > 1000)
                return (400, "SpaceAmenity.DescriptionMaxLength", null);

            if (!_currentUser.UserId.HasValue ||
                _currentUser.UserId.Value <= 0 ||
                _currentUser.UserId.Value > int.MaxValue)
            {
                return (401, "Common.Unauthorized", null);
            }

            return await _repository.SaveAsync(
                model,
                (int)_currentUser.UserId.Value);
        }

        public Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long spaceAmenityId)
        {
            if (spaceAmenityId <= 0)
                return Task.FromResult<(int, string, bool)>(
                    (400, "Common.InvalidId", false));

            return _repository.DeleteAsync(spaceAmenityId);
        }
    }
}
