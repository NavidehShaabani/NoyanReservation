using TowerApi.Models.Geo;

namespace TowerApi.Repositories.Geo
{
    public interface IGeoRepository
    {
        Task<(
            int ResultCode,
            string ResultMessage,
            List<GeoItemResponse> Data
        )> GetChildrenAsync(
            GeoChildrenQueryRequest request);
        Task<(
            int ResultCode,
            string? ResultMessage,
            GeoResponseGetById? Data
        )> GetByIdAsync(string geoId);
    }
}
