namespace TowerApi.Models.Booking.ClassSeries
{
    public class ClassSeriesModel
    {
        public long ClassSeriesId { get; set; }
        public long OrgId { get; set; }

        public string ClassName { get; set; } = string.Empty;
        public string? ClassNameEn { get; set; }

        public string? ClassDescription { get; set; }
        public string? ClassDescriptionEn { get; set; }

        public long? CoachEmployeeId { get; set; }
        public string? ExternalCoachName { get; set; }
        public string? ExternalCoachMobile { get; set; }

        public int Capacity { get; set; }

        public bool IsRegistrationOpen { get; set; } = true;
        public DateTime? RegistrationStartAt { get; set; }
        public DateTime? RegistrationEndAt { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public class ClassSeriesListRequest
    {
        public long? OrgId { get; set; }
    }
}
