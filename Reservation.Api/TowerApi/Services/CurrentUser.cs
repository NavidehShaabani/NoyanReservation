using System.Security.Claims;
using System.Text.Json;
using TowerApi.Models.Auth;
using TowerApi.Models.User;

namespace TowerApi.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal? ClaimsUser =>
            _httpContextAccessor
                .HttpContext?
                .User;

        public bool IsAuthenticated =>
            ClaimsUser?.Identity?.IsAuthenticated == true;

        public long? UserId
        {
            get
            {
                var claim =
                    ClaimsUser?.FindFirst(
                        ClaimTypes.NameIdentifier);

                if (claim == null)
                    return null;

                if (!long.TryParse(
                    claim.Value,
                    out var userId))
                {
                    return null;
                }

                return userId > 0
                    ? userId
                    : null;
            }
        }

        public UserSession? User
        {
            get
            {
                if (!IsAuthenticated)
                    return null;

                var user = new UserSession
                {
                    UserId = UserId ?? 0,

                    Username =
                        ClaimsUser?
                            .FindFirst(ClaimTypes.Name)?
                            .Value ?? string.Empty,

                    FirstName =
                        ClaimsUser?
                            .FindFirst("FirstName")?
                            .Value,

                    LastName =
                        ClaimsUser?
                            .FindFirst("LastName")?
                            .Value
                };

                var rolesClaim =
                    ClaimsUser?
                        .FindFirst("Roles")?
                        .Value;

                if (!string.IsNullOrWhiteSpace(rolesClaim))
                {
                    user.Roles =
                        JsonSerializer.Deserialize<
                            List<UserRole>>(
                                rolesClaim)
                        ?? new List<UserRole>();
                }

                var menusClaim =
                    ClaimsUser?
                        .FindFirst("Menus")?
                        .Value;

                if (!string.IsNullOrWhiteSpace(menusClaim))
                {
                    user.Menus =
                        JsonSerializer.Deserialize<
                            List<UserMenu>>(
                                menusClaim)
                        ?? new List<UserMenu>();
                }

                return user;
            }
        }

        public bool IsInRole(string roleName)
        {
            if (!IsAuthenticated ||
                string.IsNullOrWhiteSpace(roleName))
            {
                return false;
            }

            return ClaimsUser!.IsInRole(roleName);
        }

        public bool HasPermission(
            long menuId,
            int requiredLevel)
        {
            var menu = User?.Menus
                .FirstOrDefault(
                    x => x.MenuId == menuId);

            if (menu == null)
                return false;

            return menu.PermissionLevel >=
                   requiredLevel;
        }
    }
}
