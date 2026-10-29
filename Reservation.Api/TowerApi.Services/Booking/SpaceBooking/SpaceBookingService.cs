using TowerApi.Models.Booking.SpaceBooking;
using TowerApi.Repositories.Booking.SpaceBooking;

namespace TowerApi.Services.Booking.SpaceBooking
{
    public class SpaceBookingService : ISpaceBookingService
    {
        private readonly ISpaceBookingRepository _repository;

        public SpaceBookingService(
            ISpaceBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            GetListAsync(SpaceBookingQueryRequest request)
        {
            if (request == null)
            {
                return (400, "پارامترهای جستجوی رزرو معتبر نیست.", null);
            }

            if (request.SpaceId.HasValue && request.SpaceId.Value <= 0)
            {
                return (400, "شناسه فضا نامعتبر است.", null);
            }

            if (request.OrgId.HasValue && request.OrgId.Value <= 0)
            {
                return (400, "شناسه سازمان نامعتبر است.", null);
            }

            if (request.StartFrom.HasValue &&
                request.StartTo.HasValue &&
                request.StartFrom.Value > request.StartTo.Value)
            {
                return (400, "بازه جستجوی زمانی معتبر نیست.", null);
            }

            if (request.BookingType.HasValue &&
                request.BookingType.Value is < 1 or > 2)
            {
                return (400, "نوع رزرو معتبر نیست.", null);
            }

            if (request.BookingStatus.HasValue &&
                request.BookingStatus.Value is < 1 or > 6)
            {
                return (400, "وضعیت رزرو معتبر نیست.", null);
            }

            var result = await _repository.GetListAsync(request);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            GetByIdAsync(long bookingId)
        {
            if (bookingId <= 0)
            {
                return (400, "شناسه رزرو نامعتبر است.", null);
            }

            var result = await _repository.GetByIdAsync(bookingId);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            AddAsync(SpaceBookingCreateRequest request, int userId)
        {
            if (request == null)
            {
                return (400, "اطلاعات رزرو ارسال نشده است.", null);
            }

            if (userId <= 0)
            {
                return (401, "کاربر احراز هویت نشده است.", null);
            }

            var validationMessage = ValidateBooking(
                request.OrgId,
                request.BuildingId,
                request.SpaceId,
                request.BookingType,
                request.StartAt,
                request.EndAt,
                request.BookingStatus,
                request.BookingTitle,
                request.BookingDescription,
                request.BookingDescriptionEn,
                request.RequestedByParticipantId);

            if (validationMessage != null)
            {
                return (400, validationMessage, null);
            }

            var result = await _repository.AddAsync(request, userId);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            EditAsync(
                long bookingId,
                SpaceBookingUpdateRequest request,
                int userId)
        {
            if (bookingId <= 0)
            {
                return (400, "شناسه رزرو نامعتبر است.", null);
            }

            if (request == null)
            {
                return (400, "اطلاعات رزرو ارسال نشده است.", null);
            }

            if (userId <= 0)
            {
                return (401, "کاربر احراز هویت نشده است.", null);
            }

            var validationMessage = ValidateBooking(
                request.OrgId,
                request.BuildingId,
                request.SpaceId,
                request.BookingType,
                request.StartAt,
                request.EndAt,
                request.BookingStatus,
                request.BookingTitle,
                request.BookingDescription,
                request.BookingDescriptionEn,
                request.RequestedByParticipantId);

            if (validationMessage != null)
            {
                return (400, validationMessage, null);
            }

            var result = await _repository.EditAsync(
                bookingId,
                request,
                userId);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            CheckConflictAsync(SpaceBookingConflictRequest request)
        {
            if (request == null)
            {
                return (400, "اطلاعات بررسی تداخل ارسال نشده است.", null);
            }

            if (request.SpaceId <= 0)
            {
                return (400, "شناسه فضا نامعتبر است.", null);
            }

            if (request.ExcludeBookingId.HasValue &&
                request.ExcludeBookingId.Value <= 0)
            {
                return (400, "شناسه رزرو جهت استثنا نامعتبر است.", null);
            }

            if (request.EndAt <= request.StartAt)
            {
                return (400, "زمان پایان باید بعد از زمان شروع باشد.", null);
            }

            var result = await _repository.CheckConflictAsync(request);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            ApproveAsync(long bookingId, int userId)
        {
            if (bookingId <= 0)
            {
                return (400, "شناسه رزرو نامعتبر است.", null);
            }

            if (userId <= 0)
            {
                return (401, "کاربر احراز هویت نشده است.", null);
            }

            var result = await _repository.ApproveAsync(bookingId, userId);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string ResultMessage, object? Data)>
            CancelAsync(long bookingId, int userId)
        {
            if (bookingId <= 0)
            {
                return (400, "شناسه رزرو نامعتبر است.", null);
            }

            if (userId <= 0)
            {
                return (401, "کاربر احراز هویت نشده است.", null);
            }

            var result = await _repository.CancelAsync(bookingId, userId);

            return (result.ResultCode, result.ResultMessage, result.Data);
        }

        public async Task<(int ResultCode, string ResultMessage)>
            DeleteAsync(long bookingId, int userId)
        {
            if (bookingId <= 0)
            {
                return (400, "شناسه رزرو نامعتبر است.");
            }

            if (userId <= 0)
            {
                return (401, "کاربر احراز هویت نشده است.");
            }

            return await _repository.DeleteAsync(bookingId, userId);
        }

        private static string? ValidateBooking(
            long orgId,
            long buildingId,
            long spaceId,
            byte bookingType,
            DateTime startAt,
            DateTime endAt,
            byte bookingStatus,
            string? bookingTitle,
            string? bookingDescription,
            string? bookingDescriptionEn,
            long? requestedByParticipantId)
        {
            if (orgId <= 0)
                return "شناسه سازمان نامعتبر است.";

            if (buildingId <= 0)
                return "شناسه ساختمان نامعتبر است.";

            if (spaceId <= 0)
                return "شناسه فضا نامعتبر است.";

            if (bookingType is < 1 or > 2)
                return "نوع رزرو معتبر نیست.";

            if (endAt <= startAt)
                return "زمان پایان باید بعد از زمان شروع باشد.";

            if (bookingStatus is < 1 or > 6)
                return "وضعیت رزرو معتبر نیست.";

            if (requestedByParticipantId.HasValue &&
                requestedByParticipantId.Value <= 0)
                return "شناسه درخواست‌کننده نامعتبر است.";

            if (bookingTitle?.Length > 200)
                return "عنوان رزرو نباید بیشتر از 200 کاراکتر باشد.";

            if (bookingDescription?.Length > 1000)
                return "توضیحات رزرو نباید بیشتر از 1000 کاراکتر باشد.";

            if (bookingDescriptionEn?.Length > 1000)
                return "توضیحات انگلیسی رزرو نباید بیشتر از 1000 کاراکتر باشد.";

            return null;
        }
    }
}
