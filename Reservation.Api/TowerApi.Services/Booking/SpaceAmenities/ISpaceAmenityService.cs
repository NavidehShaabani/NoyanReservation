using TowerApi.Models.Booking.SpaceAmenities;

namespace TowerApi.Services.Booking.SpaceAmenities
{
    public interface ISpaceAmenityService
    {
        Task<(int ResultCode, string ResultMessage, SpaceAmenityModel? Data)>
            GetByIdAsync(long spaceAmenityId);

        Task<(int ResultCode, string ResultMessage, IEnumerable<SpaceAmenityModel>? Data)>
            GetListAsync(SpaceAmenityListRequest request);

        Task<(int ResultCode, string ResultMessage, SpaceAmenityModel? Data)>
            SaveAsync(SpaceAmenityModel model);

        Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long spaceAmenityId);
    }
}
