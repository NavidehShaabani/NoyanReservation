using TowerApi.Models.Booking.ClassSeries;

namespace TowerApi.Repositories.Booking.ClassSeries
{
    public interface IClassSeriesRepository
    {
        Task<(int ResultCode, string ResultMessage, ClassSeriesModel? Data)>
            GetByIdAsync(long classSeriesId);

        Task<(int ResultCode, string ResultMessage, IEnumerable<ClassSeriesModel>? Data)>
            GetActiveListAsync(long? orgId);

        Task<(int ResultCode, string ResultMessage, ClassSeriesModel? Data)>
            SaveAsync(ClassSeriesModel model, int userId);

        Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long classSeriesId, long userId);
    }
}
