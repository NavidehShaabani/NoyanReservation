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
                using var connection =
                    _connectionFactory.CreateConnection();

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

                result.User =
                    multi
                        .Read<UserInfo>()
                        .FirstOrDefault();

                // =====================================================
                // Result Set 2 : Roles + Menus
                // =====================================================

                var rows =
                    multi
                        .Read<LoginRoleMenuRow>()
                        .ToList();

                // =====================================================
                // Group Roles
                // =====================================================

                result.Roles =
                    rows
                        .GroupBy(x => new
                        {
                            x.RoleId,
                            x.RoleCode,
                            x.RoleNameFa,
                            x.RoleNameEn,
                            x.RoleDescriptionFa,
                            x.RoleDescriptionEn
                        })
                        .Select(roleGroup =>
                        {
                            var menus =
                                roleGroup
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

                                        IsPermission =
                                            x.PermissionLevel > 1,

                                        Permission =
                                            PermissionHelper.GetPermissionInfo(
                                                x.PermissionLevel)
                                    })
                                    .ToList();

                            return new UserRole
                            {
                                RoleId = roleGroup.Key.RoleId,

                                RoleCode =
                                    roleGroup.Key.RoleCode
                                    ?? string.Empty,

                                RoleName = new LocalizedText
                                {
                                    Fa =
                                        roleGroup.Key.RoleNameFa
                                        ?? string.Empty,

                                    En =
                                        roleGroup.Key.RoleNameEn
                                        ?? string.Empty
                                },

                                RoleDescription = new LocalizedText
                                {
                                    Fa =
                                        roleGroup.Key.RoleDescriptionFa
                                        ?? string.Empty,

                                    En =
                                        roleGroup.Key.RoleDescriptionEn
                                        ?? string.Empty
                                },

                                Menus = BuildMenuTree(menus)
                            };
                        })
                        .ToList();

                // =====================================================
                // Output Parameters
                // =====================================================

                result.ResultCode =
                    parameters.Get<int>("@ResultCode");

                result.ResultMessage =
                    parameters.Get<string>("@ResultMessage")
                    ?? string.Empty;

                return result;
            }
            catch (Exception ex)
            {
                return new LoginResult
                {
                    ResultCode = 500,
                    ResultMessage =
                        $"خطا در انجام عملیات ورود: {ex.Message}"
                };
            }
        }
        public async Task<LoginResult?> GetUserForRefreshAsync(long userId)
        {
            try
            {
                using var connection = _connectionFactory.CreateConnection();

                using var multi = await connection.QueryMultipleAsync(
                    "dbo.UserGetForRefresh",
                    new { UserId = userId },
                    commandType: CommandType.StoredProcedure
                );

                var result = new LoginResult
                {
                    User = (await multi.ReadAsync<UserInfo>()).FirstOrDefault(),
                    Roles = new List<UserRole>()
                };

                if (result.User == null)
                {
                    result.ResultCode = 401;
                    result.ResultMessage = "کاربر یافت نشد یا غیرفعال است.";
                    return result;
                }

                var rows = (await multi.ReadAsync<LoginRoleMenuRow>()).ToList();

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
                    .Select(roleGroup =>
                    {
                        var menus = roleGroup
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
                                Permission = PermissionHelper.GetPermissionInfo(
                                    x.PermissionLevel)
                            })
                            .ToList();

                        return new UserRole
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
                            Menus = BuildMenuTree(menus)
                        };
                    })
                    .ToList();

                if (!result.Roles.Any())
                {
                    result.ResultCode = 401;
                    result.ResultMessage =
                        "کاربر فاقد نقش فعال است و اجازه ادامه فعالیت ندارد.";
                    result.User = null;
                    result.Roles = new List<UserRole>();
                    return result;
                }

                result.ResultCode = 200;
                result.ResultMessage = "اطلاعات کاربر با موفقیت دریافت شد.";
                return result;
            }
            catch (Exception)
            {
                return new LoginResult
                {
                    User = null,
                    Roles = new List<UserRole>(),
                    ResultCode = 500,
                    ResultMessage = "خطا در دریافت اطلاعات کاربر."
                };
            }
        }
        private static List<UserMenu> BuildMenuTree(List<UserMenu> menus)
        {
            var lookup =
                menus.ToDictionary(
                    x => x.MenuId,
                    x => x);

            var roots = new List<UserMenu>();

            foreach (var menu in menus)
            {
                // -----------------------------
                // Root menu
                // -----------------------------

                if (!menu.ParentId.HasValue)
                {
                    roots.Add(menu);
                    continue;
                }

                // -----------------------------
                // Child menu
                // -----------------------------

                if (lookup.TryGetValue(
                        menu.ParentId.Value,
                        out var parent))
                {
                    parent.Children.Add(menu);
                }
            }

            // -----------------------------
            // Sort children recursively
            // -----------------------------

            SortMenuTree(roots);

            return roots;
        }
        private static void SortMenuTree(List<UserMenu> menus)
        {
            menus.Sort(
                (x, y) =>
                    x.SortOrder.CompareTo(y.SortOrder));

            foreach (var menu in menus)
            {
                if (menu.Children.Count > 0)
                {
                    SortMenuTree(menu.Children);
                }
            }
        }
    }
}
