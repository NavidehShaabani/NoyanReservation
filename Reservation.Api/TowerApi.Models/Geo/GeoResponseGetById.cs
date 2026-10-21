

namespace TowerApi.Models.Geo
{
    public class GeoResponseGetById
    {
        public string GeoId { get; set; } = string.Empty;
        public string? GeoNameFa { get; set; }
        public string? GeoNameEn { get; set; }
        public int? GeoType { get; set; }
        public string? ParantId { get; set; }
        public string? PL1 { get; set; }
        public string? PL2 { get; set; }
        public string? PL3 { get; set; }
        public string? PL4 { get; set; }
        public string? PL5 { get; set; }
        public string? GeoPathFa { get; set; }
        public string? GeoPathEn { get; set; }
    }
}
