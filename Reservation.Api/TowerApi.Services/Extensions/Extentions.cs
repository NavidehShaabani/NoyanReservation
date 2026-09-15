using Microsoft.Extensions.DependencyInjection;
using TowerApi.Repositories.Auth;
using TowerApi.Repositories.Building;
using TowerApi.Repositories.DataBase;
using TowerApi.Repositories.Organization;
using TowerApi.Repositories.Unit;
using TowerApi.Services.Auth;
using TowerApi.Services.Profile;

namespace TowerApi.Repositories.Extensions
{
    public static class Extentions
    {
        public static IServiceCollection ServiceExtention(this IServiceCollection _services)
        {
            _services.AddScoped<IAuthService, AuthService>();
            _services.AddScoped<IProfileService,ProfileService>();
            return _services;
        }
    }
}
