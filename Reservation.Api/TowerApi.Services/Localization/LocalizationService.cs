using System.Resources;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace TowerApi.Services.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ResourceManager _resourceManager;

        public LocalizationService(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            _resourceManager =
                new ResourceManager(
                    "TowerApi.Services.Localization.Resources.Messages",
                    typeof(LocalizationService).Assembly);
        }

        public string Get(string key)
        {
            var language = GetCurrentLanguage();

            try
            {
                var culture =
                    CultureInfo.GetCultureInfo(language);

                var message =
                    _resourceManager.GetString(
                        key,
                        culture);

                if (!string.IsNullOrWhiteSpace(message))
                {
                    return message;
                }
            }
            catch
            {
                // Ignore localization errors
            }

            // Fallback to Persian
            try
            {
                var fallback =
                    _resourceManager.GetString(
                        key,
                        CultureInfo.GetCultureInfo(
                            SupportedLanguages.Persian));

                if (!string.IsNullOrWhiteSpace(fallback))
                {
                    return fallback;
                }
            }
            catch
            {
                // Ignore fallback errors
            }

            return key;
        }

        private string GetCurrentLanguage()
        {
            var language =
                _httpContextAccessor.HttpContext?
                    .Request
                    .Headers["Accept-Language"]
                    .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(language))
            {
                return SupportedLanguages.Persian;
            }

            language = language
                .Split(',')
                .FirstOrDefault()?
                .Trim()
                .ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(language))
            {
                return SupportedLanguages.Persian;
            }

            // Example:
            // en-US -> en
            // fa-IR -> fa
            // ar-SA -> ar

            if (language.Contains('-'))
            {
                language =
                    language.Split('-')[0];
            }

            if (SupportedLanguages.All.Contains(language))
            {
                return language;
            }

            return SupportedLanguages.Persian;
        }
    }
}