
using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Booking
{
    public sealed class BookingParticipantSaveRequest
    {
        public long? ParticipantId { get; set; }

        public long? UserId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(20)]
        public string? MobileNumber { get; set; }

        [EmailAddress]
        [StringLength(254)]
        public string? Email { get; set; }

        [Range(1, byte.MaxValue)]
        public byte ParticipantType { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public sealed class BookingParticipantViewModel
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
}
