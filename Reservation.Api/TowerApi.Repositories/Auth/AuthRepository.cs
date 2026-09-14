using System.Data;
using Dapper;
using TowerApi.Repositories.DataBase;
using TowerApi.Models.Auth;
using TowerApi.Models.User;
using TowerApi.Models.General;
using TowerApi.Services;

namespace TowerApi.Repositories.Auth
{

    public class AuthRepository : IAuthRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AuthRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<LoginResult> LoginAsync(LoginRequest user)
        {
            var result = new LoginResult();

            try
            {
                using var connection = _connectionFactory.CreateConnection();

                var parameters = new DynamicParameters();

                parameters.Add(
                    "@pUsername",
                    user.Username,
                    DbType.String,
                    ParameterDirection.Input);

                parameters.Add(
                    "@pPassword",
                    user.Password,
                    DbType.String,
                    ParameterDirection.Input);

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
                        "dbo.UserLogin",
                        parameters,
                        commandType: CommandType.StoredProcedure);


                // =====================================================
                // Result Set 1 : User
                // =====================================================

                result.User = multi
                    .Read<UserInfo>()
                    .FirstOrDefault();


                // =====================================================
                // Result Set 2 : Roles + Menus
                // =====================================================

                var rows = multi
                    .Read<LoginRoleMenuRow>()
                    .ToList();


                // =====================================================
                // Group Roles
                // =====================================================

                result.Roles = rows
                    .GroupBy(x => new
                    {
                        x.RoleId,
                        x.RoleCode,
                        x.RoleNameFa,
                        x.RoleNameEn,
                        x.RoleDescriptionFa,
                        x.RoleDescriptionEn
                    })
                    .Select(roleGroup => new UserRole
                    {
                        RoleId = roleGroup.Key.RoleId,

                        RoleCode = roleGroup.Key.RoleCode ?? string.Empty,

                        RoleName = new LocalizedText
                        {
                            Fa = roleGroup.Key.RoleNameFa ?? string.Empty,
                            En = roleGroup.Key.RoleNameEn ?? string.Empty
                        },

                        RoleDescription = new LocalizedText
                        {
                            Fa = roleGroup.Key.RoleDescriptionFa ?? string.Empty,
                            En = roleGroup.Key.RoleDescriptionEn ?? string.Empty
                        },

                        Menus = roleGroup
                            .Where(x => x.MenuId > 0)
                            .Select(x => new UserMenu
                            {
                                MenuId = x.MenuId,

                                RoleId = x.RoleId,

                                ParentId = x.ParentId,

                                Name = new LocalizedText
                                {
                                    Fa = x.TitleFa ?? string.Empty,
                                    En = x.TitleEn ?? string.Empty
                                },

                                MenuUrl = x.MenuUrl,

                                Icon = x.Icon,

                                SortOrder = x.SortOrder,

                                IsPermission = x.PermissionLevel > 1,

                                Permission =
                                    PermissionHelper.GetPermissionInfo(
                                        x.PermissionLevel)
                            })
                            .ToList()
                    })
                    .ToList();


                // =====================================================
                // Output Parameters
                // =====================================================

                result.ResultCode =
                    parameters.Get<int>("@ResultCode");

                result.ResultMessage =
                    parameters.Get<string>("@ResultMessage") ?? string.Empty;


                return result;
            }
            catch (Exception ex)
            {
                return new LoginResult
                {
                    ResultCode = 500,
                    ResultMessage = $"خطا در انجام عملیات ورود: {ex.Message}"
                };
            }
        }
    }
}
