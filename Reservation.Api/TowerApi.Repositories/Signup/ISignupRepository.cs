using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerApi.Models.Signup;

namespace TowerApi.Repositories.Signup
{
    public interface ISignupRepository
    {
        Task<SignupDbResult<SignupWithPasswordData>>
            SignupWithPasswordAsync(
                string username,
                string passwordHash,
                string orgName,
                int orgType,
                string geoId,
                string? requestIp);

        Task<SignupDbResult<SignupStartOtpData>>
            StartOtpAsync(
                string mobile,
                string orgName,
                int orgType,
                string geoId,
                string? requestIp,
                string? userAgent);

        Task<SignupDbResult<SignupVerifyOtpData>>
            VerifyOtpAsync(
                long userId,
                long otpRequestId,
                string otpCode);
    }
}
