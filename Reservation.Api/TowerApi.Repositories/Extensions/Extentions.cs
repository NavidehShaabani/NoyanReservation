using Microsoft.Extensions.DependencyInjection;
using TowerApi.Repositories.Auth;
using TowerApi.Repositories.Building;
using TowerApi.Repositories.DataBase;
using TowerApi.Repositories.EmployeeAssignments;
using TowerApi.Repositories.Employees;
using TowerApi.Repositories.EmployeeTypeRoles;
using TowerApi.Repositories.EmployeeTypes;
using TowerApi.Repositories.Geo;
using TowerApi.Repositories.LoginAttempt;
using TowerApi.Repositories.Organization;
using TowerApi.Repositories.Profile;
using TowerApi.Repositories.RefreshTokens;
using TowerApi.Repositories.SessionRepository;
using TowerApi.Repositories.Unit;

namespace TowerApi.Repositories.Extensions
{
    public static class Extentions
    {
        public static IServiceCollection RepositoriesExtention(this IServiceCollection _services)
        {
            _services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            _services.AddScoped<IAuthRepository, AuthRepository>();
            _services.AddScoped<ILoginAttemptRepository,LoginAttemptRepository>();
            _services.AddScoped<IUserSessionRepository, UserSessionRepository>();
            _services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            _services.AddScoped<IOrganizationRepository,OrganizationRepository>();
            _services.AddScoped<IBuildingRepository,BuildingRepository>();
            _services.AddScoped<IUnitRepository,UnitRepository>();
            _services.AddScoped<IProfileRepository,ProfileRepository>();
            _services.AddScoped<IGeoRepository, GeoRepository>();
            _services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
            _services.AddScoped<IEmployeeTypeRoleRepository, EmployeeTypeRoleRepository>();
            _services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            _services.AddScoped<IEmployeeAssignmentRepository, EmployeeAssignmentRepository>();
            
            return _services;
        }
    }
}
