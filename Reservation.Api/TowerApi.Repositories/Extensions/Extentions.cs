using Microsoft.Extensions.DependencyInjection;
using TowerApi.Repositories.Auth;
using TowerApi.Repositories.BaseLookupValues;
using TowerApi.Repositories.Booking.BookingParticipant;
using TowerApi.Repositories.Booking.ClassSeries;
using TowerApi.Repositories.Booking.Equipment;
using TowerApi.Repositories.Booking.HallRentalDetails;
using TowerApi.Repositories.Booking.RentalParticipants;
using TowerApi.Repositories.Booking.ReservationEquipment;
using TowerApi.Repositories.Booking.SpaceAmenities;
using TowerApi.Repositories.Booking.SpaceBooking;
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
using TowerApi.Repositories.Signup;
using TowerApi.Repositories.Spaces;
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
            _services.AddScoped<ISignupRepository, SignupRepository>();
            _services.AddScoped<ISpaceRepository, SpaceRepository>();
            _services.AddScoped<IBaseLookupValueRepository,BaseLookupValueRepository>();
            _services.AddScoped<ISpaceBookingRepository,SpaceBookingRepository>();
            _services.AddScoped<IBookingParticipantRepository,BookingParticipantRepository>();
            _services.AddScoped<IHallRentalDetailsRepository,HallRentalDetailsRepository>();
            _services.AddScoped<IRentalParticipantsRepository, RentalParticipantsRepository>();
            _services.AddScoped<IReservationEquipmentRepository,ReservationEquipmentRepository>();
            _services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            _services.AddScoped<ISpaceAmenityRepository, SpaceAmenityRepository>();
            _services.AddScoped<IClassSeriesRepository, ClassSeriesRepository>();

            return _services;
        }
    }
}
