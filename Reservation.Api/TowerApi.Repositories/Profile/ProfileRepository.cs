using System.Data;
using Dapper;
using TowerApi.Models.Profile;
using TowerApi.Repositories.DataBase;

namespace TowerApi.Repositories.Profile
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProfileRepository(
            IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            CompleteProfileResponse? Data
        )> CompleteProfileAsync(
            long userId,
            CompleteProfileRequest request)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@UserId",
                userId,
                DbType.Int64);

            // =========================
            // Users
            // =========================

            parameters.Add(
                "@FirstName",
                request.FirstName);

            parameters.Add(
                "@LastName",
                request.LastName);

            parameters.Add(
                "@Email",
                request.Email);

            parameters.Add(
                "@NationalId",
                request.NationalId);

            parameters.Add(
                "@Gender",
                request.Gender);

            parameters.Add(
                "@BirthDate",
                request.BirthDate);

            parameters.Add(
                "@AvatarUrl",
                request.AvatarUrl);


            // =========================
            // UserProfiles
            // =========================

            parameters.Add(
                "@FatherName",
                request.FatherName);

            parameters.Add(
                "@BirthPlace",
                request.BirthPlace);

            parameters.Add(
                "@LandlinePhone",
                request.LandlinePhone);

            parameters.Add(
                "@UserPostalCode",
                request.UserPostalCode);

            parameters.Add(
                "@UserAddress",
                request.UserAddress);

            parameters.Add(
                "@EmergencyContactName",
                request.EmergencyContactName);

            parameters.Add(
                "@EmergencyContactMobile",
                request.EmergencyContactMobile);

            parameters.Add(
                "@EmergencyContactRelation",
                request.EmergencyContactRelation);

            parameters.Add(
                "@ProfileNotes",
                request.ProfileNotes);


            // =========================
            // UserResidencies
            // =========================

            parameters.Add(
                "@UnitId",
                request.UnitId);

            parameters.Add(
                "@RelationshipType",
                request.RelationshipType);

            parameters.Add(
                "@StartDate",
                request.StartDate);

            parameters.Add(
                "@EndDate",
                request.EndDate);

            parameters.Add(
                "@ResidencyNotes",
                request.ResidencyNotes);


            // =========================
            // Output
            // =========================

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);


            using var multi =
                await connection.QueryMultipleAsync(
                    "dbo.UsersCompleteProfile",
                    parameters,
                    commandType: CommandType.StoredProcedure);


            var user =
                await multi.ReadFirstOrDefaultAsync<
                    CompleteProfileUser>();

            var profile =
                await multi.ReadFirstOrDefaultAsync<
                    CompleteProfileDetails>();

            var residencies =
                (await multi.ReadAsync<
                    CompleteProfileResidency>())
                .ToList();


            var resultCode =
                parameters.Get<int>("@ResultCode");

            var resultMessage =
                parameters.Get<string>("@ResultMessage");


            CompleteProfileResponse? response = null;

            if (user != null)
            {
                response = new CompleteProfileResponse
                {
                    User = user,
                    Profile = profile,
                    Residencies = residencies
                };
            }


            return (
                resultCode,
                resultMessage,
                response
            );
        }

        public async Task<(
            int ResultCode,
            string ResultMessage,
            UserProfileResponse? Data)>
            GetAsync(long userId)
        {
            using var connection =
                _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add(
                "@UserId",
                userId,
                DbType.Int64);

            parameters.Add(
                "@ResultCode",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            parameters.Add(
                "@ResultMessage",
                dbType: DbType.String,
                size: 500,
                direction: ParameterDirection.Output);

            var data =
                await connection.QueryFirstOrDefaultAsync<UserProfileResponse>(
                    "dbo.UserProfilesGet",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            var resultCode =
                parameters.Get<int>("@ResultCode");

            var resultMessage =
                parameters.Get<string>("@ResultMessage");

            return (
                resultCode,
                resultMessage,
                data);
        }
    }
}
