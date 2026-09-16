using TowerApi.Models.Profile;

namespace TowerApi.Services.Profile
{
    public interface IProfileService
    {
        Task<(
            int ResultCode,
            string ResultMessage,
            CompleteProfileResponse? Data
        )> CompleteProfileAsync(
            long userId,
            CompleteProfileRequest request);

        Task<(
            int ResultCode,
            string ResultMessage,
            UserProfileResponse? Data)>
            GetAsync(long userId);
    }
}
