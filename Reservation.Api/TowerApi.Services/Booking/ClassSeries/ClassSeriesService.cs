using TowerApi.Models.Booking.ClassSeries;
using TowerApi.Repositories.Booking.ClassSeries;

namespace TowerApi.Services.Booking.ClassSeries
{
    public class ClassSeriesService : IClassSeriesService
    {
        private readonly IClassSeriesRepository _repository;
        private readonly ICurrentUser _currentUser;

        public ClassSeriesService(
            IClassSeriesRepository repository,
            ICurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }

        public Task<(int ResultCode, string ResultMessage, ClassSeriesModel? Data)>
            GetByIdAsync(long classSeriesId)
        {
            if (classSeriesId <= 0)
            {
                return Task.FromResult<(int, string, ClassSeriesModel?)>(
                    (400, "Common.InvalidId", null));
            }

            return _repository.GetByIdAsync(classSeriesId);
        }

        public Task<(int ResultCode, string ResultMessage,
            IEnumerable<ClassSeriesModel>? Data)> GetActiveListAsync(long? orgId)
        {
            if (orgId.HasValue && orgId.Value <= 0)
            {
                return Task.FromResult<
                    (int, string, IEnumerable<ClassSeriesModel>?)>(
                    (400, "Common.InvalidId", null));
            }

            return _repository.GetActiveListAsync(orgId);
        }

        public async Task<(int ResultCode, string ResultMessage, ClassSeriesModel? Data)>
            SaveAsync(ClassSeriesModel model)
        {
            if (model.OrgId <= 0 || model.ClassSeriesId < 0)
                return (400, "Common.InvalidId", null);

            if (string.IsNullOrWhiteSpace(model.ClassName))
                return (400, "ClassSeries.NameRequired", null);

            if (model.ClassName.Length > 200 ||
                (model.ClassNameEn?.Length > 200))
                return (400, "ClassSeries.NameMaxLength", null);

            if (model.ClassDescription?.Length > 1000 ||
                model.ClassDescriptionEn?.Length > 1000)
                return (400, "ClassSeries.DescriptionMaxLength", null);

            if (model.ExternalCoachName?.Length > 200)
                return (400, "ClassSeries.ExternalCoachNameMaxLength", null);

            if (model.ExternalCoachMobile?.Length > 20)
                return (400, "ClassSeries.ExternalCoachMobileMaxLength", null);

            if (model.Capacity <= 0)
                return (400, "ClassSeries.InvalidCapacity", null);

            if (model.RegistrationStartAt.HasValue &&
                model.RegistrationEndAt.HasValue &&
                model.RegistrationEndAt.Value < model.RegistrationStartAt.Value)
            {
                return (400, "ClassSeries.InvalidRegistrationDates", null);
            }

            // طبق Constraint جدول، تعیین مربی داخلی یا نام مربی خارجی الزامی است.
            if (!model.CoachEmployeeId.HasValue &&
                string.IsNullOrWhiteSpace(model.ExternalCoachName))
            {
                return (400, "ClassSeries.CoachRequired", null);
            }

            if (!_currentUser.UserId.HasValue ||
                _currentUser.UserId.Value <= 0 ||
                _currentUser.UserId.Value > int.MaxValue)
            {
                return (401, "Common.Unauthorized", null);
            }

            return await _repository.SaveAsync(
                model,
                (int)_currentUser.UserId.Value);
        }

        public async Task<(int ResultCode, string ResultMessage, bool Data)>
            DeleteAsync(long classSeriesId)
        {
            if (classSeriesId <= 0)
                return (400, "Common.InvalidId", false);

            if (!_currentUser.UserId.HasValue ||
                _currentUser.UserId.Value <= 0)
            {
                return (401, "Common.Unauthorized", false);
            }

            return await _repository.DeleteAsync(
                classSeriesId,
                _currentUser.UserId.Value);
        }
    }
}
