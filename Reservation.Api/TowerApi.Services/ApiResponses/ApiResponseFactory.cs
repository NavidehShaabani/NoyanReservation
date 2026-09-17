
using TowerApi.Models.Common;
using TowerApi.Services.Localization;

namespace TowerApi.Services.ApiResponses
{
    public class ApiResponseFactory : IApiResponseFactory
    {
        private readonly ILocalizationService _localization;

        public ApiResponseFactory(
            ILocalizationService localization)
        {
            _localization = localization;
        }

        public ApiResponse<T> Success<T>(
            int code,
            string messageKey,
            T? data = default)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Code = code,
                MessageKey = messageKey,
                Message = _localization.Get(messageKey),
                Data = data
            };
        }

        public ApiResponse Error(
            int code,
            string messageKey)
        {
            return new ApiResponse
            {
                Success = false,
                Code = code,
                MessageKey = messageKey,
                Message = _localization.Get(messageKey)
            };
        }
    }
}
