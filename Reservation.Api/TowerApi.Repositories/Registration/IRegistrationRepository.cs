using TowerApi.Models.Registration;

namespace TowerApi.Repositories.Registration
{
    public interface IRegistrationRepository
    {
        Task<RegistrationOperationResult> MobileSignupAsync(
            MobileSignupRequest request,
            string? passwordHash,
            string? requestIp,
            string? userAgent);

        Task<RegistrationOperationResult> VerifyOtpAsync(
            VerifyOtpRequest request);

        Task<RegistrationResult> SignupAsync(
           MobileSignupRequest request,
           string? passwordHash,
           string? requestIp,
           string? userAgent);

    }
}
