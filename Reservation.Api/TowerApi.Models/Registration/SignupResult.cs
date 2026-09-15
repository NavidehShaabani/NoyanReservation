using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Models.Registration
{
    public class SignupResult
    {
        public long? UserId { get; set; }

        public long? OtpRequestId { get; set; }

        public string? OtpCode { get; set; }

        public DateTime? OtpExpiresAt { get; set; }
    }
}
