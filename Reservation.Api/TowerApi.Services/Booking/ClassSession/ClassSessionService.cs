using TowerApi.Models.Booking.ClassSession;
using TowerApi.Repositories.Booking.ClassSession;
using System.Data.SqlClient;

namespace TowerApi.Services.Booking.ClassSession
{

    public sealed class ClassSessionService : IClassSessionService
    {
        private readonly IClassSessionRepository _repository;

        public ClassSessionService(IClassSessionRepository repository)
        {
            _repository = repository;
        }

        public Task<ClassSessionModel?> GetByIdAsync(long id)
            => id <= 0
                ? Task.FromResult<ClassSessionModel?>(null)
                : _repository.GetByIdAsync(id);

        public Task<ClassSessionModel?> GetWithClassInfoAsync(long id)
            => id <= 0
                ? Task.FromResult<ClassSessionModel?>(null)
                : _repository.GetWithClassInfoAsync(id);

        public Task<IEnumerable<ClassSessionModel>> GetActiveListAsync(
            long? classSeriesId)
            => _repository.GetActiveListAsync(
                classSeriesId is > 0 ? classSeriesId : null);

        public async Task<(int Code, string MessageKey, ClassSessionModel? Data)>
            SaveAsync(ClassSessionSaveRequest request, long? userId)
        {
            if (userId is null or <= 0 || userId > int.MaxValue)
                return (401, "Common.Unauthorized", null);

            if (request.ClassSeriesId <= 0 || request.BookingId <= 0)
                return (400, "ClassSession.InvalidReference", null);

            if (request.ClassSessionId < 0)
                return (400, "ClassSession.InvalidId", null);

            if (request.SessionTitle?.Length > 200 ||
                request.SessionTitleEn?.Length > 200)
                return (400, "ClassSession.TitleTooLong", null);

            try
            {
                var result = await _repository.SaveAsync(request, (int)userId.Value);

                return result is null
                    ? (500, "Common.OperationFailed", null)
                    : (200, "ClassSession.SaveSuccessfully", result);
            }
            catch (SqlException ex)
                when (ex.Number is 2601 or 2627)
            {
                return (409, "ClassSession.BookingAlreadyHasSession", null);
            }
            catch (SqlException ex)
                when (ex.Number == 50020)
            {
                return (404, "ClassSession.NotFound", null);
            }
            catch (SqlException ex)
                when (ex.Number == 547)
            {
                return (400, "ClassSession.InvalidReference", null);
            }
        }

        public async Task<(int Code, string MessageKey)> DeleteAsync(
            long id, long? userId)
        {
            if (id <= 0)
                return (400, "ClassSession.InvalidId");

            if (userId is null or <= 0)
                return (401, "Common.Unauthorized");

            return await _repository.DeleteAsync(id, userId.Value);
        }
    }
}
