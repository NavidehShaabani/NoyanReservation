namespace TowerApi.Models.Geo
{
    public class GeoChildrenQueryRequest
    {
        public Int16 GeoType { get; set; }

        public string? ParentGeoId { get; set; }

        public string? Search { get; set; }
    }
}
