using TowerApi.Extensions;
using TowerApi.Models.Auth;

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

        public UserSession? User
        {
            get
            {
                return _httpContextAccessor
                    .HttpContext?
                    .Session
                    .GetUserSession();
            }
        }

        public bool IsAuthenticated =>
            User != null;

        public long? UserId =>
            User?.UserId;


        public bool IsInRole(string roleName)
        {
            return User?.Roles.Any(x =>
                string.Equals(
                    x.RoleName,
                    roleName,
                    StringComparison.OrdinalIgnoreCase)
            ) == true;
        }


        public bool HasPermission(
            long menuId,
            int requiredLevel)
        {
            var menu = User?.Menus
                .FirstOrDefault(x => x.MenuId == menuId);

            if (menu == null)
                return false;

            return menu.PermissionLevel >= requiredLevel;
        }
    }
}
