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
            var result = new LoginResult();

            try
            {
                using var connection = _connectionFactory.CreateConnection();

                const string sql = @"
            -- =========================================
            -- Result Set 1: User
            -- =========================================

            SELECT
                u.UserId,
                u.Username,
                u.FirstName,
                u.LastName,
                CONCAT(u.FirstName, N' ', u.LastName) AS FullName,
                u.Email,
                u.Mobile,
                u.NationalId,
                u.Gender,
                u.BirthDate,
                u.PhoneVerified,
                u.LastLoginAt,
                u.CreatedAt,
                u.AvatarUrl AS Avatar
            FROM dbo.Users u
            WHERE u.UserId = @UserId
              AND u.IsActive = 1
              AND ISNULL(u.IsDeleted, 0) = 0;


            -- =========================================
            -- Result Set 2: Roles + Menus
            -- =========================================

            ;WITH MenuHierarchy AS
            (
                SELECT
                    m.MenuId,
                    m.ParentId,
                    m.TitleFa,
                    m.TitleEn,
                    m.MenuUrl,
                    m.Icon,
                    m.SortOrder,
                    m.MenuDescriptionFa,
                    m.MenuDescriptionEn,
                    0 AS MenuLevel,
                    CAST(
                        RIGHT(
                            '0000000000' + CAST(m.SortOrder AS VARCHAR(10)),
                            10
                        )
                        + '.' +
                        RIGHT(
                            '0000000000' + CAST(m.MenuId AS VARCHAR(10)),
                            10
                        )
                        AS VARCHAR(MAX)
                    ) AS HierarchyPath
                FROM dbo.Menus m
                WHERE m.ParentId IS NULL
                  AND m.IsActive = 1
                  AND ISNULL(m.IsDeleted, 0) = 0
                  AND m.IsVisible = 1

                UNION ALL

                SELECT
                    child.MenuId,
                    child.ParentId,
                    child.TitleFa,
                    child.TitleEn,
                    child.MenuUrl,
                    child.Icon,
                    child.SortOrder,
                    child.MenuDescriptionFa,
                    child.MenuDescriptionEn,
                    parent.MenuLevel + 1,
                    CAST(
                        parent.HierarchyPath
                        + '.' +
                        RIGHT(
                            '0000000000' + CAST(child.SortOrder AS VARCHAR(10)),
                            10
                        )
                        + '.' +
                        RIGHT(
                            '0000000000' + CAST(child.MenuId AS VARCHAR(10)),
                            10
                        )
                        AS VARCHAR(MAX)
                    )
                FROM dbo.Menus child
                INNER JOIN MenuHierarchy parent
                    ON child.ParentId = parent.MenuId
                WHERE child.IsActive = 1
                  AND ISNULL(child.IsDeleted, 0) = 0
                  AND child.IsVisible = 1
            )
            SELECT
                r.RoleId,
                r.RoleCode,
                r.RoleNameFa,
                r.RoleNameEn,
                r.RoleDescriptionFa,
                r.RoleDescriptionEn,

                mh.MenuId,
                mh.ParentId,
                mh.TitleFa,
                mh.TitleEn,
                mh.MenuUrl,
                mh.Icon,
                mh.SortOrder,
                mh.MenuDescriptionFa,
                mh.MenuDescriptionEn,
                mh.MenuLevel,

                CASE
                    WHEN rm.RoleMenuId IS NULL
                        THEN CAST(1 AS TINYINT)
                    ELSE rm.PermissionLevel
                END AS PermissionLevel,

                mh.HierarchyPath

            FROM dbo.UserRoles ur

            INNER JOIN dbo.Roles r
                ON r.RoleId = ur.RoleId

            CROSS JOIN MenuHierarchy mh

            LEFT JOIN dbo.RoleMenus rm
                ON rm.RoleId = r.RoleId
               AND rm.MenuId = mh.MenuId
               AND rm.IsActive = 1
               AND ISNULL(rm.IsDeleted, 0) = 0

            WHERE ur.UserId = @UserId
              AND ur.IsActive = 1
              AND ISNULL(ur.IsDeleted, 0) = 0
              AND (ur.ExpiresAt IS NULL OR ur.ExpiresAt > GETDATE())

            ORDER BY
                r.RoleId,
                mh.HierarchyPath

            OPTION (MAXRECURSION 100);
        ";

                using var multi = await connection.QueryMultipleAsync(
                    sql,
                    new { UserId = userId },
                    commandType: CommandType.Text
                );

                // =========================================
                // Result Set 1: User
                // =========================================

                result.User = multi
                    .Read<UserInfo>()
                    .FirstOrDefault();

                if (result.User == null)
                {
                    result.ResultCode = 401;
                    result.ResultMessage = "کاربر یافت نشد یا غیرفعال است.";
                    result.Roles = new List<UserRole>();

                    return result;
                }

                // =========================================
                // Result Set 2: Roles + Menus
                // =========================================

                var rows = multi
                    .Read<LoginRoleMenuRow>()
                    .ToList();

                // =========================================
                // Group Roles
                // =========================================

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

                                Permission =
                                    PermissionHelper.GetPermissionInfo(
                                        x.PermissionLevel
                                    )
                            })
                            .ToList();

                        return new UserRole
                        {
                            RoleId = roleGroup.Key.RoleId,

                            RoleCode =
                                roleGroup.Key.RoleCode ?? string.Empty,

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

                // =========================================
                // Validate Roles
                // =========================================

                if (result.Roles == null || !result.Roles.Any())
                {
                    result.ResultCode = 401;
                    result.ResultMessage =
                        "کاربر فاقد نقش فعال است و اجازه ادامه فعالیت ندارد.";

                    result.User = null;
                    result.Roles = new List<UserRole>();

                    return result;
                }

                // =========================================
                // Success
                // =========================================

                result.ResultCode = 200;
                result.ResultMessage =
                    "اطلاعات کاربر با موفقیت دریافت شد.";

                return result;
            }
            catch (Exception)
            {
                return new LoginResult
                {
                    User = null,
                    Roles = new List<UserRole>(),
                    ResultCode = 500,
                    ResultMessage =
                        "خطا در دریافت اطلاعات کاربر."
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
