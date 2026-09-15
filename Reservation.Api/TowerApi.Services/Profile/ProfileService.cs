using TowerApi.Models.Profile;
using TowerApi.Repositories.Profile;

namespace TowerApi.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _repository;

        public ProfileService(
            IProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            CompleteProfileResponse? Data
        )> CompleteProfileAsync(
            long userId,
            CompleteProfileRequest request)
        {
            if (userId <= 0)
            {
                return (
                    401,
                    "کاربر معتبر نیست.",
                    null
                );
            }

            return await _repository.CompleteProfileAsync(
                userId,
                request);
        }
    }
}
