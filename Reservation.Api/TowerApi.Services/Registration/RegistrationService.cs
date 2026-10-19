
using TowerApi.Models.Registration;
using TowerApi.Repositories.Registration;

namespace TowerApi.Services.Registration
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _repository;


        public RegistrationService(IRegistrationRepository repository)

        {
            _repository = repository;

        }

        public async Task<RegistrationOperationResult> MobileSignupAsync(
            MobileSignupRequest request,
            string? requestIp,
            string? userAgent)
        {
            if (request == null)
            {
                return new RegistrationOperationResult
                {
                    ResultCode = 400,
                    ResultMessage = "اطلاعات ثبت‌نام الزامی است."
                };
            }

            if (string.IsNullOrWhiteSpace(request.Mobile))
            {
                return new RegistrationOperationResult
                {
                    ResultCode = 400,
                    ResultMessage = "شماره موبایل الزامی است."
                };
            }

            string? passwordHash = null;

            if (!string.IsNullOrWhiteSpace(request.Username))
            {
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new RegistrationOperationResult
                    {
                        ResultCode = 400,
                        ResultMessage =
                            "برای ثبت‌نام با نام کاربری، رمز عبور الزامی است."
                    };
                }

                passwordHash = "1234";
            }

            var result = await _repository.MobileSignupAsync(
                request,
                passwordHash,
                requestIp,
                userAgent);

            // در این نقطه، اگر ارسال پیامک پیاده‌سازی شده باشد،
            // باید فقط در صورت موفقیت ثبت OTP انجام شود.
            // OTP را به پاسخ عمومی API اضافه نکن.

            return result;
        }

        public async Task<RegistrationOperationResult> VerifyOtpAsync(
            VerifyOtpRequest request)
        {
            if (request == null ||
                request.UserId <= 0 ||
                request.OtpRequestId <= 0 ||
                string.IsNullOrWhiteSpace(request.OtpCode) ||
                request.OtpCode.Length != 6 ||
                request.OtpCode.Any(c => c < '0' || c > '9'))
            {
                return new RegistrationOperationResult
                {
                    ResultCode = 400,
                    ResultMessage = "اطلاعات تأیید کد معتبر نیست."
                };
            }

            return await _repository.VerifyOtpAsync(request);
        }

        public async Task<RegistrationResult> UsernameSignupAsync(
            UsernameSignupRequest request,
            string? requestIp,
            string? userAgent)
        {
            var passwordUser = new RegistrationPasswordUser
            {
                Username = request.Username
            };

            var passwordHash = "1234";

            return await _repository.SignupAsync(
                request,
                passwordHash,
                requestIp,
                userAgent);
        }
    }

    public sealed class RegistrationPasswordUser
    {
        public string Username { get; set; } = string.Empty;
    }
}
