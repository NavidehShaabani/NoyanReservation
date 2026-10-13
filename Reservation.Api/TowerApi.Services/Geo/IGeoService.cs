
using TowerApi.Models.Geo;

namespace TowerApi.Services.Geo
{
    public interface IGeoService
    {
        Task<(
            int ResultCode,
            string MessageKey,
            List<GeoItemResponse> Data
        )> GetChildrenAsync(
            GeoChildrenQueryRequest request);
    }
}
