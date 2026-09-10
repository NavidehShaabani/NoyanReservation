using Microsoft.Extensions.DependencyInjection;
using TowerApi.Repositories.Auth;
using TowerApi.Repositories.Building;
using TowerApi.Repositories.DataBase;
using TowerApi.Repositories.Organization;
using TowerApi.Repositories.Unit;

namespace TowerApi.Repositories.Extensions
{
    public static class Extentions
    {
        public static IServiceCollection RepositoriesExtention(this IServiceCollection _services)
        {
            _services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            _services.AddScoped<IAuthRepository, AuthRepository>();
            _services.AddScoped<IOrganizationRepository,OrganizationRepository>();
            _services.AddScoped<IBuildingRepository,BuildingRepository>();
            _services.AddScoped<IUnitRepository,UnitRepository>();
            return _services;
        }
    }
}
