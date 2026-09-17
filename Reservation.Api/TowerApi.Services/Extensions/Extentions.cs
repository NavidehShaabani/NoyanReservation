using Microsoft.Extensions.DependencyInjection;
using TowerApi.Repositories.Auth;
using TowerApi.Repositories.Building;
using TowerApi.Repositories.DataBase;
using TowerApi.Repositories.Organization;
using TowerApi.Repositories.Unit;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Auth;
using TowerApi.Services.Building;
using TowerApi.Services.Localization;
using TowerApi.Services.Organization;
using TowerApi.Services.Profile;
using TowerApi.Services.Unit;

namespace TowerApi.Services.Extensions
{
    public static class Extentions
    {
        public static IServiceCollection ServiceExtention(this IServiceCollection _services)
        {
            _services.AddScoped<IAuthService, AuthService>();
            _services.AddScoped<IProfileService,ProfileService>();
            _services.AddScoped<IBuildingService, BuildingService>();
            _services.AddScoped<IUnitService, UnitService>();
            _services.AddScoped<IOrganizationService, OrganizationService>();
            _services.AddScoped<ILocalizationService,LocalizationService>();
            _services.AddScoped<IApiResponseFactory,ApiResponseFactory>();
            return _services;
        }
    }
}
