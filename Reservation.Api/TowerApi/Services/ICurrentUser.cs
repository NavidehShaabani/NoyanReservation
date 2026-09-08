using TowerApi.Model.Auth;

namespace TowerApi.Services
{
    public interface ICurrentUser
    {
        UserSession? User { get; }

        bool IsAuthenticated { get; }

        long? UserId { get; }

        bool IsInRole(string roleName);

        bool HasPermission(
            long menuId,
            int requiredLevel);
    }
}
