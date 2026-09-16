using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Models.Profile
{
    public class UserProfileResponse
    {
        public long UserProfileId { get; set; }
        public long UserId { get; set; }

        public string? FatherName { get; set; }
        public string? BirthPlace { get; set; }
        public string? LandlinePhone { get; set; }
        public string? UserPostalCode { get; set; }
        public string? UserAddress { get; set; }

        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactMobile { get; set; }
        public string? EmergencyContactRelation { get; set; }

        public string? Notes { get; set; }

        public DateTime? CreatedAt { get; set; }
        public long? UserCreater { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public long? UserUpdater { get; set; }
    }
}
