using TowerApi.Models.Geo;
using TowerApi.Repositories.Geo;

namespace TowerApi.Services.Geo
{
    public class GeoService : IGeoService
    {
        private readonly IGeoRepository _repository;

        public GeoService(IGeoRepository repository)
        {
            _repository = repository;
        }

        public async Task<(
            int ResultCode,
            string MessageKey,
            List<GeoItemResponse> Data
        )> GetChildrenAsync(
            GeoChildrenQueryRequest request)
        {
            if (request.GeoType < 1 || request.GeoType > 5)
            {
                return (
                    400,
                    "Geo.InvalidGeoType",
                    new List<GeoItemResponse>());
            }

            if (request.GeoType == 1 &&
                !string.IsNullOrWhiteSpace(request.ParentGeoId))
            {
                return (
                    400,
                    "Geo.ParentNotAllowedForCountries",
                    new List<GeoItemResponse>());
            }

            if (request.GeoType > 1 &&
                string.IsNullOrWhiteSpace(request.ParentGeoId))
            {
                return (
                    400,
                    "Geo.ParentRequired",
                    new List<GeoItemResponse>());
            }

            request.ParentGeoId =
                string.IsNullOrWhiteSpace(request.ParentGeoId)
                    ? null
                    : request.ParentGeoId.Trim();

            request.Search =
                string.IsNullOrWhiteSpace(request.Search)
                    ? null
                    : request.Search.Trim();

            try
            {
                var result =
                    await _repository.GetChildrenAsync(request);

                if (result.ResultCode == 200)
                {
                    return (
                        200,
                        "Geo.GetChildrenSuccessfully",
                        result.Data);
                }

                if (result.ResultCode == 400)
                {
                    // ممکن است شناسه والد در دیتابیس معتبر نباشد.
                    return (
                        400,
                        "Geo.InvalidParent",
                        new List<GeoItemResponse>());
                }

                return (
                    result.ResultCode,
                    result.ResultCode == 404
                        ? "Geo.NotFound"
                        : "Common.SystemError",
                    new List<GeoItemResponse>());
            }
            catch
            {
                return (
                    500,
                    "Common.SystemError",
                    new List<GeoItemResponse>());
            }
        }
    }
}
