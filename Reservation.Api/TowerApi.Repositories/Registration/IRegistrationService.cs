using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerApi.Models.Registration;

namespace TowerApi.Repositories.Registration
{
    public interface IRegistrationService
    {
        Task<(
            int ResultCode,
            string ResultMessage,
            MobileSignupResponse? Data
        )> MobileSignupAsync(
            MobileSignupRequest request,
            string? requestIp,
            string? userAgent);

        Task<(
            int ResultCode,
            string ResultMessage,
            UsernameSignupResponse? Data
        )> UsernameSignupAsync(
            UsernameSignupRequest request,
            string? requestIp,
            string? userAgent);

        Task<(
            int ResultCode,
            string ResultMessage,
            VerifyOtpResponse? Data
        )> VerifyOtpAsync(
            VerifyOtpRequest request);
    }
}
