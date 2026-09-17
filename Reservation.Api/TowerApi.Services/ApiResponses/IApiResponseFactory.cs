using TowerApi.Models.Common;

namespace TowerApi.Services.ApiResponses
{
    public interface IApiResponseFactory
    {
        ApiResponse<T> Success<T>(
            int code,
            string messageKey,
            T? data = default);

        ApiResponse Error(
            int code,
            string messageKey);
    }
}
