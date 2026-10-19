using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerApi.Models.Signup;

namespace TowerApi.Services.Signup
{
    public interface ISignupService
    {
        Task<SignupServiceResult<SignupWithPasswordData>>
            SignupWithPasswordAsync(
                SignupWithPasswordRequest request,
                string? requestIp);

        Task<SignupServiceResult<SignupStartOtpData>>
            StartOtpAsync(
                SignupStartOtpRequest request,
                string? requestIp,
                string? userAgent);

        Task<SignupServiceResult<SignupVerifyOtpData>>
            VerifyOtpAsync(SignupVerifyOtpRequest request);
    }
}
