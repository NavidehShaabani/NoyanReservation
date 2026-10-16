using TowerApi.Models.Registration;
using TowerApi.Models.Registration.TowerApi.Models.Registration;

namespace TowerApi.Repositories.Registration
{
    public interface IRegistrationRepository
    {
        //Task<(
        //    int ResultCode,
        //    string ResultMessage,
        //    MobileSignupResponse? Data,
        //    string? OtpCode
        //)> MobileSignupAsync(
        //    string mobile,
        //    string? requestIp,
        //    string? userAgent);

        Task<RegistrationResult> SignupAsync(
           MobileSignupRequest request,
           string? passwordHash,
           string? requestIp,
           string? userAgent);

        //Task<(
        //    int ResultCode,
        //    string ResultMessage,
        //    VerifyOtpResponse? Data
        //)> VerifyOtpAsync(
        //    VerifyOtpRequest request);
    }
}
