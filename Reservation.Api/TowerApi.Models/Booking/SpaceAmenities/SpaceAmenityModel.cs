namespace TowerApi.Models.Booking.SpaceAmenities
{
    public class SpaceAmenityModel
    {
        public long SpaceAmenityId { get; set; }
        public long SpaceId { get; set; }

        public string AmenityName { get; set; } = string.Empty;
        public string? AmenityNameEn { get; set; }

        public string? AmenityDescription { get; set; }
        public string? AmenityDescriptionEn { get; set; }

        public bool IsAvailable { get; set; } = true;
    }

    public class SpaceAmenityListRequest
    {
        public long? SpaceId { get; set; }
        public bool OnlyAvailable { get; set; }
    }
}
