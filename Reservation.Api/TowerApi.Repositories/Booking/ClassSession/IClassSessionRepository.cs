using TowerApi.Models.Booking.ClassSession;

namespace TowerApi.Repositories.Booking.ClassSession
{
    public interface IClassSessionRepository
    {
        Task<ClassSessionModel?> GetByIdAsync(long id);
        Task<ClassSessionModel?> GetWithClassInfoAsync(long id);
        Task<IEnumerable<ClassSessionModel>> GetActiveListAsync(long? classSeriesId);
        Task<ClassSessionModel?> SaveAsync(ClassSessionSaveRequest model, int userId);
        Task<(int Code, string MessageKey)> DeleteAsync(long id, long userId);
    }
}
