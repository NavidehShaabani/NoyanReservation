using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerApi.Models.Profile;

namespace TowerApi.Repositories.Profile
{
    public interface IProfileRepository
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
