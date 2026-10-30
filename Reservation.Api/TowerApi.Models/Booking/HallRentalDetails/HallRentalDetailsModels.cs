using System.ComponentModel.DataAnnotations;

namespace TowerApi.Models.Booking.HallRentalDetails
{

    public sealed class HallRentalDetailsSaveRequest
    {
        [Range(1, long.MaxValue)]
        public long BookingId { get; set; }

        [Range(1, long.MaxValue)]
        public long RenterParticipantId { get; set; }

        [StringLength(500)]
        public string? RentalPurpose { get; set; }

        [StringLength(500)]
        public string? RentalPurposeEn { get; set; }

        [Range(0, int.MaxValue)]
        public int? ExpectedAttendeeCount { get; set; }

        [StringLength(1000)]
        public string? SetupNotes { get; set; }

        [StringLength(1000)]
        public string? SetupNotesEn { get; set; }

        [Range(typeof(decimal), "0", "9999999999999999")]
        public decimal? AgreedAmount { get; set; }

        [Range(typeof(decimal), "0", "9999999999999999")]
        public decimal DepositAmount { get; set; }

        [Range(typeof(decimal), "0", "9999999999999999")]
        public decimal? FinalAmount { get; set; }

        [StringLength(2000)]
        public string? RentalTerms { get; set; }

        [StringLength(2000)]
        public string? RentalTermsEn { get; set; }
    }

    public sealed class HallRentalDetailsQueryRequest
    {
        public long? RenterParticipantId { get; set; }

        public long? OrgId { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }

    public sealed class HallRentalDetailsViewModel
    {
        public long BookingId { get; set; }
        public long RenterParticipantId { get; set; }

        public string? RentalPurpose { get; set; }
        public string? RentalPurposeEn { get; set; }

        public int? ExpectedAttendeeCount { get; set; }

        public string? SetupNotes { get; set; }
        public string? SetupNotesEn { get; set; }

        public decimal? AgreedAmount { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal? FinalAmount { get; set; }

        public string? RentalTerms { get; set; }
        public string? RentalTermsEn { get; set; }

        public DateTime CreatedAt { get; set; }
        public int? UserCreater { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int? UserUpdater { get; set; }

        // اطلاعات رزرو اصلی که Stored Procedure برمی‌گرداند
        public long OrgId { get; set; }
        public long BuildingId { get; set; }
        public long SpaceId { get; set; }

        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        public byte BookingStatus { get; set; }
    }
}
