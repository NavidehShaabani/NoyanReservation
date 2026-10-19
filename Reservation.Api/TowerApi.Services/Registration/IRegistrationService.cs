using TowerApi.Models.Registration;

namespace TowerApi.Repositories.Registration
{

    public interface IRegistrationService
    {

        Task<RegistrationResult> UsernameSignupAsync(
            UsernameSignupRequest request,
            string? requestIp,
            string? userAgent);

        Task<RegistrationOperationResult> MobileSignupAsync(
            MobileSignupRequest request,
            string? requestIp,
            string? userAgent);

        Task<RegistrationOperationResult> VerifyOtpAsync(
            VerifyOtpRequest request);
    }

}
