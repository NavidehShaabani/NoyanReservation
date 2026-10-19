using TowerApi.Models.Signup;
using TowerApi.Repositories.Signup;

namespace TowerApi.Services.Signup
{
    public class SignupService : ISignupService
    {
        private readonly ISignupRepository _repository;

        public SignupService(ISignupRepository repository)
        {
            _repository = repository;
        }

        public async Task<SignupServiceResult<SignupWithPasswordData>>
            SignupWithPasswordAsync(
                SignupWithPasswordRequest request,
                string? requestIp)
        {
            if (string.IsNullOrWhiteSpace(request.Username) ||
                request.Username.Trim().Length < 3 ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.OrgName) ||
                string.IsNullOrWhiteSpace(request.GeoId) ||
                request.OrgType <= 0)
            {
                return Fail<SignupWithPasswordData>(
                    400, "Signup.InvalidData");
            }

            var username = request.Username.Trim();
            var orgName = request.OrgName.Trim();
            var geoId = request.GeoId.Trim();

            // رمز خام فقط در حافظه استفاده می‌شود؛ به دیتابیس ارسال نمی‌شود.
            var passwordHash = "1234";

            var result = await _repository.SignupWithPasswordAsync(
                username,
                passwordHash,
                orgName,
                request.OrgType,
                geoId,
                requestIp);

            if (result.Code != 200)
            {
                return Fail<SignupWithPasswordData>(
                    result.Code, MapMessageKey(result.Code, result.Message));
            }

            return new SignupServiceResult<SignupWithPasswordData>
            {
                Code = 200,
                MessageKey = "Signup.RegisterSuccessfully",
                Data = result.Data
            };
        }

        public async Task<SignupServiceResult<SignupStartOtpData>>
            StartOtpAsync(
                SignupStartOtpRequest request,
                string? requestIp,
                string? userAgent)
        {
            if (string.IsNullOrWhiteSpace(request.Mobile) ||
                request.Mobile.Trim().Length < 10 ||
                string.IsNullOrWhiteSpace(request.OrgName) ||
                string.IsNullOrWhiteSpace(request.GeoId) ||
                request.OrgType <= 0)
            {
                return Fail<SignupStartOtpData>(
                    400, "Signup.InvalidData");
            }

            var result = await _repository.StartOtpAsync(
                request.Mobile.Trim(),
                request.OrgName.Trim(),
                request.OrgType,
                request.GeoId.Trim(),
                requestIp,
                userAgent);

            if (result.Code != 200)
            {
                return Fail<SignupStartOtpData>(
                    result.Code, MapMessageKey(result.Code, result.Message));
            }

            return new SignupServiceResult<SignupStartOtpData>
            {
                Code = 200,
                MessageKey = "Signup.OtpRequestCreated",
                Data = result.Data
            };
        }

        public async Task<SignupServiceResult<SignupVerifyOtpData>>
            VerifyOtpAsync(SignupVerifyOtpRequest request)
        {
            if (request.UserId <= 0 ||
                request.OtpRequestId <= 0 ||
                string.IsNullOrWhiteSpace(request.OtpCode) ||
                request.OtpCode.Trim().Length != 4)
            {
                return Fail<SignupVerifyOtpData>(
                    400, "Signup.InvalidData");
            }

            var result = await _repository.VerifyOtpAsync(
                request.UserId,
                request.OtpRequestId,
                request.OtpCode.Trim());

            if (result.Code != 200)
            {
                return Fail<SignupVerifyOtpData>(
                    result.Code, MapMessageKey(result.Code, result.Message));
            }

            return new SignupServiceResult<SignupVerifyOtpData>
            {
                Code = 200,
                MessageKey = "Signup.OtpVerifiedSuccessfully",
                Data = result.Data
            };
        }

        private static SignupServiceResult<T> Fail<T>(
            int code, string messageKey)
        {
            return new SignupServiceResult<T>
            {
                Code = code,
                MessageKey = messageKey
            };
        }

        private static string MapMessageKey(int code, string message)
        {
            // در اینجا متن پیام دیتابیس به کاربر برگردانده نمی‌شود؛
            // کلید پایدار ترجمه استفاده می‌شود.
            if (code == 400)
            {
                if (message.Contains("موقعیت جغرافیایی"))
                    return "Signup.InvalidGeo";

                if (message.Contains("نوع سازمان"))
                    return "Signup.InvalidOrgType";

                if (message.Contains("رمز عبور") ||
                    message.Contains("نام کاربری"))
                    return "Signup.InvalidCredentials";

                return "Signup.InvalidData";
            }

            if (code == 401)
                return "Signup.InvalidOtp";

            if (code == 404)
                return "Signup.NotFound";

            if (code == 409)
            {
                if (message.Contains("نام کاربری"))
                    return "Signup.UsernameConflict";

                if (message.Contains("موبایل"))
                    return "Signup.MobileConflict";

                if (message.Contains("قبلاً استفاده شده"))
                    return "Signup.OtpAlreadyUsed";

                if (message.Contains("قبلاً فعال شده"))
                    return "Signup.AlreadyActivated";

                return "Signup.Conflict";
            }

            if (code == 410)
                return "Signup.OtpExpired";

            if (code == 429)
            {
                if (message.Contains("تلاش‌های مجاز"))
                    return "Signup.OtpAttemptsExceeded";

                return "Signup.RateLimited";
            }

            return "Common.SystemError";
        }
    }
}
