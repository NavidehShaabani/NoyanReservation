using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerApi.Models.Booking.Participant
{
    public sealed class ParticipantModel
    {
        public long ParticipantId { get; set; }
        public long? UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
        public byte ParticipantType { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UserCreater { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }
    }

    public sealed class ParticipantSaveRequest
    {
        public long? ParticipantId { get; set; }
        public long? UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
        public byte ParticipantType { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
