using TowerApi.Models.Registration;
using TowerApi.Models.Registration.TowerApi.Models.Registration;

namespace TowerApi.Repositories.Registration
{

    public interface IRegistrationService
    {
        Task<RegistrationResult> MobileSignupAsync(
            MobileSignupRequest request,
            string? requestIp,
            string? userAgent);

        Task<RegistrationResult> UsernameSignupAsync(
            UsernameSignupRequest request,
            string? requestIp,
            string? userAgent);

        Task<RegistrationResult> VerifyOtpAsync(
            VerifyOtpRequest request);
    }

}
