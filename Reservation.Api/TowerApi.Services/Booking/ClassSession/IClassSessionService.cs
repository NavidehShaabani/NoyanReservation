using TowerApi.Models.Booking.ClassSession;

namespace TowerApi.Services.Booking.ClassSession
{
    public interface IClassSessionService
    {
        Task<ClassSessionModel?> GetByIdAsync(long id);
        Task<ClassSessionModel?> GetWithClassInfoAsync(long id);
        Task<IEnumerable<ClassSessionModel>> GetActiveListAsync(long? classSeriesId);
        Task<(int Code, string MessageKey, ClassSessionModel? Data)> SaveAsync(
            ClassSessionSaveRequest request, long? userId);
        Task<(int Code, string MessageKey)> DeleteAsync(long id, long? userId);
    }
}
