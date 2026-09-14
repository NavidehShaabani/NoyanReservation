using System.Security.Claims;
using TowerApi.Models;
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


        // ============================================================
        // Claims User
        // ============================================================

        private ClaimsPrincipal? ClaimsUser =>
            _httpContextAccessor
                .HttpContext?
                .User;


        // ============================================================
        // Is Authenticated
        // ============================================================

        public bool IsAuthenticated =>
            ClaimsUser?.Identity?.IsAuthenticated == true;


        // ============================================================
        // UserId
        // ============================================================

        public long? UserId
        {
            get
            {
                var claim = ClaimsUser?
                    .FindFirst(ClaimTypes.NameIdentifier);

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


        // ============================================================
        // Username
        // ============================================================

        public string Username =>
            ClaimsUser?
                .FindFirst(ClaimTypes.Name)?
                .Value
            ?? string.Empty;


        // ============================================================
        // FirstName
        // ============================================================

        public string FirstName =>
            ClaimsUser?
                .FindFirst("FirstName")?
                .Value
            ?? string.Empty;


        // ============================================================
        // LastName
        // ============================================================

        public string LastName =>
            ClaimsUser?
                .FindFirst("LastName")?
                .Value
            ?? string.Empty;


        // ============================================================
        // FullName
        // ============================================================

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}".Trim();
            }
        }


        // ============================================================
        // Role Codes
        // ============================================================

        public List<string> RoleCodes
        {
            get
            {
                if (!IsAuthenticated)
                    return new List<string>();

                return ClaimsUser!
                    .FindAll(ClaimTypes.Role)
                    .Select(x => x.Value)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();
            }
        }


        // ============================================================
        // User Session
        // ============================================================

        public UserSession? User
        {
            get
            {
                if (!IsAuthenticated || !UserId.HasValue)
                    return null;

                var user = new UserSession
                {
                    UserId = UserId.Value,

                    Username = Username,

                    FirstName = FirstName,

                    LastName = LastName,

                    Roles = new List<UserRole>()
                };


                // ----------------------------------------------------
                // Build Roles from JWT Role Claims
                // ----------------------------------------------------

                foreach (var roleCode in RoleCodes)
                {
                    user.Roles.Add(
                        new UserRole
                        {
                            RoleCode = roleCode
                        });
                }


                return user;
            }
        }


        // ============================================================
        // IsInRole
        // ============================================================

        public bool IsInRole(string roleCode)
        {
            if (!IsAuthenticated ||
                string.IsNullOrWhiteSpace(roleCode))
            {
                return false;
            }

            return ClaimsUser!.IsInRole(roleCode);
        }
    }
}

