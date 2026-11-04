using Microsoft.Extensions.DependencyInjection;
using TowerApi.Services.ApiResponses;
using TowerApi.Services.Auth;
using TowerApi.Services.BaseLookupValues;
using TowerApi.Services.Booking.BookingParticipant;
using TowerApi.Services.Booking.ClassSeries;
using TowerApi.Services.Booking.ClassSession;
using TowerApi.Services.Booking.Equipment;
using TowerApi.Services.Booking.HallRentalDetails;
using TowerApi.Services.Booking.Participant;
using TowerApi.Services.Booking.RentalParticipants;
using TowerApi.Services.Booking.ReservationEquipment;
using TowerApi.Services.Booking.SpaceAmenities;
using TowerApi.Services.Booking.SpaceBooking;
using TowerApi.Services.Building;
using TowerApi.Services.BuildingConfiguration;
using TowerApi.Services.BuildingFloor;
using TowerApi.Services.BuildingFloorStaircase;
using TowerApi.Services.BuildingStaircase;
using TowerApi.Services.EmployeeAssignments;
using TowerApi.Services.Employees;
using TowerApi.Services.EmployeeTypeRoles;
using TowerApi.Services.EmployeeTypes;
using TowerApi.Services.Enrollment.EnrollmentClass;
using TowerApi.Services.Enrollment.EnrollmentWaitlist;
using TowerApi.Services.Geo;
using TowerApi.Services.Localization;
using TowerApi.Services.Organization;
using TowerApi.Services.Pricing.CommissionPlan;
using TowerApi.Services.Pricing.CommissionTier;
using TowerApi.Services.Pricing.PricingRule;
using TowerApi.Services.Profile;
using TowerApi.Services.Signup;
using TowerApi.Services.Spaces;
using TowerApi.Services.Unit;
using TowerApi.Services.UnitStaircase;

namespace TowerApi.Services.Extensions
{
    public static class Extentions
    {
        public static IServiceCollection ServiceExtention(this IServiceCollection _services)
        {
            _services.AddScoped<IAuthService, AuthService>();
            _services.AddScoped<IJwtService, JwtService>();
            _services.AddScoped<IProfileService,ProfileService>();
            _services.AddScoped<IBuildingService, BuildingService>();
            _services.AddScoped<IUnitService, UnitService>();
            _services.AddScoped<IOrganizationService, OrganizationService>();
            _services.AddScoped<ILocalizationService,LocalizationService>();
            _services.AddScoped<IApiResponseFactory,ApiResponseFactory>();
            _services.AddScoped<IGeoService, GeoService>();
            _services.AddScoped<IEmployeeTypeService, EmployeeTypeService>();
            _services.AddScoped<IEmployeeTypeRoleService, EmployeeTypeRoleService>();
            _services.AddScoped<IEmployeeService, EmployeeService>();
            _services.AddScoped<IEmployeeAssignmentService, EmployeeAssignmentService>();
            _services.AddScoped<ISignupService, SignupService>();
            _services.AddScoped<ISpaceService, SpaceService>();
            _services.AddScoped<IBaseLookupValueService,BaseLookupValueService>();
            _services.AddScoped<ISpaceBookingService,SpaceBookingService>();
            _services.AddScoped<IBookingParticipantService,BookingParticipantService>();
            _services.AddScoped<IHallRentalDetailsService,HallRentalDetailsService>();
            _services.AddScoped<IRentalParticipantsService, RentalParticipantsService>();
            _services.AddScoped<IReservationEquipmentService,ReservationEquipmentService>();
            _services.AddScoped<IEquipmentService, EquipmentService>();
            _services.AddScoped<ISpaceAmenityService, SpaceAmenityService>();
            _services.AddScoped<IClassSeriesService, ClassSeriesService>();
            _services.AddScoped<IClassSessionService, ClassSessionService>();
            _services.AddScoped<IParticipantService, ParticipantService>();
            _services.AddScoped<IEnrollmentClassService,EnrollmentClassService>();
            _services.AddScoped<IEnrollmentWaitlistService,EnrollmentWaitlistService>();
            _services.AddScoped<IPricingRuleService,PricingRuleService>();
            _services.AddScoped<IBuildingConfigurationService,BuildingConfigurationService>();
            _services.AddScoped<IBuildingFloorService,BuildingFloorService>();
            _services.AddScoped<IBuildingStaircaseService,BuildingStaircaseService>();
            _services.AddScoped<IBuildingFloorStaircaseService,BuildingFloorStaircaseService>();
            _services.AddScoped<IUnitStaircaseService,UnitStaircaseService>();
            _services.AddScoped<ICommissionPlanService, CommissionPlanService>();
            _services.AddScoped<ICommissionTierService,CommissionTierService>();

            return _services;
        }
    }
}
