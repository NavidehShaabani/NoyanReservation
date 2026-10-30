using TowerApi.Models.Booking.ClassSeries;

namespace TowerApi.Services.Booking.ClassSeries
{
    public interface IClassSeriesService
    {
        Task<(int ResultCode, string ResultMessage, ClassSeriesModel? Data)>
            GetByIdAsync(long classSeriesId);

        Task<(int ResultCode, string ResultMessage, IEnumerable<ClassSeriesModel>? Data)>
            GetActiveListAsync(long? orgId);

        Task<(int ResultCode, string ResultMessage, ClassSeriesModel? Data)>
            SaveAsync(ClassSeriesModel model);

        Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long classSeriesId);
    }
}
