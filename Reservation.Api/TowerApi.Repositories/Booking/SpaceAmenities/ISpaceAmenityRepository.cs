using TowerApi.Models.Booking.SpaceAmenities;

namespace TowerApi.Repositories.Booking.SpaceAmenities
{
    public interface ISpaceAmenityRepository
    {
        Task<(int ResultCode, string ResultMessage, SpaceAmenityModel? Data)>
            GetByIdAsync(long spaceAmenityId);

        Task<(int ResultCode, string ResultMessage, IEnumerable<SpaceAmenityModel>? Data)>
            GetListAsync(SpaceAmenityListRequest request);

        Task<(int ResultCode, string ResultMessage, SpaceAmenityModel? Data)>
            SaveAsync(SpaceAmenityModel model, int userId);

        Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long spaceAmenityId);
    }
}
