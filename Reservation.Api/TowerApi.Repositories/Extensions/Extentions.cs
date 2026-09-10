using Microsoft.Extensions.DependencyInjection;
using TowerApi.Repositories.Auth;
using TowerApi.Repositories.DataBase;
using TowerApi.Repositories.Organization;

namespace TowerApi.Repositories.Extensions
{
    public static class Extentions
    {
        public static IServiceCollection RepositoriesExtention(this IServiceCollection _services)
        {
            _services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            _services.AddScoped<IAuthRepository, AuthRepository>();
            _services.AddScoped<IOrganizationsRepository, OrganizationsRepository>();

            return _services;
        }
    }
}
