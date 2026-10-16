
using TowerApi.Models.Registration;
using TowerApi.Models.Registration.TowerApi.Models.Registration;
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

        public Task<RegistrationResult> MobileSignupAsync(
            MobileSignupRequest request,
            string? requestIp,
            string? userAgent)
        {
            return _repository.SignupAsync(
                request,
                null,
                requestIp,
                userAgent);
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

        public Task<RegistrationResult> VerifyOtpAsync(
            VerifyOtpRequest request)
        {
            throw new NotImplementedException(
                "باید به پروسیجر تأیید OTP فعلی پروژه متصل شود.");
        }
    }

    public sealed class RegistrationPasswordUser
    {
        public string Username { get; set; } = string.Empty;
    }
}
